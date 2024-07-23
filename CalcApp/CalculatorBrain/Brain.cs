namespace CalculatorBrain;

public class Brain
{
    public double CurrentValue { get; private set; } = 0;

    public double Add(double value) 
    {
        CurrentValue += value;
        return CurrentValue;
    }

    public double Subtract(double value)
    {
        CurrentValue -= value;
        return CurrentValue;
    }

    public double Divide(double value)
    {
        if (value == 0) throw new DivideByZeroException("Cannot divide by zero");
            
        CurrentValue /= value;
        return CurrentValue;
    }

    public double Multiply(double value)
    {
        CurrentValue *= value;
        return CurrentValue;
    }

    public double Exponentiate(double value)
    {
        CurrentValue = Math.Pow(CurrentValue, value);
        return CurrentValue;
    }

    public double Negate()
    {
        CurrentValue = -CurrentValue;
        return CurrentValue;
    }

    public double Sqrt()
    {
        if (CurrentValue < 0) throw new ArgumentException("Cannot take the square root of a negative number");
            
        CurrentValue = Math.Sqrt(CurrentValue);
        return CurrentValue;
    }

    public double Square()
    {
        CurrentValue = Math.Pow(CurrentValue, 2);
        return CurrentValue;
    }

    public double AbsValue()
    {
        CurrentValue = Math.Abs(CurrentValue);
        return CurrentValue;
    }
        
    public void Reset()
    {
        CurrentValue = 0;
    }
}