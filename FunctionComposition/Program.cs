using FunctionComposition;

List<double> numbers = new List<double> { 2, 3, 45, 6, 7 };


Func<double, double> MyComposedFunction =
			ComposeFunction(AddOne, Square, SubtractTen);

#region  Normal Use for Functions PIpeLine
numbers.Select(AddOne).Select(Square).Select(SubtractTen).ToList().ForEach((x) => Console.WriteLine(x.ToString()));
Console.ReadLine();
#endregion
#region   Manual Composition complex pipeline
numbers.Select((x) => SubtractTen(Square(AddOne(x)))).ToList().ForEach((x) => Console.WriteLine(x.ToString()));
Console.ReadLine();
#endregion
#region  COmpose Using specific Function 
numbers.Select(MyComposedFunction).ToList().ForEach((x) => Console.WriteLine(x.ToString()));
Console.ReadLine();
#endregion
#region  COmpose using a function use a composer 
numbers.Select(AddoneSquareSubtractTen()).ToList().ForEach((x) => Console.WriteLine(x.ToString()));
Console.ReadLine();
#endregion




Func<double, Double> Test()
{
	return x => x + 1;
}


double AddOne(double x)
{
	return x + 1;
}

double Square(double x)
{
	return Math.Pow(x, 2);
}

double SubtractTen(double x)
{
	return x - 10;
}

Func<double, double> ComposeFunction(Func<double, double> F1, Func<double, double> F2, Func<double, double> F3)
{
	return (x) =>
	{
		return F3(F2(F1(x)));
	};
}


Func<double, double> AddoneSquareSubtractTen()
{

	Func<double, double> q1 = AddOne;
	Func<double, double> q2 = Square;
	Func<double, double> q3 = SubtractTen;

	return q1.Compose(q2).Compose(q3);

}

