

using System.Globalization;
using System.Transactions;

public class BMICalculator<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    private Stack<double> bmiStack = new Stack<double>();

    public double CalculateBMI(T weight, T height, bool isMetric)
    {
        double weightValue = Convert.ToDouble(weight);
        double heightValue = Convert.ToDouble(height);

        if (!isMetric)
        {
            heightValue = heightValue * 0.0254;
            weightValue = weightValue * 0.453592;
        }

        double bmi = weightValue / (heightValue * heightValue);
        bmiStack.Push(bmi);
        return bmi;
    }

    public string GetBMICategory(double bmi)
    {
        if (bmi < 18.5)
        {
            return "Underweight";
        }
        else if (bmi >= 18.5 && bmi < 24.9)
        {
            return "Normal weight";
        }
        else if (bmi >= 25 && bmi < 29.9)
        {
            return "Overweight";
        }
        else
        {
            return "Obesity";
        }
    }

    public void Display()
    {
        foreach (var bmi in bmiStack)
        {
            Console.WriteLine($"BMI: {bmi} - Category: {GetBMICategory(bmi)}");
        }
    }
}

public class Calculator<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    public Func<T, T, T> Add { get; set; }
    public Func<T, T, T> Sub { get; set; }
    public Func<T, T, T> Multiply { get; set; }
    public Func<T, T, T> Divide { get; set; }

    public Calculator()
    {
        Add = (x, y) => (dynamic)x + y;
        Sub = (x, y) => (dynamic)x - y;
        Multiply = (x, y) => (dynamic)x * y;
        Divide = (x, y) => (dynamic)x / y;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("enter the type value (1: int, 2: double, 3: float):");
        int x = int.Parse(Console.ReadLine());

        switch (x)
        {
            case 1:
                RunBMICalculator<int>();
                break;
            case 2:
                RunBMICalculator<double>();
                break;
            case 3:
                RunBMICalculator<float>();
                break;
            default:
                Console.WriteLine("Invalid  try again");
                break;
        }

        RunCalculator();
    }

    public static void RunBMICalculator<T>() where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        BMICalculator<T> bmiCalculator = new BMICalculator<T>();

        Console.WriteLine("Enter height (in meters or feet/inches):");
        T height = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        Console.WriteLine("Enter weight (in kilograms or pounds):");
        T weight = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        Console.WriteLine("Is the input in metric units? (yes/no):");
        bool isMetric = Console.ReadLine().ToLower() == "yes";

        double bmi = bmiCalculator.CalculateBMI(weight, height, isMetric);
        string category = bmiCalculator.GetBMICategory(bmi);

        Console.WriteLine($"Calculated BMI: {bmi}");
        Console.WriteLine($"BMI Category: {category}");

        Console.WriteLine("Previous BMI calculations:");
    bmiCalculator.Display();
    }

   

    public static void RunCalculator()
    {
        Console.WriteLine("enter the type value  you want calculate (1: int, 2: double):");
        int y = int.Parse(Console.ReadLine());

        switch (y)
        {
            case 1:
                Calculator<int> intCalculator = new Calculator<int>();

                Console.WriteLine(" enter the integer number 1 :");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine(" enter the integer number 2 :");
                int num2 = int.Parse(Console.ReadLine());


                Console.WriteLine("enter the process (1: Add, 2: Substruct , 3: Multiply , 4: Divide):");
                int x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 1:
                        Console.WriteLine($"Addition of {num1} and {num2}: {intCalculator.Add(num1, num2)}");
                        break;
                    case 2:
                        Console.WriteLine($"Subtraction of {num1} and {num2}: {intCalculator.Sub(num1, num2)}");
                        break;
                    case 3:
                        Console.WriteLine($"Multiplication of {num1} and {num2}: {intCalculator.Multiply(num1, num2)}");
                        break;
                    case 4:
                        Console.WriteLine($"Division of {num1}by {num2}: {intCalculator.Divide(num1, num2)}");
                        break;

                    default:
                        Console.WriteLine("Invalid  try again");
                        break;
                }

              
                break;
            case 2:
                Calculator<double> doubleCalculator = new Calculator<double>();
                Console.WriteLine(" enter the double number 1 :");
               double dnum1 = double.Parse(Console.ReadLine());

                Console.WriteLine(" enter the double number 2 :");
                double dnum2 = double.Parse(Console.ReadLine());


                Console.WriteLine("enter the process (1: Add, 2: Substruct , 3: Multiply , 4: Divide):");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine($"Addition of {dnum1} and {dnum2}: {doubleCalculator.Add(dnum1, dnum2)}");
                        break;
                    case 2:
                        Console.WriteLine($"Subtraction of {dnum1} and {dnum2}: {doubleCalculator.Sub(dnum1, dnum2)}");
                        break;
                    case 3:
                        Console.WriteLine($"Multiplication of {dnum1} and {dnum2}: {doubleCalculator.Multiply(dnum1, dnum2)}");
                        break;
                    case 4:
                        Console.WriteLine($"Division of {dnum1}by {dnum2}: {doubleCalculator.Divide(dnum1, dnum2)}");
                        break;

                    default:
                        Console.WriteLine("Invalid  try again");
                        break;
                }

                break;
           
            default:
                Console.WriteLine("Invalid  try again");
                break;
        }

       
       
       
      
    }
}
