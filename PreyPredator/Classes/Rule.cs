using System;
using System.Collections.Generic;
using System.Linq;

namespace PreyPredatorModel.Classes
{
    //simple model

    public class Rule_deprecated
    {
        public void UpdatePopulation(Creature[,] array, Creature[,] buffer, Configuration conf)
        {
            int width = array.GetUpperBound(0) + 1;
            int height = array.Length / width;
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    var creature = buffer[i, k];

                    if(creature.Type == CreatureType.Predator)
                    {
                        var r = rand.NextDouble();
                        if( r < conf.PredatorDealthRate)
                        {
                            creature.Type = CreatureType.Nothing;
                        }
                    }
                    else if(creature.Type == CreatureType.Prey)
                    {
                        var neighbors = GetNeighborhood(array, i, k, width, height);
                        int nPred = neighbors.Where(x => x.Type == CreatureType.Predator).Count();
                        var r= rand.NextDouble();

                        if (r >= Math.Pow(1 - conf.PreyDealthRate, nPred)) 
                        { 
                            var rh = rand.NextDouble();
                            if (rh < conf.PredatorBirthRate)//hunt is succesfull and cell became predator
                                creature.Type = CreatureType.Predator;
                        }
                        
                    }
                    else if (creature.Type == CreatureType.Nothing)
                    {
                        var neighbors = GetNeighborhood(array, i, k, width, height);
                        int nPred = neighbors.Where(x => x.Type == CreatureType.Predator).Count();
                        int nPrey = neighbors.Where(x => x.Type == CreatureType.Prey).Count();

                        if(nPrey > 0 && nPred == 0)
                        {
                            var r = rand.NextDouble();
                            if( r < Math.Pow(1 - conf.PreyBirthRate, nPrey))//cell become prey by breeding
                                creature.Type = CreatureType.Prey;
                        }
                    }
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    array[i, k] = buffer[i, k];
                }
            }
        }

         protected virtual List<Creature> GetNeighborhood(
             Creature[,] array, 
             int i, 
             int k, 
             int width, 
             int height
             )
         {
            List<Creature> neighbors = new List<Creature>();

            if (i == 0 && k == 0)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
            }
            else if (i == width - 1 && k == 0)
            {  
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
            }
            else if (i == 0 && k == height - 1)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i == width - 1 && k == height - 1)
            {
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i != 0 && i != width - 1 && k == 0)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
            }
            else if (i != 0 && i != width - 1 && k == height - 1)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i == 0 && k != height - 1 && k != 0)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i == width - 1 && k != height - 1 && k != 0)
            {
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            return neighbors; 
         }
    }

    //advanced model

    public class Rule
    {
        private double Overpopulation(int numofPreys, double preyDealthRate, int radius)
        {
            return numofPreys * (1 - Math.Cos(Math.PI * 0.5 * preyDealthRate)) / Math.Pow(2 * radius + 1, 2);
        }
        protected IEnumerable<Creature> NorthVisibility(Creature[,] array, int x, int y, int width, int height, int radius)
        {
            List<Creature> neighbors = new List<Creature>();
            for (int i = 1; i <= radius; i++)
            {
                for (int j = -i; j <= i; j++)
                {
                    if (y + i < height && x + j >= 0 && x + j < width)
                    {
                        Creature creature = array[x + j, y + i];
                        neighbors.Add(creature);
                    }
                }
            }
            return neighbors;
        }

        protected IEnumerable<Creature> EastVisibility(Creature[,] array, int x, int y, int width, int height, int radius)
        {
            List<Creature> neighbors = new List<Creature>();
            for (int i = 1; i <= radius; i++)
            {
                for (int j = -i; j <= i; j++)
                {
                    if (x + i < width && y + j >= 0 && y + j < height)
                    {
                        Creature creature = array[x + i, y + j];
                        neighbors.Add(creature);
                    }
                }
            }
            return neighbors;
        }

        protected IEnumerable<Creature> SouthVisibility(Creature[,] array, int x, int y, int width, int height, int radius)
        {
            List<Creature> neighbors = new List<Creature>();
            for (int i = 1; i <= radius; i++)
            {
                for (int j = -i; j <= i; j++)
                {
                    if (y - i >= 0 && x + j >= 0 && x + j < width)
                    {
                        Creature creature = array[x + j, y - i];
                        neighbors.Add(creature);
                    }
                }
            }
            return neighbors;
        }

        protected IEnumerable<Creature> WestVisibility(Creature[,] array, int x, int y, int width, int height, int radius)
        {
            List<Creature> neighbors = new List<Creature>();
            for (int i = 1; i <= radius; i++)
            {
                for (int j = -i; j <= i; j++)
                {
                    if (x - i >= 0 && y + j >= 0 && y + j < height)
                    {
                        Creature creature = array[x - i, y + j];
                        neighbors.Add(creature);
                    }
                }
            }
            return neighbors;
        }
  
        protected virtual List<Creature> GetNeighborhood(Creature[,] array, int i, int k, int width, int height)
        {
            List<Creature> neighbors = new List<Creature>();

            if (i == 0 && k == 0)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
            }
            else if (i == width - 1 && k == 0)
            {
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
            }
            else if (i == 0 && k == height - 1)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i == width - 1 && k == height - 1)
            {
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i != 0 && i != width - 1 && k == 0)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
            }
            else if (i != 0 && i != width - 1 && k == height - 1)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i == 0 && k != height - 1 && k != 0)
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i == width - 1 && k != height - 1 && k != 0)
            {
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else
            {
                neighbors.Add(array[i + 1, k]);
                neighbors.Add(array[i, k + 1]);
                neighbors.Add(array[i - 1, k]);
                neighbors.Add(array[i, k - 1]);
            }
            return neighbors;
        }

        void FeedingPhase(Creature[,] array, Creature[,] buffer, Configuration conf, int width, int height)
        {
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    var creature = buffer[i, k];

                    if (creature.Type == CreatureType.Prey)
                    {
                        var neighbors = GetNeighborhood(array, i, k, width, height);
                        int nPred = neighbors.Where(x => x.Type == CreatureType.Predator).Count();

                        var north = NorthVisibility(array, i, k, width, height, conf.VisibilityRadius);
                        var west = WestVisibility(array, i, k, width, height, conf.VisibilityRadius);
                        var south = SouthVisibility(array, i, k, width, height, conf.VisibilityRadius);
                        var east = EastVisibility(array, i, k, width, height, conf.VisibilityRadius);

                        var neighborsOfRadiusR = north.Union(east.Union(west.Union(north)));
                        var np = neighborsOfRadiusR.Where(p => p.Type == CreatureType.Prey).Count();
                        var nh = neighborsOfRadiusR.Where(p => p.Type == CreatureType.Predator).Count();

                        var r = rand.NextDouble();

                        if( nh == 0 || r < Math.Pow(1 - conf.PreyDealthRate, nPred))
                        {
                            var prob = Overpopulation(np, conf.PreyDealthRate, conf.VisibilityRadius);
                            if(r < prob)
                                creature.Killed = true;
                            
                        }
                        else  if (r >= Math.Pow(1 - conf.PreyDealthRate, nPred))
                             creature.Killed = true;
                    }
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    array[i, k] = buffer[i, k];
                }
            }
        }
        void ReproductionPhase(Creature[,] array, Creature[,] buffer, Configuration conf, int width, int height)
        {
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    var creature = buffer[i, k];

                    if (creature.Type == CreatureType.Predator)
                    {
                        var r = rand.NextDouble();
                        if (r < conf.PredatorDealthRate)
                        {
                            creature.Type = CreatureType.Nothing;
                            creature.Killed = false;
                        }

                    }
                    else if (creature.Type == CreatureType.Nothing)
                    {
                        var neighbors = GetNeighborhood(array, i, k, width, height);
                        int nPred = neighbors.Where(x => x.Type == CreatureType.Predator).Count();
                        int nPrey = neighbors.Where(x => x.Type == CreatureType.Prey).Count();

                        if (nPrey > 0 && nPred == 0)
                        {
                            var r = rand.NextDouble();
                            if (r < Math.Pow(1 - conf.PreyBirthRate, nPrey))//cell become prey by breeding
                                creature.Type = CreatureType.Prey;
                        }
                    }
                    else if (creature.Type == CreatureType.Prey && creature.Killed)
                    {
                        var neighbors = GetNeighborhood(array, i, k, width, height);
                        int nFedPred = neighbors.Where(x => x.Type == CreatureType.Predator).Count();
                        var r = rand.NextDouble();
                        if (r < Math.Pow(1 - conf.PredatorBirthRate, nFedPred))
                        {
                            creature.Type = CreatureType.Nothing;
                            creature.Killed = false;
                        }
                        else
                        {
                            creature.Type = CreatureType.Predator;
                            creature.Killed = false;
                        }
                    }
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    array[i, k] = buffer[i, k];
                }
            }
        }

        void MovementPhase(Creature[,] array, Creature[,] buffer, Configuration conf, int width, int height)
        {
            List<Cell> competitionCells = new List<Cell>();
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    var creature = buffer[i, k];

                    var north = NorthVisibility(array, i, k, width, height, conf.VisibilityRadius);
                    var west = WestVisibility(array, i, k, width, height, conf.VisibilityRadius);
                    var south = SouthVisibility(array, i, k, width, height, conf.VisibilityRadius);
                    var east = EastVisibility(array, i, k, width, height, conf.VisibilityRadius);
                   
                    List<IEnumerable<Creature>> neighbors = new List<IEnumerable<Creature>>() { north, west, south, east };
                    
                    if (creature.Type == CreatureType.Prey &&
                    neighbors.Any(x => x.Where(y => y.Type == CreatureType.Predator).Count() > 0))
                    {
                        var favourite = new List<Creature>();
                        int min = Int32.MaxValue;
                        neighbors.ForEach(x =>
                        {
                            if (x.Where(y => y.Type == CreatureType.Predator).Count() < min)
                            {
                                min = x.Where(y => y.Type == CreatureType.Predator).Count();
                                favourite = x.Where(y => y.Type == CreatureType.Nothing).ToList();
                            }
                        });//chose favourite area where to move
                        if (favourite.Any())
                        {
                            var r = rand.Next(favourite.Count());
                            var cellToMove = favourite[r]; // cell with which current want to move
                            var cell = competitionCells.Find(c => c.x == cellToMove.X && c.y == cellToMove.Y);
                            if (cell != null)
                                cell.creatures.Add(creature);
                            else
                            {
                                Cell newCell = new Cell { x = cellToMove.X, y = cellToMove.Y };
                                newCell.creatures.Add(creature);
                                competitionCells.Add(newCell);
                            }
                        }
                    }
                    else if(creature.Type == CreatureType.Predator)
                    {
                        var favourite = new List<Creature>();
                        if (neighbors.Any(x => x.Where(y => y.Type == CreatureType.Prey).Count() > 0)){
                            //there are preys in one of the areas and predator will be moving to area where there are most of them
                            
                            int max = Int32.MinValue;
                            neighbors.ForEach(x =>
                            {
                                if (x.Where(y => y.Type == CreatureType.Prey).Count() > max)
                                {
                                    max = x.Where(y => y.Type == CreatureType.Prey).Count();
                                    favourite = x.Where(y => y.Type == CreatureType.Nothing).ToList();
                                }
                            });//chose favourite area where to move
                        }
                        else
                        {
                            var r = rand.Next(4);
                            favourite = neighbors[r].Where(y => y.Type == CreatureType.Nothing).ToList();
                        }
                        if (favourite.Any())
                        {
                            var r = rand.Next(favourite.Count());
                            var cellToMove = favourite[r]; // cell with which current want to move
                            var cell = competitionCells.Find(c => c.x == cellToMove.X && c.y == cellToMove.Y);
                            if (cell != null)
                                cell.creatures.Add(creature);
                            else
                            {
                                Cell newCell = new Cell { x = cellToMove.X, y = cellToMove.Y };
                                newCell.creatures.Add(creature);
                                competitionCells.Add(newCell);
                            }
                        }
                    }
                }

            }

            foreach(var cell in competitionCells)
            {
                var r = rand.Next(cell.creatures.Count());
                var creature = cell.creatures[r];
                buffer[cell.x, cell.y].Type = creature.Type;
                buffer[creature.X, creature.Y].Type = CreatureType.Nothing;
            }
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    array[i, k] = buffer[i, k];
                }
            }

        }

        public void UpdatePopulation(Creature[,] array, Creature[,] buffer, Configuration conf)
        {
            int width = array.GetUpperBound(0) + 1;
            int height = array.Length / width;
            MovementPhase(array, buffer, conf, width, height);
            FeedingPhase(array, buffer, conf, width, height);
            ReproductionPhase(array, buffer, conf, width, height);
        }
    }

    //neighborhood extention
    public class MooreRule : Rule
    {
        protected override List<Creature> GetNeighborhood(
            Creature[,] array,
            int i,
            int k,
            int width,
            int height
            )
        {
            var neighbors = base.GetNeighborhood(array, i, k, width, height);
            if (i == 0 && k == 0)
            {
                neighbors.Add(array[i + 1, k + 1]);
            }
            else if (i == width - 1 && k == 0)
            {
                neighbors.Add(array[i - 1, k + 1]);
            }
            else if (i == 0 && k == height - 1)
            {
                neighbors.Add(array[i + 1, k - 1]);
            }
            else if (i == width - 1 && k == height - 1)
            {
                neighbors.Add(array[i - 1, k - 1]);
            }
            else if (i != 0 && i != width - 1 && k == 0)
            {
                neighbors.Add(array[i + 1, k + 1]);
                neighbors.Add(array[i - 1, k + 1]);
            }
            else if (i != 0 && i != width - 1 && k == height - 1)
            {
                neighbors.Add(array[i + 1, k - 1]);
                neighbors.Add(array[i - 1, k - 1]);
            }
            else if (i == 0 && k != height - 1 && k != 0)
            {
                neighbors.Add(array[i + 1, k + 1]);
                neighbors.Add(array[i + 1, k - 1]);
            }
            else if (i == width - 1 && k != height - 1 && k != 0)
            {
                neighbors.Add(array[i - 1, k + 1]);
                neighbors.Add(array[i - 1, k - 1]);
            }
            else
            {
                neighbors.Add(array[i + 1, k + 1]);
                neighbors.Add(array[i - 1, k + 1]);
                neighbors.Add(array[i - 1, k - 1]);
                neighbors.Add(array[i - 1, k - 1]);
            }

            return neighbors;
        }
    }

    public class ExtendedNeumannRule : MooreRule
    {
        protected override List<Creature> GetNeighborhood(
            Creature[,] array,
            int i,
            int k,
            int width,
            int height
            )
        {
            var neighbors = base.GetNeighborhood(array, i, k, width, height);

            if (i <= 1 && k <= 1)
            {
                neighbors.Add(array[i + 2, k]);
                neighbors.Add(array[i, k + 2]);
            }
            else if (i >= width - 2 && k <= 1)
            {
                neighbors.Add(array[i - 2, k]);
                neighbors.Add(array[i, k + 2]);
            }
            else if (i <= 1 && k >= height - 2)
            {
                neighbors.Add(array[i + 2, k]);
                neighbors.Add(array[i, k - 1]);
            }
            else if (i >= width - 2 && k >= height - 2)
            {
                neighbors.Add(array[i - 2, k]);
                neighbors.Add(array[i, k - 2]);
            }
            else if (i > 1 && i < width - 2 && k <= 1)
            {
                neighbors.Add(array[i + 2, k]);
                neighbors.Add(array[i - 2, k]);
                neighbors.Add(array[i, k + 2]);
            }
            else if (i > 1 && i < width - 2 && k >= height - 2)
            {
                neighbors.Add(array[i + 2, k]);
                neighbors.Add(array[i - 2, k]);
                neighbors.Add(array[i, k - 2]);
            }
            else if (i <= 1 && k < height - 2 && k > 1)
            {
                neighbors.Add(array[i + 2, k]);
                neighbors.Add(array[i, k - 2]);
                neighbors.Add(array[i, k + 2]);
            }
            else if (i >= width - 2 && k < height - 2 && k > 1)
            {
                neighbors.Add(array[i - 2, k]);
                neighbors.Add(array[i, k - 2]);
                neighbors.Add(array[i, k + 2]);
            }
            else
            {
                neighbors.Add(array[i + 2, k]);
                neighbors.Add(array[i - 2, k]);
                neighbors.Add(array[i, k - 2]);
                neighbors.Add(array[i, k + 2]);
            }
            return neighbors;
        }
    }

}
