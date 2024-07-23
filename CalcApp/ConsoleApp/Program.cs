using CalculatorBrain;
using MenuSystem;

namespace ConsoleApp;

class Program
{
    private static readonly Brain Brain = new Brain();
        
    static void Main(string[] args)
    {
        Console.Clear();
            
        Console.ForegroundColor = ConsoleColor.Green;
        var mainMenu = new Menu(ReturnCurrentDisplayValue, "Calculator Main", EMenuLevel.Root);
        mainMenu.AddMenuItems(new List<MenuItem>()
        {
            new MenuItem("A", "Binary operations", SubmenuBinary),
            new MenuItem("S", "Unary operations", SubmenuUnary),
            new MenuItem("R", "Reset", Reset)
        });
            
        mainMenu.Run();
    }

    public static string ReturnCurrentDisplayValue()
    {
        return "Current Value: " + Brain.CurrentValue;
    }

    public static string SubmenuBinary()
    {
        var menu = new Menu(ReturnCurrentDisplayValue, "Binary", EMenuLevel.First);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new MenuItem("+", "Add", Add),
            new MenuItem("-", "Subtract", Subtract),
            new MenuItem("/", "Divide", Divide),
            new MenuItem("*", "Multiply", Multiply),
            new MenuItem("P", "Power", Exponentiate)

        });
        return menu.Run();
    }
        
    public static string SubmenuUnary()
    {
        var menu = new Menu(ReturnCurrentDisplayValue, "Unary", EMenuLevel.First);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new MenuItem("N", "Negate", Negate),
            new MenuItem("S", "Square root", Sqrt),
            new MenuItem("Q", "Square", Square),
            new MenuItem("A", "Absolute value", AbsValue)
        });
        return menu.Run();
    }
        
    public static string Reset()
    {
        Brain.Reset();
            
        Console.WriteLine("Calculator reset.");
            
        return "";
    }

    public static string Add()
    {
        // CalculatorCurrentDisplay
        Console.WriteLine("Current value: " + Brain.CurrentValue);
        Console.Write("Enter value to add: ");
        var value = GetInputValue();
            
        Brain.Add(value);
            
        return "";
    }

    public static string Subtract()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
        Console.Write("Enter value to subtract: ");
        var value = GetInputValue();
            
        Brain.Subtract(value);
            
        return "";
    }

    public static string Divide()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
        Console.Write("Enter value to divide by: ");
        var value = GetInputValue();
            
        if (value == 0)
        {
            Console.WriteLine("Cannot divide by 0");
            return "";
        }
            
        Brain.Divide(value);
            
        return "";
    }

    public static string Multiply()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
        Console.Write("Enter value to multiply: ");
        var value = GetInputValue();
            
        Brain.Multiply(value);
            
        return "";
    }

    public static string Exponentiate()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
        Console.Write("Enter power: ");
        var value = GetInputValue();
            
        Brain.Exponentiate(value);
            
        return "";
    }

    public static string Negate()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
            
        Brain.Negate();
            
        return "";
    }

    public static string Sqrt()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
            
        try
        {
            Brain.Sqrt();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
            
        return "";
    }

    public static string Square()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
            
        Brain.Square();
            
        return "";
    }

    public static string AbsValue()
    {
        Console.WriteLine("Current value: " + Brain.CurrentValue);
            
        Brain.AbsValue();
            
        return "";
    }

    private static double GetInputValue()
    {
        var input = Console.ReadLine()?.Trim();
        double.TryParse(input, out var value);
        return value;
    }
}