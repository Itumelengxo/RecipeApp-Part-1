using System;

namespace RecipeApplication
{
    internal class Program
    {
        private static Recipe recipe = new Recipe();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                int option = GetUserOption();
                ProcessOption(option);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1 - Enter recipe detail");
            Console.WriteLine("2 - Display full recipe");
            Console.WriteLine("3 - Scale recipe");
            Console.WriteLine("4 - Reset quantities");
            Console.WriteLine("5 - Clear data");
        }

        private static int GetUserOption()
        {
            Console.WriteLine("Enter your choice:");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
            return option;
        }

        private static void ProcessOption(int option)
        {
            switch (option)
            {
                case 1:
                    recipe.EnterRecipeDetails();
                    break;
                case 2:
                    recipe.DisplayFullRecipe();
                    break;
                case 3:
                    recipe.ScaleRecipe();
                    break;
                case 4:
                    recipe.ResetQuantities();
                    break;
                case 5:
                    recipe.ClearData();
                    break;
            }
        }
    }

    internal class Recipe
    {
        private string[] IngreName;
        private int[] IngreQty;
        private string[] IngreUnitOM;
        private string[] Step;
        private int[] StepNum;

        public Recipe()
        {
            IngreName = new string[100];
            IngreQty = new int[100];
            IngreUnitOM = new string[100];
            Step = new string[100];
            StepNum = new int[100];
        }

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter number of ingredients:");
            int ingreNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingreNum; i++)
            {
                Console.WriteLine("Enter Ingredient Name:");
                IngreName[i] = Console.ReadLine();

                Console.WriteLine("Enter ingredient quantity:");
                IngreQty[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter unit of measurement:");
                IngreUnitOM[i] = Console.ReadLine();

                Console.WriteLine("Enter number of steps:");
                StepNum[i] = int.Parse(Console.ReadLine());

                for (int j = 0; j < StepNum[i]; j++)
                {
                    Console.WriteLine("Enter step description:");
                    Step[j] = Console.ReadLine();
                }
            }
        }

        public void DisplayFullRecipe()
        {
            Console.WriteLine("Full Recipe:");
            Console.WriteLine("___________________________\n");

            for (int i = 0; i < IngreName.Length; i++)
            {
                if (IngreName[i] == null)
                    break;

                Console.WriteLine($"Number of ingredient: {i + 1}");
                Console.WriteLine($"Name of ingredient: {IngreName[i]}");
                Console.WriteLine($"Ingredient quantity: {IngreQty[i]}");
                Console.WriteLine($"Ingredient unit of measurement: {IngreUnitOM[i]}");
                Console.WriteLine($"Number of steps: {StepNum[i]}");

                for (int j = 0; j < StepNum[i]; j++)
                {
                    Console.WriteLine($"Step {j + 1} description: {Step[j]}");
                }

                Console.WriteLine();
            }
        }

        public void ScaleRecipe()
        {
            Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < IngreName.Length; i++)
            {
                if (IngreName[i] == null)
                    break;

                IngreQty[i] = (int)(IngreQty[i] * factor);
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < IngreName.Length; i++)
            {
                if (IngreName[i] == null)
                    break;

                IngreQty[i] /= 2; // Resetting to half of the original quantity
            }

            Console.WriteLine("Quantities reset to half of original values.");
        }

        public void ClearData()
        {
            Array.Clear(IngreName, 0, IngreName.Length);
            Array.Clear(IngreQty, 0, IngreQty.Length);
            Array.Clear(IngreUnitOM, 0, IngreUnitOM.Length);
            Array.Clear(Step, 0, Step.Length);
            Array.Clear(StepNum, 0, StepNum.Length);

            Console.WriteLine("All data cleared successfully.");
        }
    }
}
