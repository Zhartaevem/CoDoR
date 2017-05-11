namespace CoDoR
{
    class NonRotating : AbstractCalc
    {
        public NonRotating(double[] inst)
        {
            CoefOfExp = inst[0];
            WidthOfSlab = inst[1];
            LenghtOfRoller = inst[2];
            InnerRadius = inst[3];
            OuterRadius = inst[4];
            CoefOfFourierQ1 = inst[5];
            CoefOfFourierQ2 = inst[6];
            Calculaion();
        }

        public override void Calculaion()
        {
            double v; // переменная для промежуточного расчета
            Distance = (LenghtOfRoller - WidthOfSlab) / 2.0;
            v = CoefOfExp * WidthOfSlab * (4.0 * Distance + WidthOfSlab) * OuterRadius / (8.0 * (InnerRadius * InnerRadius + OuterRadius * OuterRadius));
            ConstituentW = CoefOfFourierQ1 * v;
            ConstituentV = CoefOfFourierQ2 * v;
        }

        public override string ShowW()
        {           
            return ConstituentW.ToString("#.###");
        }

        public override string ShowV()
        {
            return ConstituentV.ToString("#.###");
        }

        public override string Show()
        {
            return "Расстояние от опоры до сляба\n" + " " + Distance.ToString("####.") + " мм";
        }


    }
}
