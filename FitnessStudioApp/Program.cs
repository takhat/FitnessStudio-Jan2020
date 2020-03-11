using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace FitnessStudioApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************");
            Console.WriteLine("Welcome to my Fitness Studio!");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create a new Customer Account");
                Console.WriteLine("2. Purchase a class pass");
                Console.WriteLine("3. Purchase a membership");
                Console.WriteLine("4. View all transactions");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option) //"switch" is a simplified form of an if statement for an equality comparison
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the fitness studio!");
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Customer name: ");
                            var customerName = Console.ReadLine();
                            Console.Write("Email Address: ");
                            var emailAddress = Console.ReadLine();
                            Console.Write("Customer Phone: ");
                            var customerPhone = string.Format("{0:(###)###-####}",Console.ReadLine());
                            Console.Write("Enter Date of Birth in MM/DD/YYYY format: ");
                            var dateOfBirth = DateTime.Parse(Console.ReadLine());
                            var customerAccount = FitnessStudio.CreateAccount(customerName, emailAddress, customerPhone, dateOfBirth);
                            Console.WriteLine($"ID: {customerAccount.CustomerID}, " +
                                $"CN: {customerAccount.CustomerName}, " +
                                $"DOB: {customerAccount.DateofBirth:d}, " +
                                $"JD:{customerAccount.CustomerSince:d}, " +
                                $"PH: {customerAccount.CustomerPhone}," +
                                $"EID: {customerAccount.EmailAddress}");
                        }
                        catch (System.IO.IOException)
                        {
                            Console.WriteLine("Please enter string");
                        }
                        catch (OutOfMemoryException omex)
                        {
                            Console.WriteLine(omex.Message);
                        }
                        catch (ArgumentNullException anx)
                        {
                            Console.WriteLine(anx.Message);
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine(ax.Message);
                        }
                        catch (FormatException fx)
                        {
                            Console.WriteLine(fx.Message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Try again!");
                        }

                        break;

                    case "2":

                        Console.WriteLine("Select a class: ");
                        //converting enum into array below then printing values
                        var classNames = Enum.GetNames(typeof(TitleofClass));

                        for (var i = 0; i < classNames.Length; i++)
                        {
                            Console.WriteLine($"{i}.{classNames[i]}");
                        }
                        var className = Enum.Parse<TitleofClass>(Console.ReadLine());
                        Console.WriteLine("Select a ClassPass option: ");
                        var classpassOptions = Enum.GetNames(typeof(ClassPassOption));
                        
                        var classPassAmounts = (int[])Enum.GetValues(typeof(ClassPassOption));
                        for (var n = 0; n < classPassAmounts.Length; n++)
                        {
                            Console.WriteLine($"{n}.{classpassOptions[n]} - ${classPassAmounts[n]}");
                        }
                        var classPass = Enum.Parse<ClassPassOption>(Console.ReadLine());
                        var classPassAmount = classPassAmounts[Convert.ToInt32(classPass)];
                        FitnessStudio.BuyAClassPass(customerID, className, classPass);
                        FitnessStudio.createTransaction(classPassAmount, customerID, TypeOfTransaction.ClassPass);
                        Console.WriteLine($"Enjoy your {classpassOptions[Convert.ToInt32(classPass)]} worth ${classPassAmount} for {classNames[Convert.ToInt32(className)]}");
                        
                        
                        
                        /*Console.WriteLine("Would you like to add another Class?: ");
                        var yesNo = Enum.GetNames(typeof(YesNo));
                        for (var i=0; i<yesNo.Length; i++)
                        {
                            Console.WriteLine($"{i}.{yesNo[i]}");
                        }
                        var yesNoOption = Enum.Parse<YesNo>(Console.ReadLine());
                        Console.WriteLine(yesNoOption);
                        if (yesNoOption == 0)
                        {
                            for (var index = 0; index < classNames.Length; index++)
                            {
                                Console.WriteLine($"{index}.{classNames[index]}");
                            }
                            var className1 = Enum.Parse<TitleofClass>(Console.ReadLine());
                            Console.WriteLine("Select a ClassPass option: ");

                            for (var index1 = 0; index1 < classpassOptions.Length; index1++)
                            {
                                Console.WriteLine($"{index1}.{classpassOptions[index1]} - ${classPassAmounts[index1]}");
                            }
                            var classPass1 = Enum.Parse<ClassPassOption>(Console.ReadLine());
                            var classPassAmount1 = classPassAmounts[Convert.ToInt32(classPass1)];
                            FitnessStudio.BuyAClassPass(customerID, className1, classPass1);
                            FitnessStudio.createTransaction(classPassAmount1, customerID, TypeOfTransaction.ClassPass);
                            Console.WriteLine($"Enjoy your {classpassOptions[Convert.ToInt32(classPass1)]} worth ${classPassAmount1} for {classNames[Convert.ToInt32(className1)]}");
                        }
                        else return;*/
                        break;
                    case "3":
                        Console.Write("CustomerID: ");
                        var customeriD = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Select a membership type: ");
                        //converting enum into array below then printing values
                        var membershipTypes = Enum.GetNames(typeof(MembershipOption));
                        var membershipAmounts = (int[])Enum.GetValues(typeof(MembershipOption));
                        for (var i = 0; i < membershipAmounts.Length; i++)
                        {
                            Console.WriteLine($"{i}.{membershipTypes[i]} - ${membershipAmounts[i]}");
                        }
                        var memberType = Enum.Parse<MembershipOption>(Console.ReadLine());
                        var membershipAmount = membershipAmounts[Convert.ToInt32(memberType)];
                        FitnessStudio.BuyAMembership(customeriD, memberType);
                        FitnessStudio.createTransaction(membershipAmount, customeriD, TypeOfTransaction.Membership);
                        Console.WriteLine($"Thank you for buying {membershipTypes[Convert.ToInt32(memberType)]} for ${membershipAmount}");
                        break;
                    case "4":
                        Console.Write("Enter your Customer ID: ");
                        var custID = Convert.ToInt32(Console.ReadLine());
                        var transactions = FitnessStudio.GetAllTransactionsByCustomerID(custID);
                        foreach(var transaction in transactions)
                        {
                            Console.WriteLine($"TiD: {transaction.TransactionID}, TT:{transaction.TransactionType}," +
                                $"TD: {transaction.TransactionDate}, TA: {transaction.Amount}");
                        }
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again!");
                        break;
                }

            }

        }

    }
}

