using System;

namespace CoDoR
{
    class SNonRotating : AbstractCalc
    {
        double FiniteWidthOfSlab; //Конечная ширина ролика
        double Step; //Шаг итерации
        double[] Width; //Массив для хранения ширины ролика
        double[] W; //Массив для хранения результатов расчета

        public SNonRotating(double[] inst)
        {
            CoefOfExp = inst[0];
            WidthOfSlab = inst[1];
            FiniteWidthOfSlab = inst[2];
            LenghtOfRoller = inst[3];
            InnerRadius = inst[4];
            OuterRadius = inst[5];
            CoefOfFourierQ1 = inst[6];
            CoefOfFourierQ2 = inst[7];
            Step = inst[8];
            Width = new double [Convert.ToInt32((FiniteWidthOfSlab - WidthOfSlab)/Step) + 2];
            W = new double[Width.Length];
            Calculaion();
        }

        public override void Calculaion()
        {
            int i;
            for ( i = 0; WidthOfSlab < (FiniteWidthOfSlab + Step); WidthOfSlab += Step, i++) {
                if(WidthOfSlab > FiniteWidthOfSlab)
                {
                    WidthOfSlab = FiniteWidthOfSlab;
                }
                Distance = (LenghtOfRoller - WidthOfSlab) / 2.0;
                Width[i] = WidthOfSlab;
                W[i] = 100 * CoefOfExp * WidthOfSlab * (4.0 * Distance + WidthOfSlab) * OuterRadius / (8.0 * (InnerRadius * InnerRadius + OuterRadius * OuterRadius));
            }
        }

        public override string ShowW()
        {
            return "";
        }

        public override string ShowV()
        {
            return "";
        }

        public override string Show()
        {
            string result = "Ширина    Деформация\n" + "ролика\t\tпо оси Z\n";
            for(int i = 0; i < Width.Length; i++)
            {   
                if(Width[i] == 0)
                {
                    return result;
                }
                result += Width[i].ToString() + "\t\t" + W[i].ToString("##.###") + '\n';
            }
            return result;
        }


    }
}
