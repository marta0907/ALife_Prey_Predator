using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PreyPredatorModel.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreyPredatorModel.Froms
{
    public partial class ChartForm : Form
    {
        private Game game;

        private int i;

        private int populationSize = 100;

        private ModelForm modelForm;

        private List<double> _preysPopulation;

        private List<double> _predatorsPopulation;

        private List<double> _preysMeans;

        private List<double> _predatorsMeans;

        public List<double> Preys => _preysPopulation;
        public List<double> Predators => _predatorsPopulation;
        public Game Game => game;

        PdfDocument pdfDocument;

        Guid guid;

        string file;
        public int Population
        {
            get { return i; }
            set
            {
                i = value;
                if (i % 25 == 0)
                {
                    DrawPredators();
                    DrawPreys();
                    DrawPhaseDiagram();
                }
                if(i % 500 == 0 && i != 0)
                {
                    SaveTest();
                }
            }
        }

        public ChartForm()
        {
            InitializeComponent();
            _preysPopulation = new List<double>();
            _predatorsPopulation = new List<double>();
            _preysMeans = new List<double>();
            _predatorsMeans = new List<double>();
            guid = Guid.NewGuid();
            file = $"{guid}.pdf";
            pdfDocument = new PdfDocument();
        }

        void DrawPredators()
        {
            this.chart1.Series[1].Points.Clear();
            for (int i = 0; i < _predatorsPopulation.Count(); i++)
            {
                this.chart1.Series[1].Points.AddXY(i, _predatorsPopulation[i]);
            }
        }

        void DrawPreys()
        {
            this.chart1.Series[0].Points.Clear();
            for (int i = 0; i < _preysPopulation.Count(); i++) {
                this.chart1.Series[0].Points.AddXY(i, _preysPopulation[i]);
            }
        }


        void DrawPhaseDiagram()
        {
            this.phasechart.Series[0].Points.Clear();
            int length = _preysPopulation.Count < _predatorsPopulation.Count? _preysPopulation.Count : _predatorsPopulation.Count ;
            for (int i = 0; i < length; i++)
            {
                this.phasechart.Series[0].Points.AddXY( _preysPopulation[i], _predatorsPopulation[i]);
            }
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            Configuration configuration = TryParse();
            game = new Game(configuration, populationSize);
            _preysPopulation.Clear();
            _predatorsPopulation.Clear();
            ShowModelForm();
        }

        Dictionary<int, Rule> rules = new Dictionary<int, Rule>()
        {
            { 0, new Rule() },
            { 1, new MooreRule() },
            { 2, new ExtendedNeumannRule() }
        };

        Dictionary<int, string> neighborhoodtype = new Dictionary<int, string>()
        {
            { 0,"von Neumann" },
            { 1, "Moore" },
            { 2, "extended von Neumann" }
        };
        private Configuration TryParse()
        {
            double preyD, preyB, predatorD, predatorB;
            int visRadius;
            Double.TryParse(textBox_pd.Text, out preyD);
            Double.TryParse(textBox_pb.Text, out preyB);
            Double.TryParse(textBox_hd.Text, out predatorD);
            Double.TryParse(textBox_hb.Text, out predatorB);
            Int32.TryParse(textBox_vr.Text, out visRadius);
            var index = comboBox_ntype.SelectedIndex < 0 ? 0 : comboBox_ntype.SelectedIndex;
            var rule = rules[index];
            return new Configuration(preyD, preyB, predatorD, predatorB, visRadius, rule);
        }

        private void ShowModelForm() 
        {
            if (modelForm != null && modelForm.Visible)
            {
                modelForm.Close();
            }
            modelForm = new ModelForm(this);
            modelForm.Show();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            textBox_hb.Text = "0,65";
            textBox_hd.Text = "0,35";
            textBox_pb.Text = "0,35";
            textBox_pd.Text = "0,65";
            textBox_vr.Text = "1";
        }

        private void SaveTest()
        {
            _predatorsMeans.Add(Statistic.Mean(_predatorsPopulation));
            _preysMeans.Add(Statistic.Mean(_preysPopulation));

            PdfPage page1 = pdfDocument.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page1);

            XFont font = new XFont("Arial", 12, XFontStyle.Regular, XPdfFontOptions.UnicodeDefault);

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{label_pd.Text}:\t{textBox_pd.Text}\n");
            builder.AppendLine($"{label_pb.Text}:\t{textBox_pb.Text}\n");
            builder.AppendLine($"{label_hd.Text}:\t{textBox_hd.Text}\n");
            builder.AppendLine($"{label_hb.Text}:\t{textBox_hb.Text}\n");
            builder.AppendLine($"{label_vr.Text}:\t{textBox_vr.Text}\n");
            var index = comboBox_ntype.SelectedIndex < 0 ? 0 : comboBox_ntype.SelectedIndex;
            builder.AppendLine($"neighborhood type:\t{neighborhoodtype[index]}\n\n");
            builder.AppendLine($"predators mean:\t{_predatorsMeans.Last()}\n");
            builder.AppendLine($"preys mean:\t{_preysMeans.Last()}\n");
            
            var formatter = new XTextFormatter(gfx);

            var layoutRectangle = new XRect(30, 30, page1.Width,280);

            formatter.DrawString(builder.ToString(), font, XBrushes.Black, layoutRectangle);

            using (MemoryStream ms1 = new MemoryStream())
            {
                chart1.SaveImage(ms1, System.Drawing.Imaging.ImageFormat.Png);
                XImage im = XImage.FromStream(ms1);
                gfx.DrawImage(im, 20, 280);
            }

            using (MemoryStream ms2 = new MemoryStream())
            {
                phasechart.SaveImage(ms2, System.Drawing.Imaging.ImageFormat.Png);
                XImage im = XImage.FromStream(ms2);
                gfx.DrawImage(im, 20, 550);
            }
            pdfDocument.Save(file);
            Process.Start(file);
        }
        private void SaveReport()
        {
            PdfPage page1 = pdfDocument.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page1);

            XFont font = new XFont("Arial", 14, XFontStyle.Bold, XPdfFontOptions.UnicodeDefault);

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Preys:\n\n");

            var mean = Statistic.Mean(_preysMeans);
            builder.AppendLine($"Mean: {mean}\n");

            var cv = Statistic.CV(_preysMeans);
            builder.AppendLine($"Valve Coefficient: {cv}\n");

            var sd = Statistic.StandartDerivation(_preysMeans);
            builder.AppendLine($"Standard Deviation: {sd}\n\n");

            builder.AppendLine("Predators:\n\n");

            mean = Statistic.Mean(_predatorsMeans);
            builder.AppendLine($"Mean: {mean}\n");

            cv = Statistic.CV(_predatorsMeans);
            builder.AppendLine($"Valve Coefficient: {cv}\n");

            sd = Statistic.StandartDerivation(_predatorsMeans);
            builder.AppendLine($"Standard Deviation: {sd}\n\n");

            var formatter = new XTextFormatter(gfx);

            var layoutRectangle = new XRect(30, 30, page1.Width, page1.Height);

            formatter.DrawString(builder.ToString(), font, XBrushes.Black, layoutRectangle);
           
            pdfDocument.Save(file);
            Process.Start(file);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveReport();
        }
    }
}
