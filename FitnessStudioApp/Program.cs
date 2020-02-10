using System;

namespace FitnessStudioApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = FitnessStudio.CreateAccount("New Customer", "123 St NE Redmond 98052", "555-55-5555", TitleofClass.FlexFit, TypeOfMembership.MonthlyFlexFitPass);
            Console.WriteLine($"AN:{myAccount.CustomerID},ADD: {myAccount.CustomerAddress}, PH: {myAccount.CustomerPhone}, Title: {myAccount.ClassTitle} ");
        }
    }
}
