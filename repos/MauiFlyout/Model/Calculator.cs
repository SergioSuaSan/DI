namespace MauiFlyout.Model;

public static class Calculator
{
    /// <summary>
    /// Method to calculate the result of a mathematical operation
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="mathOperator"></param>
    /// <returns></returns>
    public static double Calculate(double value1, double value2, string mathOperator)
    {
        double result = 0;

        switch (mathOperator)
        {
            case "÷":
                result = value1 / value2;
                break;
            case "×":
                result = value1 * value2;
                break;
            case "+":
                result = value1 + value2;
                break;
            case "-":
                result = value1 - value2;
                break;
        }

        return result;
    }
}

/// <summary>
/// Extension method to format a double value as a string
/// </summary>
public static class DoubleExtensions
{
    public static string ToTrimmedString(this double target, string decimalFormat)
    {
        string strValue = target.ToString(decimalFormat); //Get the stock string

        //If there is a decimal point present
        if (strValue.Contains("."))
        {
            //Remove all trailing zeros
            strValue = strValue.TrimEnd('0');

            //If all we are left with is a decimal point
            if (strValue.EndsWith(".")) //then remove it
                strValue = strValue.TrimEnd('.');
        }

        return strValue;
    }
}
