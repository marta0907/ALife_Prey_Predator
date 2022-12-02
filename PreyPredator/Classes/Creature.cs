using System.Collections.Generic;

namespace PreyPredatorModel.Classes
{
    public class Creature
    {
        private CreatureType type;
        private bool killed = false;
        public Creature(CreatureType type)
        {
            this.Type = type;
        }
        public CreatureType Type
        {
            get => type; 
            set => type = value;
        }

        public int X;
        public int Y;
        public bool Killed { get => killed; set => killed = value; }
    }

    public class Cell
    {
        public int x;
        public int y;
        public List<Creature> creatures = new List<Creature>();
    }

    public enum CreatureType
    {
        Nothing = 0,
        Prey = 1,
        Predator = 2
    }
}
