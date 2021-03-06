using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Area
{
	public static class CalculateArea
	{
		public static double pi = 3.1415926535897931;

		//Area.CalculateArea.CircleA(1);
		public static double CircleA(double r)
		{
			return pi * r * r;
		}

		//Area.CalculateArea.TriangleA(3,4,5);
		public static double TriangleA(double a, double b, double c)
		{
			double[] array = { a, b, c };
			Array.Sort(array);

			double max = array[array.Length - 1];
			double min1 = array[array.Length - 2];
			double min2 = array[array.Length - 3];

			double hip = max * max;
			double kat = (min1 * min1) + (min2 * min2);

			if (hip == kat)
			{
				return (min1 * min2) / 2;
			}
			else
			{
				double p = (a + b + c) / 2;
				return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
			}
		}

		//Area.CalculateArea.SimplePolygonA("0,1 2,3 4,7");
		public static double SimplePolygonA(string data)
		{
			List<string> xystring = data.Split(' ').ToList();
			double a = 0.0;
			int n = xystring.Count;

			int count0 = xystring.Count(g => g.Contains(","));

			if ((n >= 3) && (count0 == n))
			{
				List<string> numx = new List<string>() { };
				List<string> numy = new List<string>() { };
				List<string> nummaskx = new List<string>() { };
				List<string> nummasky = new List<string>() { };

				for (int k = 0; k < n; k++)
				{
					numx.Add(xystring[k].Split(',')[0]);
					numy.Add(xystring[k].Split(',')[1]);

					double Num1;
					bool isNum1 = double.TryParse(xystring[k].Split(',')[0], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out Num1);
					double Num2;
					bool isNum2 = double.TryParse(xystring[k].Split(',')[1], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out Num2);

					if (isNum1)
					{
						nummaskx.Add("True");
					} else
					{
						nummaskx.Add("False");
					}

					if (isNum2)
					{
						nummasky.Add("True");
					}
					else
					{
						nummasky.Add("False");
					}
				}

				int count1 = nummaskx.Count(s => s == "True");
				int count2 = nummasky.Count(f => f == "True");

				if ((numx.Count == numy.Count) && (count1 == n) && (count2 == n))   
				{ 
					int j = n - 1;

					for (int i = 0; i < n; i++)
					{
						double xprev = Convert.ToDouble(xystring[j].Split(',')[0], CultureInfo.InvariantCulture);
						double yprev = Convert.ToDouble(xystring[j].Split(',')[1], CultureInfo.InvariantCulture);
						double x = Convert.ToDouble(xystring[i].Split(',')[0], CultureInfo.InvariantCulture);
						double y = Convert.ToDouble(xystring[i].Split(',')[1], CultureInfo.InvariantCulture);

						a += (xprev + x) * (yprev - y);

						j = i;
					}

					return Math.Abs(a / 2);
				} else
				{
					Console.WriteLine("Дайте все числовые координаты");
					return 0.0;
				}
			}
			else
			{
				Console.WriteLine("Дайте 3 или более координат через запятую, разделяя пробелами");
				return 0.0;
			}

		}

	}

}
