using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    class Program
    {
        static double f12(double x1, double x2)
        {
            return -6 * x1 * x1 + 15 * x1 - x2 * x2 - 3 * x2 + 42;
        }

        static double f21(double x1, double x2)
        {
            return -5 * x2 * x2 + 17 * x2 + 9 * x1 * x1 + 2 * x1 + 7;
        }

        static void print(double [][] arr, int w, int h)
        {
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
			int l1, l2, r1, r2;
			Console.WriteLine("Enter lower range x1:");
			l1 = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter upper range x1:");
			r1 = int.Parse(Console.ReadLine());

			Console.WriteLine("Enter lower range x2:");
			l2 = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter upper range x2:");
			r2 = int.Parse(Console.ReadLine());

			double step1 = 0.1;
			double step2 = 0.1;
			int size1 = (int)(Math.Abs(r1 - l1) / step1);
			int size2 = (int)(Math.Abs(r2 - l2) / step2);
			double[][] matrixf12 = new double[size1][];
			double[][] matrixf21 = new double[size2][];

			for (int i = 0; i < size1; ++i)
			{
				matrixf12[i] = new double[size2];
				for (int j = 0; j < size2; ++j)
				{
					matrixf12[i][j] = f12(i + step1, j + step2);
				}
			}

			for (int i = 0; i < size2; ++i)
			{
				matrixf21[i] = new double[size1];
				for (int j = 0; j < size1; ++j)
				{
					matrixf21[i][j] = f21(i + step2, j + step1);
				}
			}

			print(matrixf12, size1, size2);
			print(matrixf21, size2, size1);

			double f12star, f21star;
			List<double> mins = new List<double>();
			for (int i = 0; i < size1; ++i)
			{
				double tmin = matrixf12[i][0];
				for (int k = 0; k < size2; ++k)
				{
					tmin = (matrixf12[i][k] < tmin) ? matrixf12[i][k] : tmin;
				}
				mins.Add(tmin);
			}
			double max = mins.Max();
			Console.WriteLine($"MaxMin = {max}");

			List<double> maxs = new List<double>();
			for (int i = 0; i < size2; ++i)
			{
				double tmax = matrixf21[i][0];
				for (int k = 0; k < size1; ++k)
				{
					max = (matrixf21[i][k] > max) ? matrixf21[i][k] : max;
				}
				maxs.Add(max);
			}
			double min = maxs.Min();
			Console.WriteLine($"MinMax = {min}");
		}
    }
}
