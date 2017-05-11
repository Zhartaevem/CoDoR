using System;
using System.Windows;


namespace CoDoR
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        AbstractCalc rot;

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {   
            bool go = true;

            while (IsNotRotating.IsChecked == true && go == true)
            {
                double[] Inst = new double[7];
                double temp;

                try
                {
                    temp = Convert.ToDouble(Coef_of_exp.GetLineText(0));

                    if (temp < 0.000002 || temp > 0.00144)
                    {
                        throw new FormatException();
                    }
                    Inst[0] = temp;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение Коэффициента линейного расширения ролика должно находиться в пределах от 0,000002 до 0,00144");
                    Coef_of_exp.Clear();
                    Coef_of_exp.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Width_of_slab.GetLineText(0));

                    if (temp > 5000 || temp < 350)
                    {
                        throw new FormatException();
                    }
                    Inst[1] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение ширины сляба должно находиться в диапазоне от 350 до 5000");
                    Width_of_slab.Clear();
                    Width_of_slab.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Lenght_of_roller.GetLineText(0));

                    if (temp > 10000 || temp < 1000)
                    {
                        throw new FormatException();
                    }
                    Inst[2] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение длины ролика должно находиться в диапазоне от 1000 до 10000");
                    Lenght_of_roller.Clear();
                    Lenght_of_roller.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Inner_radius.GetLineText(0));

                    if (temp > 75 || temp < 0)
                    {
                        throw new FormatException();
                    }
                    Inst[3] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внутреннего радиуса ролика должно находиться в диапазоне от 0 (Ролик сплошной) до 75 мм");
                    Inner_radius.Clear();
                    Inner_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Outer_radius.GetLineText(0));

                    if (temp > 300 || temp < 70)
                    {
                        throw new FormatException();
                    }
                    Inst[4] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внешнего радиуса ролика должно находиться в диапазоне от 70 до 300 мм");
                    Outer_radius.Clear();
                    Outer_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Coef_of_Fourier_q1.GetLineText(0));

                    if (temp > 100 || temp < 80)
                    {
                        throw new FormatException();
                    }
                    Inst[5] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение коэффициента Фурье должно находиться в диапазоне от 80 до 100");
                    Coef_of_Fourier_q1.Clear();
                    Coef_of_Fourier_q1.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Coef_of_Fourier_q2.GetLineText(0));

                    if (temp > 27 || temp < 22)
                    {
                        throw new FormatException();
                    }
                    Inst[6] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение коэффициента Фурье должно находиться в диапазоне от 22 до 27");
                    Coef_of_Fourier_q2.Clear();
                    Coef_of_Fourier_q2.Focus();
                    go = false;
                    break;
                }

                rot = new NonRotating(Inst);
                go = false;

                Results.Clear();
                Results.AppendText(rot.Show());

                Constituent_W.Clear();
                Constituent_W.AppendText(rot.ShowW());

                Constituent_V.Clear();
                Constituent_V.AppendText(rot.ShowV());
            }

            while (IsRotating.IsChecked == true && go == true)
            {
                double[] Inst = new double[6];
                double temp, newtemp;

                try
                {
                    temp = Convert.ToDouble(Coef_of_exp.GetLineText(0));

                    if (temp < 0.000002 || temp > 0.00144)
                    {
                        throw new FormatException();
                    }
                    Inst[0] = temp;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение Коэффициента линейного расширения ролика должно находиться в пределах от 0,000002 до 0,00144");
                    Coef_of_exp.Clear();
                    Coef_of_exp.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Width_of_slab.GetLineText(0));

                    if (temp > 5000 || temp < 350)
                    {
                        throw new FormatException();
                    }
                    Inst[1] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение ширины сляба должно находиться в диапазоне от 350 до 5000");
                    Width_of_slab.Clear();
                    Width_of_slab.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Lenght_of_roller.GetLineText(0));

                    if (temp > 10000 || temp < 1000)
                    {
                        throw new FormatException();
                    }
                    Inst[2] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение длины ролика должно находиться в диапазоне от 1000 до 10000");
                    Lenght_of_roller.Clear();
                    Lenght_of_roller.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Inner_radius.GetLineText(0));

                    if (temp != 0 && temp != 37.5 && temp != 45.0 && temp != 75.0)
                    {
                        throw new FormatException();
                    }
                    Inst[3] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внутреннего радиуса ролика может принимать значения:\n" +
                        "0.0 при внешем радиусе 70.0 мм, 90.0 мм, 107.5 мм, 120.5 мм\n" +
                        "37.5 мм при внешнем радуису 135.0 мм\n" +
                        "45.0 мм при внешнем радуису 165.0 мм\n" +
                        "75.0 мм при внешнем радуису 240.0 мм и 300.0 мм");
                    Inner_radius.Clear();
                    Inner_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    newtemp = Convert.ToDouble(Outer_radius.GetLineText(0));

                    switch (temp)
                    {
                        case 0.0:
                            if (newtemp != 70.0 && newtemp != 90 && newtemp != 107.5 && newtemp != 120.5)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;

                        case 37.5:
                            if (newtemp != 135.0)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;

                        case 45:
                            if (newtemp != 165.0)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;

                        case 75:
                            if (newtemp != 240.0 && newtemp != 300.0)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;
                        default:
                            throw new FormatException();
                    }
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внешнего радиуса ролика может принимать значения:\n" +
                        "70.0 мм, 90.0 мм, 107.5 мм, 120.5 мм при внутреннем радиусе 0.0 мм\n" +
                        "135.0 мм при внутреннем радиусе 37.5 мм\n" +
                        "165.0 мм при внутреннем радиусе 45.0 мм\n" +
                        "240.0 мм и 300.0 мм при внутреннем радиусе 75.0 мм");
                    Outer_radius.Clear();
                    Outer_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(Speed_of_stream.GetLineText(0));

                    if (temp > 5 || temp < 0.2)
                    {
                        throw new FormatException();
                    }
                    Inst[5] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение скорости разливки должно находиться в диапазоне 0.2 до 5");
                    Speed_of_stream.Clear();
                    Speed_of_stream.Focus();
                    go = false;
                    break;
                }

                
                rot = new Rotating(Inst);
                go = false;

                Results.Clear();
                Results.AppendText(rot.Show());

                Constituent_W.Clear();
                Constituent_W.AppendText(rot.ShowW());

                Constituent_V.Clear();
                Constituent_V.AppendText(rot.ShowV());
            }
        }

        private void IsRotating_or_Not(object sender, RoutedEventArgs e)
        {   
            if(Speed_of_stream != null)
                Speed_of_stream.IsEnabled = (IsRotating.IsChecked == true) ? true : false;
            if (Coef_of_Fourier_q1 != null)
                Coef_of_Fourier_q1.IsEnabled = (IsNotRotating.IsChecked == true) ? true : false;
            if (Coef_of_Fourier_q2 != null)
                Coef_of_Fourier_q2.IsEnabled = (IsNotRotating.IsChecked == true) ? true : false;
        }

        private void SCalculation_Click(object sender, RoutedEventArgs e)
        {
            bool go = true;

            while (SIsNotRotating.IsChecked == true && go == true)
            {
                double[] Inst = new double[9];
                double temp;
                double newtemp;

                try
                {
                    temp = Convert.ToDouble(SCoef_of_exp.GetLineText(0));

                    if (temp < 0.000002 || temp > 0.00144)
                    {
                        throw new FormatException();
                    }
                    Inst[0] = temp;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение Коэффициента линейного расширения ролика должно находиться в пределах от 0,000002 до 0,00144");
                    SCoef_of_exp.Clear();
                    SCoef_of_exp.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SWidth_of_slab_First.GetLineText(0));

                    if (temp > 5000 || temp < 350)
                    {
                        throw new FormatException();
                    }
                    Inst[1] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение ширины сляба должно находиться в диапазоне от 350 до 5000");
                    SWidth_of_slab_First.Clear();
                    SWidth_of_slab_First.Focus();
                    go = false;
                    break;
                }


                try
                {
                    newtemp = Convert.ToDouble(SWidth_of_slab_Second.GetLineText(0));

                    if (temp > 5000 || temp < 350 || newtemp <= temp)
                    {
                        throw new FormatException();
                    }
                    Inst[2] = newtemp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение ширины сляба должно находиться в диапазоне от 350 до 5000 и должно должно быть больше начального значения");
                    SWidth_of_slab_Second.Clear();
                    SWidth_of_slab_Second.Focus();
                    go = false;
                    break;
                }


                try
                {
                    temp = Convert.ToDouble(SLenght_of_roller.GetLineText(0));

                    if (temp > 10000 || temp < 1000)
                    {
                        throw new FormatException();
                    }
                    Inst[3] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение длины ролика должно находиться в диапазоне от 1000 до 10000");
                    SLenght_of_roller.Clear();
                    SLenght_of_roller.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SInner_radius.GetLineText(0));

                    if (temp > 75 || temp < 0)
                    {
                        throw new FormatException();
                    }
                    Inst[4] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внутреннего радиуса ролика должно находиться в диапазоне от 0 (Ролик сплошной) до 75 мм");
                    SInner_radius.Clear();
                    SInner_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SOuter_radius.GetLineText(0));

                    if (temp > 300 || temp < 70)
                    {
                        throw new FormatException();
                    }
                    Inst[5] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внешнего радиуса ролика должно находиться в диапазоне от 70 до 300 мм");
                    SOuter_radius.Clear();
                    SOuter_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SCoef_of_Fourier_q1.GetLineText(0));

                    if (temp > 100 || temp < 80)
                    {
                        throw new FormatException();
                    }
                    Inst[6] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение коэффициента Фурье должно находиться в диапазоне от 80 до 100");
                    SCoef_of_Fourier_q1.Clear();
                    SCoef_of_Fourier_q1.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SCoef_of_Fourier_q2.GetLineText(0));

                    if (temp > 27 || temp < 22)
                    {
                        throw new FormatException();
                    }
                    Inst[7] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение коэффициента Фурье должно находиться в диапазоне от 22 до 27");
                    SCoef_of_Fourier_q2.Clear();
                    SCoef_of_Fourier_q2.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SStep.GetLineText(0));

                    if (temp > 1000 || temp < 10)
                    {
                        throw new FormatException();
                    }
                    Inst[8] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение шага итерации должно находиться в диапазоне от 10 до 1000");
                    SStep.Clear();
                    SStep.Focus();
                    go = false;
                    break;
                }

                rot = new SNonRotating(Inst);
                go = false;

                SResults.Clear();
                SResults.AppendText(rot.Show());

                MessageBox.Show("Для наглядности представления зависимостей, значение Температурной составляющей деформации оси ролика в направлении Z домножено на 100 и поделено на Коэффициент Фурье");
            }

            while (SIsRotating.IsChecked == true && go == true)
            {
                double[] Inst = new double[8];
                double temp, newtemp;

                try
                {
                    temp = Convert.ToDouble(SCoef_of_exp.GetLineText(0));

                    if (temp < 0.000002 || temp > 0.00144)
                    {
                        throw new FormatException();
                    }
                    Inst[0] = temp;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение Коэффициента линейного расширения ролика должно находиться в пределах от 0,000002 до 0,00144");
                    SCoef_of_exp.Clear();
                    SCoef_of_exp.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SWidth_of_slab_Second.GetLineText(0));

                    if (temp > 5000 || temp < 350)
                    {
                        throw new FormatException();
                    }
                    Inst[1] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение ширины сляба должно находиться в диапазоне от 350 до 5000");
                    SWidth_of_slab_Second.Clear();
                    SWidth_of_slab_Second.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SLenght_of_roller.GetLineText(0));

                    if (temp > 10000 || temp < 1000)
                    {
                        throw new FormatException();
                    }
                    Inst[2] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение длины ролика должно находиться в диапазоне от 1000 до 10000");
                    SLenght_of_roller.Clear();
                    SLenght_of_roller.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SInner_radius.GetLineText(0));

                    if (temp != 0 && temp != 37.5 && temp != 45.0 && temp != 75.0)
                    {
                        throw new FormatException();
                    }
                    Inst[3] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внутреннего радиуса ролика может принимать значения:\n" +
                        "0.0 при внешем радиусе 70.0 мм, 90.0 мм, 107.5 мм, 120.5 мм\n" +
                        "37.5 мм при внешнем радуису 135.0 мм\n" +
                        "45.0 мм при внешнем радуису 165.0 мм\n" +
                        "75.0 мм при внешнем радуису 240.0 мм и 300.0 мм");
                    SInner_radius.Clear();
                    SInner_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    newtemp = Convert.ToDouble(SOuter_radius.GetLineText(0));

                    switch (temp)
                    {
                        case 0.0:
                            if (newtemp != 70.0 && newtemp != 90 && newtemp != 107.5 && newtemp != 120.5)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;

                        case 37.5:
                            if (newtemp != 135.0)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;

                        case 45:
                            if (newtemp != 165.0)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;

                        case 75:
                            if (newtemp != 240.0 && newtemp != 300.0)
                            {
                                throw new FormatException();
                            }
                            Inst[4] = newtemp;
                            break;
                        default:
                            throw new FormatException();
                    }
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение внешнего радиуса ролика может принимать значения:\n" +
                        "70.0 мм, 90.0 мм, 107.5 мм, 120.5 мм при внутреннем радиусе 0.0 мм\n" +
                        "135.0 мм при внутреннем радиусе 37.5 мм\n" +
                        "165.0 мм при внутреннем радиусе 45.0 мм\n" +
                        "240.0 мм и 300.0 мм при внутреннем радиусе 75.0 мм");
                    SOuter_radius.Clear();
                    SOuter_radius.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SSpeed_of_stream_First.GetLineText(0));

                    if (temp > 5 || temp < 0.2)
                    {
                        throw new FormatException();
                    }
                    Inst[5] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение скорости разливки должно находиться в диапазоне 0.2 до 1.2");
                    SSpeed_of_stream_First.Clear();
                    SSpeed_of_stream_First.Focus();
                    go = false;
                    break;
                }

                try
                {
                    newtemp = Convert.ToDouble(SSpeed_of_stream_Second.GetLineText(0));

                    if (newtemp > 5 || newtemp < 0.2 || newtemp <= temp)
                    {
                        throw new FormatException();
                    }
                    Inst[6] = newtemp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение скорости разливки должно находиться в диапазоне 0.2 до 5 и быть больше начального значения");
                    SSpeed_of_stream_Second.Clear();
                    SSpeed_of_stream_Second.Focus();
                    go = false;
                    break;
                }

                try
                {
                    temp = Convert.ToDouble(SStep.GetLineText(0));

                    if (temp > 2 || temp < 0.001)
                    {
                        throw new FormatException();
                    }
                    Inst[7] = temp;
                }

                catch (FormatException)
                {
                    MessageBox.Show("Значение шага итерации должно находиться в диапазоне от 0.001 до 2");
                    SStep.Clear();
                    SStep.Focus();
                    go = false;
                    break;
                }

                rot = new SRotating(Inst);
                go = false;

                SResults.Clear();
                SResults.AppendText(rot.Show());
                MessageBox.Show("Для наглядности представления зависимостей, значение Температурной составляющей деформации оси ролика в направлении Z домножено на 100 и поделено на Коэффициент Фурье");
            }
        }

        private void SIsRotating_or_Not(object sender, RoutedEventArgs e)
        {
            if (SSpeed_of_stream_First != null)
                SSpeed_of_stream_First.IsEnabled = (SIsRotating.IsChecked == true) ? true : false;
            if (SSpeed_of_stream_Second != null)
                SSpeed_of_stream_Second.IsEnabled = (SIsRotating.IsChecked == true) ? true : false;
            if (SCoef_of_Fourier_q1 != null)
                SCoef_of_Fourier_q1.IsEnabled = (SIsNotRotating.IsChecked == true) ? true : false;
            if (SCoef_of_Fourier_q2 != null)
                SCoef_of_Fourier_q2.IsEnabled = (SIsNotRotating.IsChecked == true) ? true : false;
            if (SWidth_of_slab_First != null)
                SWidth_of_slab_First.IsEnabled = (SIsNotRotating.IsChecked == true) ? true : false;
        }
    }
 }

