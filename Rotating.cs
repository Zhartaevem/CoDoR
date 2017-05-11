using System;
using System.Globalization;

namespace CoDoR
{
    class Rotating : AbstractCalc
    {
        double SpeedOfStream; //Скорость разливки
        double RadiusOfCore; //Радиус осесимметричного ядра
        double AngularVelocity; //Угловая скорость ролика

        public Rotating(double [] inst)
        {
                CoefOfExp = inst[0];
                WidthOfSlab = inst[1];
                LenghtOfRoller = inst[2];
                InnerRadius = inst[3];
                OuterRadius = inst[4];
                SpeedOfStream = inst[5];
                Calculaion();
        }

        public override void Calculaion()
        {
            double v; // переменная для промежуточного расчета
            Distance = (LenghtOfRoller - WidthOfSlab) / 2;
            AngularVelocity = ((SpeedOfStream / OuterRadius) / 60) * 1000;


            if (InnerRadius == 0.0)
            {
                switch (OuterRadius)
                {
                    case 70.0:
                        RadiusOfCore = 31.2 * AngularVelocity + 47.75;
                        CoefOfFourierQ1 = 70.5 - 20.4 * SpeedOfStream;
                        CoefOfFourierQ2 = 36.5 - 17.8 * SpeedOfStream;
                        break;

                    case 90:
                        RadiusOfCore = 40.5 * AngularVelocity + 61.2;
                        CoefOfFourierQ1 = 70.5 - 20.4 * SpeedOfStream;
                        CoefOfFourierQ2 = 36.5 - 17.8 * SpeedOfStream;
                        break;

                    case 107.5:
                        RadiusOfCore = 52.3 * AngularVelocity + 73.4;
                        CoefOfFourierQ1 = 82.4 - 32.3 * SpeedOfStream;
                        CoefOfFourierQ2 = 47.5 - 17.3 * SpeedOfStream;
                        break;

                    case 120.5:
                        RadiusOfCore = 90.4 * AngularVelocity + 86.25;
                        CoefOfFourierQ1 = 82.4 - 32.3 * SpeedOfStream;
                        CoefOfFourierQ2 = 47.5 - 17.3 * SpeedOfStream;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (InnerRadius)
                {
                    case 37.5:
                        if (OuterRadius == 135.0)
                        {
                            RadiusOfCore = 112.07 * AngularVelocity + 83.54;
                            CoefOfFourierQ1 = 91.3 - 37.5 * SpeedOfStream;
                            CoefOfFourierQ2 = 52.6 - 21.6 * SpeedOfStream;
                        }
                        break;

                    case 45.0:
                        if (OuterRadius == 165.0)
                        {
                            RadiusOfCore = 198.84 * AngularVelocity + 99.86;
                            CoefOfFourierQ1 = 91.3 - 37.5 * SpeedOfStream;
                            CoefOfFourierQ2 = 52.6 - 21.6 * SpeedOfStream;
                        }
                        break;

                    case 75.0:
                        if (OuterRadius == 240.0)
                        {
                            RadiusOfCore = 399.47 * AngularVelocity + 146.97;
                            CoefOfFourierQ1 = 140.4 - 68.0 * SpeedOfStream;
                            CoefOfFourierQ2 = 83.0 - 39.2 * SpeedOfStream;
                        }
                        else if (OuterRadius == 300.0)
                        {
                            RadiusOfCore = 489.75 * AngularVelocity + 208.43;
                            CoefOfFourierQ1 = 140.4 - 68.0 * SpeedOfStream;
                            CoefOfFourierQ2 = 83.0 - 39.2 * SpeedOfStream;
                        }
                        break;

                    default:
                        break;
                }
            }

            v = (CoefOfExp * WidthOfSlab * (4.0 * Distance + WidthOfSlab) / 8.0) * 
                (OuterRadius * (OuterRadius * OuterRadius - RadiusOfCore * RadiusOfCore)) / 
                (OuterRadius * OuterRadius * OuterRadius * OuterRadius - InnerRadius * InnerRadius * InnerRadius * InnerRadius);
            ConstituentW = CoefOfFourierQ1 * v;
            ConstituentV = CoefOfFourierQ2 * v;
        }

        public override string ShowW()
        {
            return ConstituentW.ToString("##.###", CultureInfo.CurrentCulture);
        }

        public override string ShowV()
        {
            return ConstituentV.ToString("##.###", CultureInfo.CurrentCulture);
        }

        public override string Show()
        {
            return "Расстояние от опоры до сляба" + "\n" + " " + Convert.ToString(Distance) + " мм\n\n" + 
                "Угловая скорость ролика " + AngularVelocity.ToString("#.#####", CultureInfo.CurrentCulture) + " рад/сек\n\n" + 
                "Радиус осесимметричного ядра " + RadiusOfCore.ToString("##.##", CultureInfo.CurrentCulture) + " мм\n\n" + 
                "Коэффициенты Фурье " + CoefOfFourierQ1.ToString("##.##", CultureInfo.CurrentCulture) + " и " + CoefOfFourierQ2.ToString("##.##");
        }
    }
}
