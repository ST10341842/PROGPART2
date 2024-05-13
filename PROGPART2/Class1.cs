//ST10341842 Mvinjelwa Buhle 
//ProgPOE part 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgPOEPart1;
using System.Collections.Generic;

namespace ProgPOEPart1;


internal class RecipeManager
{
    // List to store multiple recipe objects
    private List<Recipe> recipes = new List<Recipe>();

    public RecipeManager()
    {
        InitializeBasicRecipes(); // Initialize basic recipes upon instantiation
    }
    // Method to add predefined recipes to the list
    private void InitializeBasicRecipes()
    {
        // Braai Chicken recipe
        recipes.Add(new Recipe
        {
            DishName = "Braai Chicken",
            Ingredients = new string[] { "Chicken pieces", "BBQ spice", "Lemon juice" },
            Quantities = new double[] { 4, 2, 50 },
            Units = new string[] { "Pieces", "Tbsp", "ml" },
            Steps = new string[]
            {
                "Rub the chicken pieces with BBQ spice.",
                "Squeeze lemon juice over the chicken.",
                "Let it marinate for 30 minutes.",
                "Braai over medium coals for 45 minutes."
            }
        });
        // Additional basic recipes can be added here
    }
    //Main menu to handle user interaction with the application
    public void MainMenu()
    {
        bool appRunning = true;
        while (appRunning)
        {
            Console.WriteLine("Choose an option: \n1. View Recipes \n2. Add New Recipe \n3. Scale Recipe \n4. Clear Recipe Data \n5. Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ViewRecipes();
                    break;
                case "2":
                    AddRecipe();
                    break;
                case "3":
                    ScaleRecipe();
                    break;
                case "4":
                    ClearRecipeData();
                    break;
                case "5":
                    appRunning = false; // Exit the loop and terminate the application
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
                    break;
            }
        }
    }
    // Method to display all stored recipes
    private void ViewRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        // Sort recipes alphabetically by dish name
        var sortedRecipes = recipes.OrderBy(r => r.DishName).ToList();

        // Display the list of recipes with corresponding numbers for selection
        for (int i = 0; i < sortedRecipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedRecipes[i].DishName}");
        }

        // Prompt the user to enter the number of the recipe they want to view
        Console.WriteLine("Enter the number of the recipe you want to view:");
        int choice = Convert.ToInt32(Console.ReadLine());

        // Check if the chosen number is valid
        if (choice >= 1 && choice <= sortedRecipes.Count)
        {
            Recipe chosenRecipe = sortedRecipes[choice - 1];
            chosenRecipe.DisplayRecipe();
            Console.WriteLine("------------------------------------------------");
        }
        else
        {
            Console.WriteLine("Invalid recipe selection.");
        }
    }
    // method to add a new recipe 
    private void AddRecipe()
    {
        Recipe recipe = new Recipe();
        Console.WriteLine("Enter the name of the dish:");
        recipe.DishName = Console.ReadLine();
        recipe.EnterDetails();
        recipes.Add(recipe);
        Console.WriteLine("Recipe added successfully.");

        // Check if total calories exceed 300 and notify the user
        if (recipe.CalculateTotalCalories() > 300)
        {
            Console.WriteLine("Warning: This recipe exceeds 300 calories!");
        }
    }
    // Method to scale the quantities in a recipe
    private void ScaleRecipe()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available to scale.");
            return;
        }

        Console.WriteLine("Select a recipe to scale:");
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].DishName}");
        }
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < recipes.Count)
        {
            Console.WriteLine("Enter scale factor (e.g., 0.5 for half, 2 for double, etc.):");
            double scaleFactor = Convert.ToDouble(Console.ReadLine());
            recipes[choice].ScaleRecipe(scaleFactor);
            recipes[choice].DisplayRecipe();
        }
        else
        {
            Console.WriteLine("Invalid recipe selection.");
        }
    }
    //Method to clear Data from selected recipe 
    private void ClearRecipeData()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available to clear.");
            return;
        }

        Console.WriteLine("Select a recipe to clear Data from:");
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].DishName}");
        }
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < recipes.Count)
        {
            recipes[choice].ClearRecipeData();
            Console.WriteLine("Recipe data cleared successfully.");
        }
        else
        {
            Console.WriteLine("Invalid recipe selection.");
        }
    }
}