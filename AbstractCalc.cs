namespace CoDoR
{
    abstract class AbstractCalc
    {   

        protected double ConstituentW; //Температурная составляющая деформации оси ролика в направлении Z
        protected double ConstituentV; //Температурная составляющая деформации оси ролика в направлении Y
        protected double Distance; //Расстояние от опоры до сляба
        protected double CoefOfExp; //Коэффициент линейного расширения ролика
        protected double WidthOfSlab; //Ширина сляба
        protected double LenghtOfRoller; //Длина ролика
        protected double InnerRadius; //Внутренний радиус ролика
        protected double OuterRadius; //Внешний радиус ролика
        protected double CoefOfFourierQ1; //Коэффициент Фурье температуры на наружной поверхности ролика
        protected double CoefOfFourierQ2; //Коэффициент Фурье температуры на наружной поверхности 

        abstract public void Calculaion();
        abstract public string Show();
        abstract public string ShowW();
        abstract public string ShowV();
    }
}
