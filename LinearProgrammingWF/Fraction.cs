using System;

namespace LinearProgrammingWF
{
    //Класс дроби
    public class Fraction
    {
        //Дробь состоит из числителя/знаменателя
        private int numerator;
        private int denominator;

        //Конструкторы
        public Fraction(int number)
        {
            this.numerator = number;
            this.denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.Simplify();
        }
        public Fraction(double number)
        {
            this.numerator = Convert.ToInt32(number * 1000);
            this.denominator = 1000;
            this.Simplify();
        }

        //Нахождение НОДа
        static int GCD(int x, int y)
        {
            if (x == 0) return y;
            if (y == 0) return x;
            x = Math.Abs(x);
            y = Math.Abs(y);
            if (x > y) return GCD(y, x);
            return GCD(y % x, x);
        }

        //Сокращение дроби
        public Fraction Simplify()
        {
            if ((this.numerator < 0) && (this.denominator < 0))
            {
                this.numerator *= -1;
                this.denominator *= -1;
            }
            if ((this.numerator >= 0) && (this.denominator < 0))
            {
                this.numerator *= -1;
                this.denominator *= -1;
            }
            int divider = GCD(this.numerator, this.denominator);
            if (divider != 0)
            {
                this.numerator = this.numerator / divider;
                this.denominator = this.denominator / divider;
            }
            if (this.numerator == 0)
                this.denominator = 1;

            return this;
        }

        override public string ToString()
        {
            if (denominator == 1)
                return numerator.ToString();
            else
            {
                return numerator.ToString() + '/' + denominator.ToString();
            }
        }
        public string ToStringDouble()
        {
            return ((double)this.numerator / this.denominator).ToString();
        }

        //Перегрузка операторов
        public static Fraction operator +(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.denominator + y.numerator * x.denominator, x.denominator * y.denominator)).Simplify();
        }
        public static Fraction operator -(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.denominator - y.numerator * x.denominator, x.denominator * y.denominator)).Simplify();
        }
        public static Fraction operator *(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.numerator, x.denominator * y.denominator)).Simplify();
        }
        public static Fraction operator /(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.denominator, x.denominator * y.numerator)).Simplify();
        }
        public static Fraction operator +(Fraction x, int y)
        {
            return (x + new Fraction(y));
        }
        public static Fraction operator -(Fraction x, int y)
        {
            return (x - new Fraction(y));
        }
        public static Fraction operator *(Fraction x, int y)
        {
            return (x * new Fraction(y));
        }
        public static Fraction operator /(Fraction x, int y)
        {
            return (x / new Fraction(y));
        }
        public static Fraction operator +(Fraction x, double y)
        {
            return (x + new Fraction(y));
        }
        public static Fraction operator -(Fraction x, double y)
        {
            return (x - new Fraction(y));
        }
        public static Fraction operator *(Fraction x, double y)
        {
            return (x * new Fraction(y));
        }
        public static Fraction operator /(Fraction x, double y)
        {
            return (x / new Fraction(y));
        }
        public static bool operator ==(Fraction x, Fraction y)
        {
            if (x is null)
                x = new Fraction(0);
            if (y is null)
                y = new Fraction(0);

            if ((x.numerator == y.numerator) && (x.denominator == y.denominator))
                return true;
            else
                return false;
        }
        public static bool operator !=(Fraction x, Fraction y)
        {
            if (x is null)
                x = new Fraction(0);
            if (y is null)
                y = new Fraction(0);

            if ((x.numerator == y.numerator) && (x.denominator == y.denominator))
                return false;
            else
                return true;
        }
        public static bool operator >(Fraction x, Fraction y)
        {
            if (x is null)
                x = new Fraction(0);
            if (y is null)
                y = new Fraction(0);

            Fraction f1 = new Fraction(x.numerator, x.denominator);
            Fraction f2 = new Fraction(y.numerator, y.denominator);
            f1.numerator = f1.numerator * f2.denominator;
            f2.numerator = f2.numerator * f1.denominator;
            if (f1.numerator > f2.numerator)
                return true;
            else
                return false;
        }
        public static bool operator >=(Fraction x, Fraction y)
        {
            if (x is null)
                x = new Fraction(0);
            if (y is null)
                y = new Fraction(0);

            return ((x > y) || (x == y));
        }
        public static bool operator <(Fraction x, Fraction y)
        {
            if (x is null)
                x = new Fraction(0);
            if (y is null)
                y = new Fraction(0);

            Fraction f1 = new Fraction(x.numerator, x.denominator);
            Fraction f2 = new Fraction(y.numerator, y.denominator);
            f1.numerator = f1.numerator * f2.denominator;
            f2.numerator = f2.numerator * f1.denominator;
            if (f1.numerator < f2.numerator)
                return true;
            else
                return false;
        }
        public static bool operator <=(Fraction x, Fraction y)
        {
            if (x is null)
                x = new Fraction(0);
            if (y is null)
                y = new Fraction(0);

            return ((x < y) || (x == y));
        }
        public static bool operator ==(Fraction x, int y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x == new Fraction(y));
        }
        public static bool operator !=(Fraction x, int y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x != new Fraction(y));
        }
        public static bool operator >(Fraction x, int y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x > new Fraction(y));
        }
        public static bool operator >=(Fraction x, int y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x >= new Fraction(y));
        }
        public static bool operator <(Fraction x, int y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x < new Fraction(y));
        }
        public static bool operator <=(Fraction x, int y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x <= new Fraction(y));
        }
        public static bool operator ==(Fraction x, double y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x == new Fraction(y));
        }
        public static bool operator !=(Fraction x, double y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x != new Fraction(y));
        }
        public static bool operator >(Fraction x, double y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x > new Fraction(y));
        }
        public static bool operator >=(Fraction x, double y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x >= new Fraction(y));
        }
        public static bool operator <(Fraction x, double y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x < new Fraction(y));
        }
        public static bool operator <=(Fraction x, double y)
        {
            if (x is null)
                x = new Fraction(0);

            return (x <= new Fraction(y));
        }
        public static bool operator ==(int y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x == new Fraction(y));
        }
        public static bool operator !=(int y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x != new Fraction(y));
        }
        public static bool operator >(int y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x > new Fraction(y));
        }
        public static bool operator >=(int y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x >= new Fraction(y));
        }
        public static bool operator <(int y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x < new Fraction(y));
        }
        public static bool operator <=(int y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x <= new Fraction(y));
        }
        public static bool operator ==(double y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x == new Fraction(y));
        }
        public static bool operator !=(double y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x != new Fraction(y));
        }
        public static bool operator >(double y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x > new Fraction(y));
        }
        public static bool operator >=(double y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x >= new Fraction(y));
        }
        public static bool operator <(double y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x < new Fraction(y));
        }
        public static bool operator <=(double y, Fraction x)
        {
            if (x is null)
                x = new Fraction(0);

            return (x <= new Fraction(y));
        }
    }
}
