using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_6
{
    public class Polynomial
    {
        private readonly double[] polycoefficients;

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null) throw new ArgumentNullException();
            if (coefficients.Length == 0) throw new ArgumentOutOfRangeException();
            foreach (var coefficient in coefficients)
            {
                if (coefficient < 0) throw new ArgumentOutOfRangeException();
            }
            
            polycoefficients = coefficients;
        }

        public double this[int n]
        {
            get {
                if (Order > 0 && n>=0&&n<=Order)
                {return polycoefficients[n];}
                else { throw new ArgumentOutOfRangeException();} }
            set
            {
                if (Order > 0 && n >= 0)
                { polycoefficients[n] = value; }
                else { throw new ArgumentOutOfRangeException(); }
            }
        }

        public int Order
        {
            get { return polycoefficients.Length; }
        }

        public override string ToString()
        {
            return string.Format("Coefficients: " + string.Join("; ", polycoefficients));
        }

        public double Calculate(double x)
        {
            int n = polycoefficients.Length - 1;
            double res = polycoefficients[n];
            for (int i = n - 1; i >= 0; i--)
                res = x * res + polycoefficients[i];
            return res;
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            if (first.Equals(null) || second.Equals(null)) throw new ArgumentNullException();

            int cnt = Math.Max(first.polycoefficients.Length, second.polycoefficients.Length);
            var res = new double[cnt];
            for (int i = 0; i < cnt; i++)
            {
                double a = 0;
                double b = 0;
                if (i < first.polycoefficients.Length)
                    a = first[i];
                if (i < second.polycoefficients.Length)
                    b = second[i];
                res[i] = a + b;
            }
            return new Polynomial(res);
        }

        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            if (first.Order == 0 || second.Order == 0) throw new ArgumentOutOfRangeException();

            int cnt = Math.Max(first.polycoefficients.Length, second.polycoefficients.Length);
            var res = new double[cnt];
            for (int i = 0; i < cnt; i++)
            {
                double a = 0;
                double b = 0;
                if (i < first.polycoefficients.Length)
                    a = first[i];
                if (i < second.polycoefficients.Length)
                    b = second[i];
                res[i] = a - b;
            }
            return new Polynomial(res);
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            if (first.Order == 0 || second.Order == 0) throw new ArgumentOutOfRangeException();

            int cnt = first.polycoefficients.Length + second.polycoefficients.Length - 1;
            var res = new double[cnt];
            for (int i = 0; i < first.polycoefficients.Length; i++)
            {
                for (int j = 0; j < second.polycoefficients.Length; j++)
                    res[i + j] += first[i] * second[j];
            }

            return new Polynomial(res);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Polynomial p = (Polynomial)obj;
            return (Order == p.Order) && (Order == p.Order);
        }

        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first.Order == 0 || second.Order == 0) throw new ArgumentOutOfRangeException();

            if (first.polycoefficients.Length != second.polycoefficients.Length)
                return false;
            for (int i = 0; i < first.polycoefficients.Length; i++)
            {
                if (first[i] != second[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(Polynomial first, Polynomial second)
        {
            if (first.Order == 0 || second.Order == 0) throw new ArgumentOutOfRangeException();

            return !(first == second);
        }
    }
}
