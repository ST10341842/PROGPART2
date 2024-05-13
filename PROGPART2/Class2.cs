//ST10341842 Mvinjelwa Buhle 
//ProgPOE part 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPOEPart1;

public class Recipe : RecipeBase
{
    //Field to store the original quantities before scaling
    private double[] originalQuantities;

    // Method for entering recipe details via user input
    public void EnterDetails()
    {
        Console.WriteLine("Enter the number of ingredients:");
        int numIngredients = int.Parse(Console.ReadLine());

        Ingredients = new string[numIngredients];
        Quantities = new double[numIngredients];
        Units = new string[numIngredients];
        Calories = new double[numIngredients]; // calories for each ingredient
        FoodGroups = new string[numIngredients]; // food group for each ingredient 


        // Define the food groups
        string[] foodGroups = new string[]
        {
        "Starchy foods",
        "Vegetables and fruits",
        "Dry beans, peas, lentils and soya",
        "Chicken, fish, meat and eggs",
        "Milk and dairy products",
        "Fats and oil",
        "Water"
        };
        // Loop to input each ingredient's details
        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter ingredient {i + 1} name:");
            Ingredients[i] = Console.ReadLine();

            Console.WriteLine($"Enter quantity for {Ingredients[i]}:");
            Quantities[i] = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter unit for {Ingredients[i]}:");
            Units[i] = Console.ReadLine();

            Console.WriteLine($"Enter calories for {Ingredients[i]}:"); // New: Prompt for calories
            Calories[i] = double.Parse(Console.ReadLine());

            // Prompt for food group and inform about available options
            Console.WriteLine($"Select the food group for {Ingredients[i]} by entering the corresponding number:");
            for (int j = 0; j < foodGroups.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {foodGroups[j]}");
            }
            int foodGroupChoice;
            bool validChoice;
            do
            {
                Console.Write("Enter your choice: ");
                validChoice = int.TryParse(Console.ReadLine(), out foodGroupChoice);
                if (!validChoice || foodGroupChoice < 1 || foodGroupChoice > foodGroups.Length)
                {
                    Console.WriteLine("Invalid choice. Please enter a number corresponding to the food group.");
                }
            } while (!validChoice || foodGroupChoice < 1 || foodGroupChoice > foodGroups.Length);

            FoodGroups[i] = foodGroups[foodGroupChoice - 1];
        }
        Console.WriteLine("Enter the number of steps:");
        int numSteps = int.Parse(Console.ReadLine());

        Steps = new string[numSteps];

        // Loop to input each cooking step
        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            Steps[i] = Console.ReadLine();
        }
    }
    // Method to display the complete recipe
    public void DisplayRecipe()
    {
        Console.WriteLine($"Recipe for {DishName}:");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < Ingredients.Length; i++)
        {
            Console.WriteLine($"{Quantities[i]} {Units[i]} of {Ingredients[i]} - {Calories[i]} calories, Food Group: {FoodGroups[i]}"); //new change
        }
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < Steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i]}");
        }
        Console.WriteLine($"Total Calories: {CalculateTotalCalories()}"); // New: Display total calories
    }
    private double CalculateTotalCalories()
    {
        double totalCalories = 0;
        for (int i = 0; i < Ingredients.Length; i++)
        {
            totalCalories += Quantities[i] * Calories[i];
        }
        return totalCalories;

    }

    // Method to scale the quantities of the ingredients
    public void ScaleRecipe(double factor)
    {
        if (originalQuantities == null)
        {
            originalQuantities = (double[])Quantities.Clone();
        }
        // Adjust each quantity by the scaling factor
        for (int i = 0; i < Quantities.Length; i++)
        {
            Quantities[i] = originalQuantities[i] * factor;
        }
    }
    // Method to reset quantities to their original values
    public void ResetQuantities()
    {
        if (originalQuantities != null)
        {
            Quantities = (double[])originalQuantities.Clone();
        }
    }
    // method to clear all recipe data to their origunal value
    public void ClearRecipeData()
    {
        DishName = string.Empty;
        Ingredients = new string[0];
        Quantities = new double[0];
        Units = new string[0];
        Steps = new string[0];
        Console.WriteLine("All recipe data has been cleared.");
    }
}






