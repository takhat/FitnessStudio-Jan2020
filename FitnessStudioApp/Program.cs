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
                            Console.Write("10 digit Customer Phone: ");
                            var customerPhone = Convert.ToInt64(Console.ReadLine()).ToString("(###)###-####");
                            Console.Write("Enter Date of Birth in MM/DD/YYYY format: ");
                            var dateOfBirth = DateTime.Parse(Console.ReadLine());
                            var customerAccount = FitnessStudio.CreateAccount(customerName, emailAddress, customerPhone, dateOfBirth);
                            Console.WriteLine($"ID: {customerAccount.CustomerID}, " +
                                    $"CN: {customerAccount.CustomerName}, " +
                                    $"DOB: {customerAccount.DateofBirth:d}, " +
                                    $"JD: {customerAccount.CustomerSince:d}, " +
                                    $"PH: {customerAccount.CustomerPhone}, " +
                                    $"EID: {customerAccount.EmailAddress}");
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Please enter a value");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid Value.Try again!");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine(ax.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format. Try again!");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Something went wrong. Try again!");
                        }
                     break;

                    case "2":
                        try
                        {
                            Console.Write("Enter Customer ID: ");
                            var customerID = Convert.ToInt32(Console.ReadLine());
                        
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
                            /*FitnessStudio.createTransaction(classPassAmount, customerID, TypeOfTransaction.ClassPass);*/
                            Console.WriteLine($"Enjoy your {classpassOptions[Convert.ToInt32(classPass)]} worth ${classPassAmount} for {classNames[Convert.ToInt32(className)]}");
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Please enter a value");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid customer ID or class or class pass. Try again");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid customer ID or class or class pass. Try again!");
                        }
                        catch (OutOfMemoryException)
                        {
                            Console.WriteLine("Invalid value. Try again");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something went wrong. Try again!");
                        }

                        break;
                    case "3":
                        try
                        {
                            Console.Write("Enter Customer ID: ");
                            var customerID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Select a membership type: ");
                            //converting enum into array below then printing values
                            var membershipTypes = Enum.GetNames(typeof(MembershipOption));
                            var membershipAmounts = (int[])Enum.GetValues(typeof(MembershipOption));
                            for (var i = 0; i < membershipAmounts.Length; i++)
                            {
                                Console.WriteLine($"{i}.{membershipTypes[i]} - ${membershipAmounts[i]}");
                            }
                            var memberType = Enum.Parse<MembershipOption>(Console.ReadLine());
                            var membershipAmount = membershipAmounts[Convert.ToInt32(memberType)];
                            FitnessStudio.BuyAMembership(customerID, memberType);
                            /*FitnessStudio.createTransaction(membershipAmount, customerID, TypeOfTransaction.Membership);*/
                            Console.WriteLine($"Thank you for buying {membershipTypes[Convert.ToInt32(memberType)]} for ${membershipAmount}");
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Please enter a value");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid customer ID or membership. Try again");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid customer ID or membership. Try again!");
                        }
                        catch (OutOfMemoryException)
                        {
                            Console.WriteLine("Invalid value. Try again");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something went wrong. Try again!");
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Enter Customer ID: ");
                            var customerID = Convert.ToInt32(Console.ReadLine());
                            var transactions = FitnessStudio.GetAllTransactionsByCustomerID(customerID);
                            foreach (var transaction in transactions)
                            {
                                Console.WriteLine($"TiD: {transaction.TransactionID}, " +
                                    $"TT: {transaction.TransactionType}, " +
                                    $"TD: {transaction.TransactionDate}, " +
                                    $"TA: ${transaction.Amount}");
                            }
                        }
                        catch(ArgumentNullException)
                        {
                            Console.WriteLine("Please enter a value");
                        }
                        catch(ArgumentException)
                        {
                            Console.WriteLine("Invalid customer ID. Try again!");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Something went wrong. Try again!");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again!");
                        break;
                }

            }

        }

    }

}

