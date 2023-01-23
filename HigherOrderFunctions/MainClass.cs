using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherOrderFunctions
{
    public class MainClass
    {

		#region
		private static Func<int, (double x1, double x2)> A = ProductParamtersFood;
		private static Func<int, (double x1, double x2)> B = ProductParamtersBeverage;
		private static Func<int, (double x1, double x2)> C = ProductParamtersRawMaterial;
		private static Order R = new Order { OrderID = 10, ProductIndex = 100, Quantity = 20, UnitPrice = 4 };
		#endregion

		public static void RunExample()
        {
			var product = ProductType.Food;

			Func<int, (double x1, double x2)> P = (product == ProductType.Food) ? A : 
				                                  ((product == ProductType.Beverage) ? B :
												  C);
			Console.WriteLine(MainClass.ClaculateDiscount(P, R).ToString());
		}







        private static double ClaculateDiscount(Func<int, (double x1, double x2)> ProductParamterCalc, Order Order)
		{
			(double x1, double x2) paramters = ProductParamterCalc(Order.ProductIndex);
			return paramters.x1 * Order.Quantity + paramters.x2 * Order.UnitPrice;
		}


		static (double x1, double x2) ProductParamtersFood(int ProductIndex)
		{
			return (x1: ProductIndex / (double)(ProductIndex + 100), x2: ProductIndex / (double)(ProductIndex + 300));

		}

		static (double x1, double x2) ProductParamtersBeverage(int ProductIndex)
		{
			return (x1: ProductIndex / (double)(ProductIndex + 300), x2: ProductIndex / (double)(ProductIndex + 400));
		}

		static (double x1, double x2) ProductParamtersRawMaterial(int ProductIndex)
		{
			return (x1: ProductIndex / (double)(ProductIndex + 400), x2: ProductIndex / (double)(ProductIndex + 700));
		}



		
	}
	public enum ProductType
	{
		Food,
		Beverage,
		RawMaterial

	}

	public class Order
	{

		public int OrderID;
		public int ProductIndex;
		public double Quantity;
		public double UnitPrice;

	}
}
