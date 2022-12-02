namespace PreyPredatorModel.Classes
{
    public class Configuration
    {
        private readonly double preyDealthRate;
        private readonly double preyBirthRate;
        private readonly double predatorDealthRate;
        private readonly double predatorBirthRate;
        private readonly int visibilityRadius;
        private readonly Rule rule;

        public Configuration(double dp, 
            double bp, 
            double dh, 
            double bh,
            int vr,
            Rule ruleType)
        {
            preyDealthRate = dp;
            preyBirthRate = bp;
            predatorDealthRate = dh;
            predatorBirthRate = bh;
            visibilityRadius = vr;
            this.rule = ruleType;
        }
        public double PreyDealthRate => preyDealthRate;
        public double PreyBirthRate => preyBirthRate;   
        public double PredatorDealthRate => predatorDealthRate;
        public double PredatorBirthRate => predatorBirthRate;
        public int VisibilityRadius => visibilityRadius;
        public Rule Rule => rule;
            
    }
}
