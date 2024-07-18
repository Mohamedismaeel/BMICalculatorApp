using System;
using System.Collections.Generic;

namespace BMICalculatorApp
{
    public class BMICalculator<T>
    {
        private Stack<double> bmiHistory;

        public BMICalculator()
        {
            bmiHistory = new Stack<double>();
        }

        public double CalculateBMI(T height, T weight, string unit)
        {
            double h = Convert.ToDouble(height);
            double w = Convert.ToDouble(weight);
            double bmi;

            if (unit.ToLower() == "m")
            {
                bmi = w / (h * h);
            }
            else if (unit.ToLower() == "f")
            {
                bmi = (w / (h * h)) * 703;
            }
            else
            {
                throw new ArgumentException("Wrong input please use Meter or Feet ");
            }

            StoreInStack(bmi);
            return bmi;
        }

        public string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi < 24.9)
            {
                return "Normal weight";
            }
            else if (bmi < 29.9)
            {
                return "Overweight";
            }
            else
            {
                return "Obesity";
            }
        }

        private void StoreInStack(double bmi)
        {
            bmiHistory.Push(bmi);
        }

        public bool ShowPreviousBMICalculations()
        {
            if (bmiHistory.Count == 0)
            {
                Console.WriteLine("There is NO history");
                return false;
            }

            Console.WriteLine("Hisstory of bmi: ");
            foreach (var bmi in bmiHistory)
            {
                Console.WriteLine(bmi);
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bmiCalculator = new BMICalculator<double>();

            while (true)
            {
                string x = """
                    Choose 1 , 2 or 3 :-

                    1 - Calculate BMI

                    2 - View BMI History

                    3 - Exit


                    Thanks for using our BMI Calculater
                    
                    """;
                Console.WriteLine(x);

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CalculateBMI(bmiCalculator);
                        break;
                    case "2":
                        ViewBMIHistory(bmiCalculator);
                        break;
                    case "3":
                        Console.WriteLine("see you next time");
                        return;
                    default:
                        Console.WriteLine("we need to learn some facts about numbers do we ?");
                        break;
                }
            }
        }

        static void CalculateBMI(BMICalculator<double> bmiCalculator)
        {
            while (true)
            {
                Console.WriteLine("Enter height in meters or feet: ");
                if (!double.TryParse(Console.ReadLine(), out double height) || height <= 0)
                {
                    Console.WriteLine("Wrong height please enter a correct value ");
                    continue;
                }

                Console.WriteLine("Enter weight in kilograms: ");
                if (!double.TryParse(Console.ReadLine(), out double weight) || weight <= 0)
                {
                    Console.WriteLine("Wrong weight please enter a correct numeric value ");
                    continue;
                }

                Console.WriteLine("Enter unit system meter or feet (m/f): ");
                string unit = Console.ReadLine().ToLower();
                if (unit != "m" && unit != "f")
                {
                    Console.WriteLine("Wrong input Use meter or feet");
                    continue;
                }

                double bmi = bmiCalculator.CalculateBMI(height, weight, unit);
                string category = bmiCalculator.GetBMICategory(bmi);

                Console.WriteLine($"Calculated BMI: {bmi:F2}");
                Console.WriteLine($"BMI Category: {category}");

                Console.WriteLine("Do you want to calculate another BMI? (y/n): ");
                string ContinueCalc = Console.ReadLine().ToLower();
                if (ContinueCalc == "n")
                {
                    break;
                }
            }
        }

        static void ViewBMIHistory(BMICalculator<double> bmiCalculator)
        {
            if (bmiCalculator.ShowPreviousBMICalculations())
            {
                Console.WriteLine("Do you want to calculate a new BMI or exit? (y/n): ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    CalculateBMI(bmiCalculator);
                }
                else if (choice != "n")
                {
                    Console.WriteLine("please focus we need y   or   n");
                }
            }
        }
    }
}