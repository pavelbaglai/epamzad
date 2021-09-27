using System;

namespace Homework3_1
{
    public class Newton
    {
        private double Eps { get; set; }

        public Newton (double val= 0.0001)
        {
            Eps = val;
        }

        //Метод Ньютона (метод касательных) - итерационный метод. 
        //Может применяться для нахождения корней функций типа f(x) = 0;
        //Находим грубое приближение корня X0.
        //Вычисляем поправку к значению X0: Dx = -f(X0)/f'(X0).
        //Новое значение X1 = X0 + Dx.
        //Проверка условия f(X1) = 0.
        //Если не удовлетворены, идем на шаг 2, но уже с x = X1.
        // Вычисление квадратного корня из P с погрешностью е при начальном приближении x0.

        static double Pow(double val, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= val;
            return result;
        }

        public double Exec(int n, double A)
        {
            if (A<0) throw new ArgumentOutOfRangeException("Число не может быть меньше нуля");
            double x0 = A / n;
            double x1 = (1 / (double)n) * ((n - 1) * x0 + A / Pow(x0, n - 1));

            while (Math.Abs(x1 - x0) > Eps)
            {
                x0 = x1;
                x1 = (1 / (double)n) * ((n - 1) * x0 + A / Pow(x0, (int)n - 1));
            }

            return x1;
        }
    }
}