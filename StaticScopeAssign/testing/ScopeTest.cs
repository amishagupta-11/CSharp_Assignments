using System;
using ScopeTesting;
/// <summary>
/// creating another class in same solution but different project to check scope of static variables
/// </summary>
public class ScopeTest
{
    //declaring and initializing global variable
    int n = 100;  
    public static void Main()
    {
        //modifying the static values defined in VariableScopeCheck class 
        VariableScopeCheck.Type="SCIENCE";
        int result = VariableScopeCheck.Sum(24, 25);
        //displaying the results obtained
        Console.WriteLine(result);
        Console.WriteLine(VariableScopeCheck.Type);
    }
}
