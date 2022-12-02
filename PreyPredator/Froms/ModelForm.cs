using PreyPredatorModel.Classes;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PreyPredatorModel.Froms
{
    public partial class ModelForm : Form
    {
        private Bitmap bitmap;
        private Game game;
        ChartForm chart;
        public ModelForm(ChartForm chartForm)
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            game = chartForm.Game;
            chart = chartForm;
            chart.Population = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = game?.DrawMap(bitmap);
            game?.UpdatePopulation();
            label1.Text = game?.ShowPopulationStatistics();
            label1.Refresh();
            UpdateChartForm();
        }

        void UpdateChartForm()
        {
            var predatorsPercentage = (double)game.GetPredators() / (double)game.GetPopulationSize();
            var preysPercentage = (double)game.GetPreys() / (double)game.GetPopulationSize();
            chart.Predators.Add(predatorsPercentage);
            chart.Preys.Add(preysPercentage);
            chart.Population++;
            if(chart.Population == 500)
            {
                this.Close();
            }
        }
    }
}
