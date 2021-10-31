using System;
using System.Collections.Generic;

namespace miniräknare_inlämning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista för lagring av uträkningar.
            List<string> storeCalculations = new List<string>();

            // Variabel som sparar uträkningar i strängformat.
            string calculationResult;

            Console.WriteLine("***** Miniräknare *****");

            Console.Write("\nAnge ditt namn för att starta programmet: ");

            // Variabel som lagrar användarnamn.
            string userName = EnterName();

            Console.WriteLine("\nAnge två tal samt operatorn (+, -, *, /) för det räknesätt som önskas.");

            // Villkor för om programmet ska fortsätta.
            bool newCalculation = true;

            // Loop som pågår så länge programmet inte avslutas.
            do
            {
                Console.Write("\nTal 1: ");

                // Användarens två tal använder double så att decimaltal kan matas in. Char används för att välja operator (+, -, *, /).
                double userNumber1 = EnterNumber();

                //Console.Write("\nOperator: ");
                Console.Write("\n+ - * /: ");

                char userOperator = EnterOperator();

                Console.Write("\nTal 2: ");

                double userNumber2 = EnterNumber();

                // Uträkningsresultatet.
                calculationResult = Calculation(userOperator, userNumber1, userNumber2);

                // Skriver ut uträkningsresultatet.
                PrintResult(calculationResult);

                // Lägger till uträkningsresultatet i listan.
                AddResultToList(calculationResult);

                // Villkor för menyloopen nedan.
                bool menu = true;

                // Loop som ger användaren möjlighet att via en meny välja att göra en ny uträkning,
                // se tidigare uträkningar eller avsluta programmet.
                do
                {
                    // Skriver ut menyn.
                    PrintMenu();

                    // Återanvänder EnterNumber-metoden för menyvalet med en typkonvertering från double till int.
                    int menuChoice = (int)EnterNumber();

                    // Hur programmet ska fortsätta efter en uträkning. Båda looparnas villkor måste bestämmas. 
                    (menu, newCalculation) = ProgramChoice(menuChoice);

                } while (menu);

            } while (newCalculation);

            Console.WriteLine($"\nProgrammet avslutas för {userName}.");


            // Metoder.

            /// <summary>
            /// Läser in en textsträng från användaren.
            /// </summary>
            /// <returns>Den inmatade texten.</returns>
            string EnterName()
            {
                return Console.ReadLine();
            }

            /// <summary>
            /// Läser in och konverterar en textsträng till ett decimaltal.
            /// </summary>
            /// <returns>Den inmatade strängen i form av ett decimaltal.</returns>
            double EnterNumber()
            {
                return Convert.ToDouble(Console.ReadLine());
            }

            /// <summary>
            /// Läser in en textsträng och konverterar den till en char.
            /// </summary>
            /// <returns>Den inmatade strängen i form av en char.</returns>
            char EnterOperator()
            {
                return Convert.ToChar(Console.ReadLine());
            }

            /// <summary>
            /// Adderar två tal.
            /// </summary>
            /// <param name="num1">Det första talet.</param>
            /// <param name="num2">Det andra talet.</param>
            /// <returns>Resultatet av additionen.</returns>
            double Addition(double num1, double num2)
            {
                return num1 + num2;
            }

            /// <summary>
            /// Subtraherar två tal.
            /// </summary>
            /// <param name="num1">Det första talet.</param>
            /// <param name="num2">Det andra talet.</param>
            /// <returns>Resultatet av subtraktionen.</returns>
            double Subtraction(double num1, double num2)
            {
                return num1 - num2;
            }

            /// <summary>
            /// Multipicerar två tal.
            /// </summary>
            /// <param name="num1">Det första talet.</param>
            /// <param name="num2">Det andra talet.</param>
            /// <returns>Resultatet av multiplikationen</returns>
            double Multiplication(double num1, double num2)
            {
                return num1 * num2;
            }

            /// <summary>
            /// Dividerar två tal.
            /// </summary>
            /// <param name="num1">Det första talet.</param>
            /// <param name="num2">Det andra talet.</param>
            /// <returns>Resultatet av divisionen.</returns>
            double Division(double num1, double num2)
            {
                return num1 / num2;
            }

            ///<summary>
            /// Skapar en sträng av talen och uträkningsresultatet.
            /// </summary>
            /// <param name="userOp">Vald operator.</param>
            /// <param name="num1">Det första talet.</param>
            /// <param name="num2">Det andra talet.</param>
            /// <returns>Inmatade tal, operator och resultat som en sträng.</returns>
            string Calculation(char userOp, double num1, double num2)
            {
                string result;

                if (userOp == '+')
                {
                    result = $"\n{num1} + {num2} = {Addition(num1, num2)}";
                }
                else if (userOp == '-')
                {
                    result = $"\n{num1} - {num2} = {Subtraction(num1, num2)}";
                }
                else if (userOp == '*')
                {
                    result = $"\n{num1} * {num2} = {Multiplication(num1, num2)}";
                }
                else
                {
                    result = $"\n{num1} / {num2} = {Division(num1, num2)}";
                }

                return result;
            }

            /// <summary>
            /// Skriver ut resultatet av uträkningen.
            /// </summary>
            /// <param name="result">Inmatade tal, operator och resultat som en sträng.</param>
            void PrintResult(string result)
            {
                Console.WriteLine(result);
            }

            /// <summary>
            /// Lagrar uträkningen i strängformat i en lista.
            /// </summary>
            /// <param name="result">Inmatade tal, operator och resultat som en sträng.</param>
            void AddResultToList(string result)
            {
                storeCalculations.Add(result);
            }

            /// <summary>
            /// Skriver ut en meny.
            /// </summary>
            void PrintMenu()
            {
                Console.WriteLine("\nVälj mellan alternativ 1 - 3 för att fortsätta.");

                Console.WriteLine("\n1. Ny uträkning.");

                Console.WriteLine("\n2. Visa tidigare uträkningar");

                Console.WriteLine("\n3. Avsluta programmet.");

                Console.Write("\nDitt val: ");
            }

            /// <summary>
            /// Skriver ut alla tidigare uträkningar.
            /// </summary>
            /// <param name="results">Inmatade tal, operator och resultat som en sträng.</param>
            void PrintAllCalculations(List<string> results)
            {
                foreach (string calculation in results)
                {
                    Console.WriteLine(calculation);
                }
            }

            ///<summary>
            /// Avgör programmets fortsättning utifrån användarens val.
            /// </summary>
            /// <param name="choice">Valet i menyn.</param>
            /// <returns>Ett boolvärde för den inre menyloopen.</returns>
            /// <returns>Ett boolvärde för den yttre programloopen.</returns>
            (bool, bool) ProgramChoice(int choice)
            {
                bool innerLoop;
                bool outerLoop;

                if (choice == 1)
                {
                    innerLoop = false;
                    outerLoop = true;
                }
                else if (choice == 2)
                {
                    // Skriver ut tidigare uträkningar.
                    PrintAllCalculations(storeCalculations);

                    innerLoop = true;
                    outerLoop = true;
                }
                else
                {
                    innerLoop = false;
                    outerLoop = false;
                }

                return (innerLoop, outerLoop);
            }
        }
    }
}

