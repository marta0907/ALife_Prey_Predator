using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PreyPredatorModel.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PreyPredatorModel.Froms
{
    public partial class StatisticsForm : Form
    {
        Dictionary<int, Rule> rules = new Dictionary<int, Rule>()
        {
            { 0, new Rule() },
            { 1, new MooreRule() },
            { 2, new ExtendedNeumannRule() }
        };
        List<double> preysPopulation = new List<double>();
        List<double> predatorsPopulation = new List<double>();
        List<double> preysMeans = new List<double>();
        List<double> predatorsMeans = new List<double>();
        int steps = 500;
        Game game;
        PdfDocument pdfDocument;
        Guid guid;
        string file;
        public StatisticsForm()
        {
            InitializeComponent();
            guid = Guid.NewGuid();
            file = $"{guid}.pdf";
            pdfDocument = new PdfDocument();
        }

        Dictionary<int, string> neighborhoodtype = new Dictionary<int, string>()
        {
            { 0,"von Neumann" },
            { 1, "Moore" },
            { 2, "extended von Neumann" }
        };


        private void button_start_Click(object sender, EventArgs e)
        {
            preysMeans.Clear();
            predatorsMeans.Clear();
            RunGeneration();
            SaveImages();
            RunRVGeneration();
            SaveImages();
            SaveReport();
        }

        private void SaveImages()
        {
            PdfPage page1 = pdfDocument.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page1);

            StringBuilder builder = new StringBuilder();

            using (MemoryStream ms1 = new MemoryStream())
            {
                chart_predator.SaveImage(ms1, System.Drawing.Imaging.ImageFormat.Png);
                XImage im = XImage.FromStream(ms1);
                gfx.DrawImage(im, 20, 100);
            }

            using (MemoryStream ms2 = new MemoryStream())
            {
                chart_prey.SaveImage(ms2, System.Drawing.Imaging.ImageFormat.Png);
                XImage im = XImage.FromStream(ms2);
                gfx.DrawImage(im, 20, 400);
            } 

            pdfDocument.Save(file);
        }

        void SaveReport()
        {
            PdfPage page1 = pdfDocument.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page1);

            XFont font = new XFont("Arial", 10, XFontStyle.Regular, XPdfFontOptions.UnicodeDefault);

            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            var index = comboBox_ntype.SelectedIndex < 0 ? 0 : comboBox_ntype.SelectedIndex;
            builder1.AppendLine($"neighborhood type:\t{neighborhoodtype[index]}\n\n");

            builder1.AppendLine("Preys\n\n");
            builder2.AppendLine("Predators\n\n");

            builder1.Append($"prey death rate:\t\t\t\t\t\t\t");
            builder2.Append($"prey death rate:\t\t\t\t\t\t\t");
            for (int i = 0; i < 5; i++)
            {
                builder1.Append($"{Math.Round(preysMeans[i],5)}\t\t");
                builder2.Append($"{Math.Round(predatorsMeans[i], 5)}\t\t");
            }
            builder1.AppendLine();
            builder2.AppendLine();

            builder1.Append($"prey birth rate:\t\t\t\t\t\t\t\t\t");
            builder2.Append($"prey birth rate:\t\t\t\t\t\t\t\t\t");
            for (int i = 5; i < 10; i++)
            {
                builder1.Append($"{Math.Round(preysMeans[i], 5)}\t\t");
                builder2.Append($"{Math.Round(predatorsMeans[i], 5)}\t\t");
            }
            builder1.AppendLine();
            builder2.AppendLine();
            builder1.Append($"predator death rate:\t");
            builder2.Append($"predator death rate:\t");
            for (int i = 10; i < 15; i++)
            {
                builder1.Append($"{Math.Round(preysMeans[i], 5)}\t\t");
                builder2.Append($"{Math.Round(predatorsMeans[i], 5)}\t\t");
            }
            builder1.AppendLine();
            builder2.AppendLine();

            builder1.Append($"predator birth rate:\t\t\t");
            builder2.Append($"predator birth rate:\t\t\t");
            for (int i = 15; i < 20; i++)
            {
                builder1.Append($"{Math.Round(preysMeans[i], 5)}\t\t");
                builder2.Append($"{Math.Round(predatorsMeans[i], 5)}\t\t");
            }
            builder1.AppendLine();
            builder2.AppendLine();

            builder1.Append($"visibility radius:\t\t\t\t\t\t\t\t");
            builder2.Append($"visibility radius:\t\t\t\t\t\t\t\t");
            for (int i = 20; i < 25; i++)
            {
                builder1.Append($"{Math.Round(preysMeans[i], 5)}\t\t");
                builder2.Append($"{Math.Round(predatorsMeans[i], 5)}\t\t");
            }
            builder1.AppendLine();
            builder2.AppendLine();

            var formatter = new XTextFormatter(gfx);

            var layoutRectangle1 = new XRect(30, 30, page1.Width, page1.Height/4);
            var layoutRectangle2 = new XRect(30, 30 + page1.Height / 4 ,page1.Width, page1.Height);

            formatter.DrawString(builder1.ToString(), font, XBrushes.Black, layoutRectangle1);
            formatter.DrawString(builder2.ToString(), font, XBrushes.Black, layoutRectangle2);

            pdfDocument.Save(file);

            Process.Start(file);
        }

        private void RunGeneration()
        {
            for (int i = 0; i < 5; i++)
            {
                this.chart_prey.Series[i].Points.Clear();
                this.chart_predator.Series[i].Points.Clear();
            }
            var index = comboBox_ntype.SelectedIndex < 0 ? 0 : comboBox_ntype.SelectedIndex;
            var rule = rules[index];
            var conf = InitialPopulation.GetTestParameters;

            for (int i = 0; i < 20; i++)
            {
                Configuration configuration = new Configuration(
                    conf[i, 0],
                    conf[i, 1],
                    conf[i, 2],
                    conf[i, 3],
                    (int)conf[i, 4],
                    rule
                    );
                game = new Game(configuration);
                predatorsPopulation.Clear();
                preysPopulation.Clear();
                for (int s = 0; s < steps; s++)
                {
                    var predatorsPercentage = (double)game.GetPredators() / (double)game.GetPopulationSize();
                    var preysPercentage = (double)game.GetPreys() / (double)game.GetPopulationSize();
                    predatorsPopulation.Add(predatorsPercentage);
                    preysPopulation.Add(preysPercentage);
                    game.UpdatePopulation();
                }
                var predatorsMean = Statistic.Mean(predatorsPopulation);
                var preysMean = Statistic.Mean(preysPopulation);
                predatorsMeans.Add(predatorsMean);
                preysMeans.Add(preysMean);

                if (i >= 0 && i < 5)
                {
                    this.chart_prey.Series[0].Points.AddXY(conf[i, 0], preysMean);
                    this.chart_predator.Series[0].Points.AddXY(conf[i, 0], predatorsMean);
                }
                else if (i >= 5 && i < 10)
                {
                    this.chart_prey.Series[1].Points.AddXY(conf[i, 1], preysMean);
                    this.chart_predator.Series[1].Points.AddXY(conf[i, 1], predatorsMean);
                }
                else if (i >= 10 && i < 15)
                {
                    this.chart_prey.Series[2].Points.AddXY(conf[i, 2], preysMean);
                    this.chart_predator.Series[2].Points.AddXY(conf[i, 2], predatorsMean);
                }
                else if (i >= 15 && i < 20)
                {
                    this.chart_prey.Series[3].Points.AddXY(conf[i, 3], preysMean);
                    this.chart_predator.Series[3].Points.AddXY(conf[i, 3], predatorsMean);
                }
                chart_predator.Update();
                chart_prey.Update();
            }
        }

        private void RunRVGeneration()
        {
            for (int i = 0; i < 5; i++)
            {
                this.chart_prey.Series[i].Points.Clear();
                this.chart_predator.Series[i].Points.Clear();
            }
            var index = comboBox_ntype.SelectedIndex < 0 ? 0 : comboBox_ntype.SelectedIndex;
            var rule = rules[index];
            var conf = InitialPopulation.GetTestParameters;

            for (int i = 20; i < InitialPopulation.GetParametersCount; i++)
            {
                Configuration configuration = new Configuration(
                    conf[i, 0],
                    conf[i, 1],
                    conf[i, 2],
                    conf[i, 3],
                    (int)conf[i, 4],
                    rule
                    );
                game = new Game(configuration);
                predatorsPopulation.Clear();
                preysPopulation.Clear();
                for (int s = 0; s < steps; s++)
                {
                    var predatorsPercentage = (double)game.GetPredators() / (double)game.GetPopulationSize();
                    var preysPercentage = (double)game.GetPreys() / (double)game.GetPopulationSize();
                    predatorsPopulation.Add(predatorsPercentage);
                    preysPopulation.Add(preysPercentage);
                    game.UpdatePopulation();
                }
                var predatorsMean = Statistic.Mean(predatorsPopulation);
                var preysMean = Statistic.Mean(preysPopulation);
                predatorsMeans.Add(predatorsMean);
                preysMeans.Add(preysMean);

                this.chart_prey.Series[4].Points.AddXY(conf[i, 4], preysMean);
                this.chart_predator.Series[4].Points.AddXY(conf[i, 4], predatorsMean);
                
                chart_predator.Update();
                chart_prey.Update();
            }
        }
    }
}
