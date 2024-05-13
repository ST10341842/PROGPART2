//ST10341842 Mvinjelwa Buhle 
//ProgPOE part 1
namespace ProgPOEPart1;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(
"*********************************************************************************************************************" + "\n" +
"                                                   Welcome To One Stop Recipe" + "\n" +
"*********************************************************************************************************************");
        RecipeManager manager = new RecipeManager();
        manager.MainMenu(); // call the main menu method to start the applicatiion's main loop
    }
}
