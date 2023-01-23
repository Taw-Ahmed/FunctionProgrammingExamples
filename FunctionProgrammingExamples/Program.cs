// See https://aka.ms/new-console-template for more information

List<int> numbers = new List<int> { 2, 3, 45, 6, 7 };

// I want for each number in this list to be squared, then decreased by 5 then multiples by 10 

// FP way or declartive programming

//var numbersAfterProcessing = numbers.Select(n => n * n)
//                                    .Select(n => n -5)
//                                    .Select(n => n * 10).ToList();
//numbersAfterProcessing.ForEach(n => Console.WriteLine(n));
// another way is 
var numbersAfterProcessing = numbers.Select(Square)
                                    .Select(n => Subtraction(n, 5))
                                    .Select(n => multiply(n, 10)).ToList();
numbersAfterProcessing.ForEach(n => Console.WriteLine(n));

Console.WriteLine("########################################################");
// impritve way would be more complex 
foreach (var item in numbers)
{
    var numberAfterProcessing = multiply(Subtraction(Square(item), 5), 10);
    Console.WriteLine(numberAfterProcessing);
}
 int Square(int n) { return n * n; }
int Subtraction(int n, int d) { return n - 5; }
int multiply(int n, int d) { return n * d; }


//Console.WriteLine("Hello, World!");


// higher order function is the function that take or return function as argument 
// or even both
// for example   delegate DoSomthing(delegate x, other parameters){return delegeate;}
