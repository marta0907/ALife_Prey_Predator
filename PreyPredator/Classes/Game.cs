using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PreyPredatorModel.Classes
{
    public class Game
    {
        private readonly Configuration configuration;
        private Creature[,] population;
        private Creature[,] buffer;
        private int populationSize;
        private int cellSize = 5;
        private int iterations = 0;
        private string fileName = "initial_configuration.txt";

        private readonly Dictionary<CreatureType, Color> colorMap = new Dictionary<CreatureType, Color>()
        {
            {CreatureType.Nothing, Color.Black},
            {CreatureType.Prey, Color.Green},
            {CreatureType.Predator, Color.Red}
        };
        public Game(Configuration configuration, int populationSize)
        {
            this.configuration = configuration;
            this.populationSize = populationSize;
            buffer = new Creature[populationSize, populationSize];
            population = new Creature[populationSize, populationSize];
            InitPopulation();
        }
        public Game(Configuration configuration)
        {
            this.configuration = configuration;
            this.populationSize = 0;
            buffer = new Creature[populationSize, populationSize];
            population = new Creature[populationSize, populationSize];
            InitPopulation();
        }
        void InitRandomPopulation()
        {
            Random random = new Random();
            Save(fileName, "{\n");
            for (int i = 0; i < populationSize; i++)
            {
                Save(fileName, "{");
                for (int j = 0; j < populationSize; j++)
                {
                    string text = "";
                    population[i, j] = new Creature(CreatureType.Nothing);
                    text = "0";
                    population[i, j].X = i;
                    population[i, j].Y = j;
                    int r = random.Next(100);

                    if (r > 85)
                    {
                        population[i, j].Type = CreatureType.Prey;
                        text = "1";
                    }
                    if (r < 20)
                    {
                        population[i, j].Type = CreatureType.Predator;
                        text = "2";
                    }
                    string comma1 = j == populationSize - 1 ? "" : ",";
                    Save(fileName, $"{text}{comma1}");
                }
                string comma2 = i == populationSize - 1 ? "" : ",";
                Save(fileName, "}" + comma2 + "\n");
            }
            Save(fileName, "}");
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    buffer[i, j] = population[i, j];
                }
            }
        }

        void InitPopulation()
        {
            this.population = new Creature[InitialPopulation.GetArrayWidth, InitialPopulation.GetArrayHeight];
            this.buffer = new Creature[InitialPopulation.GetArrayWidth, InitialPopulation.GetArrayHeight];
            populationSize = InitialPopulation.GetArrayWidth < InitialPopulation.GetArrayHeight ? 
                InitialPopulation.GetArrayWidth : InitialPopulation.GetArrayHeight;

            for (int i = 0; i < InitialPopulation.GetArrayWidth; i++)
            {
                for(int j = 0; j < InitialPopulation.GetArrayHeight; j++)
                {
                    if(InitialPopulation.GetInitialPopulation[i, j] == 0)
                    {
                        population[i, j] = new Creature(CreatureType.Nothing);
                    }
                    else if (InitialPopulation.GetInitialPopulation[i, j] == 1)
                    {
                        population[i, j] = new Creature(CreatureType.Prey);
                    }
                    else if(InitialPopulation.GetInitialPopulation[i, j] == 2)
                    {
                        population[i, j] = new Creature(CreatureType.Predator);
                    }
                    population[i, j].X = i;
                    population[i, j].Y = j;
                }
            }

            for (int i = 0; i < InitialPopulation.GetArrayWidth; i++)
            {
                for (int j = 0; j < InitialPopulation.GetArrayHeight; j++)
                {
                    buffer[i, j] = population[i, j];
                }
            }

        }

        public void UpdatePopulation()
        {
            configuration.Rule.UpdatePopulation(population, buffer, configuration);
            iterations++;
        }

        public Bitmap DrawMap(Bitmap bitmap)
        {
            bitmap = new Bitmap(populationSize * cellSize, populationSize * cellSize);
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < populationSize; i++)
            {
                for (int k = 0; k < populationSize; k++)
                {
                    var type = population[i, k].Type;
                    SolidBrush brush = new SolidBrush(colorMap[type]);
                    g.FillRectangle(brush, i * cellSize, k * cellSize, cellSize, cellSize);
                }
            }
            g.Dispose();
            return bitmap;
        }

        public int GetPreys()
        {
            int preys = 0;
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < populationSize; j++)
                    if (population[i, j]?.Type == CreatureType.Prey)
                        preys++;
            }
            return preys;
        }

        public int GetPredators()
        {
            int predators = 0;
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < populationSize; j++)
                    if (population[i, j]?.Type == CreatureType.Predator)
                        predators++;
            }
            return predators;
        }

        public string ShowPopulationStatistics()
        {
            return $"Iterations: {iterations}, Preys: {GetPreys()}, Predators: {GetPredators()}";
        }

        public int GetPopulationSize()
        {
            return populationSize * populationSize;
        }

        void Save(string file, string text)
        {
            FileStream fParameter = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(text);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }

    }
}
