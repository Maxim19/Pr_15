/*Задание 1
1)	Создать абстрактный класс Figure с методами вычисления площади и периметра, а также методом, выводящим  информацию о фигуре на экран. 
2)	Создать производные классы: Rectangle (прямоугольник), Circle (круг), Triangle (треугольник) со своими методами вычисления площади и периметра. 
3)	Создать массив n фигур и вывести полную информацию о фигурах на экран. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Figure
{
    //Создать абстрактный класс Figure с методами вычисления площади и периметра, а также методом, выводящим  информацию о фигуре на экран. 
    abstract class Figure
    {
        public abstract double Area();

        public abstract double Perimeter();

        public abstract void ShowInfo();
    }

    //Создать производные классы: Rectangle (прямоугольник) со своими методами вычисления площади и периметра. 
    class Rectangle : Figure
    {
        int a, b;

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public override double Area() { return a * b; }

        public override double Perimeter() { return (a + b) * 2; }

        public override void ShowInfo()
        {
            Console.WriteLine("Прямоугольник со сторонами {0} и {1}", a, b);
        }
    }

    //Создать производные классы: Triangle (треугольник) со своими методами вычисления площади и периметра. 
    class Triangle : Figure
    {
        int a, b, c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.c = c;
            this.b = b;
        }

        public override double Perimeter() { return a + b + c; }


        public override double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Треугольник со сторонами {0}, {1}, {2}", a, b, c);
        }
    }

    //Создать производные классы: Circle (круг),  со своими методами вычисления площади и периметра. 
    class Circle : Figure
    {
        const double pi = 3.14;

        int r;

        public Circle(int r) { this.r = r; }

        public override double Area() { return pi * r * r; }

        public override double Perimeter() { return 2 * pi * r; }

        public override void ShowInfo()
        {
            Console.WriteLine("Круг радиусом {0}.", r);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Figure[] array_fig = read();

            foreach (Figure fig in array_fig)
            {
                Console.WriteLine();
                fig.ShowInfo();
                Console.WriteLine("S: {0}", fig.Area());
                Console.WriteLine("P: {0}", fig.Perimeter());
            }
            Console.ReadKey();
        }

        public static Figure[] read()
        {
            StreamReader fin = new StreamReader("input.txt");
            string str = fin.ReadToEnd();
            fin.Close();
                        

            string[] s = str.Split('\n');

            Figure[] array_fig = new Figure[s.Length];

            int a = 0, b = 0, c = 0, r = 0, i = 0;

            while (i < s.Length)
            {
                switch (s[i][0])
                {
                    case 'r':
                        string[] rectangle = s[i].Split(' ');
                        a = Convert.ToInt32(rectangle[1]);
                        b = Convert.ToInt32(rectangle[2]);
                        array_fig[i] = new Rectangle(a, b);
                        i++;
                        break;
                    case 'c':
                        string[] circle = s[i].Split(' ');
                        r = Convert.ToInt32(circle[1]);
                        array_fig[i] = new Circle(r);
                        i++;
                        break;
                    case 't':
                        string[] triangle = s[i].Split(' ');
                        a = Convert.ToInt32(triangle[1]);
                        b = Convert.ToInt32(triangle[2]);
                        c = Convert.ToInt32(triangle[3]);
                        array_fig[i] = new Triangle(a, b, c);
                        i++;
                        break;
                    default:
                        break;
                }
            }            
            return array_fig;
        }
    }
}
