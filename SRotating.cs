using System;

namespace CoDoR
{
    class SRotating : AbstractCalc
    {
        double SpeedOfStream; //Скорость разливки
        double RadiusOfCore; //Радиус осесимметричного ядра
        double AngularVelocity; //Угловая скорость ролика
        double FiniteSpeedOfStream; //Конечная скорость разливки
        double Step; //Шаг итерации
        double[] Radius; //Массив для хранения радиусов ядра
        double[] W; //Массив для хранения результатов расчета

        public SRotating(double[] inst)
        {
            CoefOfExp = inst[0];
            WidthOfSlab = inst[1];
            LenghtOfRoller = inst[2];
            InnerRadius = inst[3];
            OuterRadius = inst[4];
            SpeedOfStream = inst[5];
            FiniteSpeedOfStream = inst[6];
            Step = inst[7];
            Radius = new double[Convert.ToInt32((FiniteSpeedOfStream - SpeedOfStream) / Step) + 2];
            W = new double[Radius.Length];
            Calculaion();
        }

        public override void Calculaion()
        {
            int i;

            for (i = 0; SpeedOfStream < (FiniteSpeedOfStream + Step); SpeedOfStream += Step, i++) {

                if (SpeedOfStream > FiniteSpeedOfStream)
                {
                    SpeedOfStream = FiniteSpeedOfStream;
                }
                Distance = (LenghtOfRoller - WidthOfSlab) / 2;

                AngularVelocity = ((SpeedOfStream / OuterRadius) / 60) * 1000;

                if (InnerRadius == 0.0)
                {
                    switch (OuterRadius)
                    {
                        case 70.0:
                            RadiusOfCore = 31.2 * AngularVelocity + 47.75;
                            CoefOfFourierQ1 = 70.5 - 20.4 * SpeedOfStream;
                            break;

                        case 90:
                            RadiusOfCore = 40.5 * AngularVelocity + 61.2;
                            CoefOfFourierQ1 = 70.5 - 20.4 * SpeedOfStream;
                            break;

                        case 107.5:
                            RadiusOfCore = 52.3 * AngularVelocity + 73.4;
                            CoefOfFourierQ1 = 82.4 - 32.3 * SpeedOfStream;
                            break;

                        case 120.5:
                            RadiusOfCore = 90.4 * AngularVelocity + 86.25;
                            CoefOfFourierQ1 = 82.4 - 32.3 * SpeedOfStream;
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
                            }
                            break;

                        case 45.0:
                            if (OuterRadius == 165.0)
                            {
                                RadiusOfCore = 198.84 * AngularVelocity + 99.86;
                                CoefOfFourierQ1 = 91.3 - 37.5 * SpeedOfStream;
                            }
                            break;

                        case 75.0:
                            if (OuterRadius == 240.0)
                            {
                                RadiusOfCore = 399.47 * AngularVelocity + 146.97;
                                CoefOfFourierQ1 = 140.4 - 68.0 * SpeedOfStream;
                            }
                            else if (OuterRadius == 300.0)
                            {
                                RadiusOfCore = 489.75 * AngularVelocity + 208.43;
                                CoefOfFourierQ1 = 140.4 - 68.0 * SpeedOfStream;
                            }
                            break;

                        default:
                            break;
                    }
                }

                Radius[i] = RadiusOfCore;
                W[i] = 100 * (CoefOfExp * WidthOfSlab * (4.0 * Distance + WidthOfSlab) / 8.0) *
                    (OuterRadius * (OuterRadius * OuterRadius - RadiusOfCore * RadiusOfCore)) /
                    (OuterRadius * OuterRadius * OuterRadius * OuterRadius - InnerRadius * InnerRadius * InnerRadius * InnerRadius);
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
            string result = "Радиус      Деформация\n" + "осесим.\t\tпо оси Z\n" + "ядра\n";
            for (int i = 0; i < Radius.Length; i++)
            {
                if (Radius[i] == 0)
                {
                    return result;
                }
                result += Radius[i].ToString("##.##") + "\t\t" + W[i].ToString("##.###") + '\n';
            }
            return result;
        }
    }
}
