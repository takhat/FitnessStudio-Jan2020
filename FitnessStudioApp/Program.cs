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
                        Console.Write("Customer name: ");
                        var customerName = Console.ReadLine();
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Customer Phone: ");
                        var customerPhone = Console.ReadLine();
                        Console.Write("Date of Birth: ");
                        var dateOfBirth = Console.ReadLine();
                        var customerAccount = FitnessStudio.CreateAccount(customerName,emailAddress,customerPhone,dateOfBirth);
                        Console.WriteLine($"Thank you for joining us. Your Customer ID is: {customerAccount.CustomerID}");
                        break;

                    case "2":
                        Console.WriteLine("CustomerID: ");
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
                        for (var n = 0; n < classpassOptions.Length; n++)
                        {
                            Console.WriteLine($"{n}.{classpassOptions[n]}");
                        }
                        var classPass = Enum.Parse<ClassPassOption>(Console.ReadLine());
                        
                        foreach(int i in Enum.GetValues(typeof(ClassPassOption)))
                        {
                            Console.WriteLine($"{i}");
                        }
                       switch(Convert.ToInt32(classPass))
                        {
                            case 0: FitnessStudio.BuyAClassPass(customerID, className, ClassPassOption.FreeTrial);
                                FitnessStudio.createTransaction(0, customerID, TypeOfTransaction.ClassPass);
                                Console.WriteLine($"Enjoy your Free Trial Pass for {classNames[Convert.ToInt32(className)]}");
                                break;
                            case 1:
                                FitnessStudio.BuyAClassPass(customerID, className, ClassPassOption.SingleClassPass);
                                FitnessStudio.createTransaction(20, customerID, TypeOfTransaction.ClassPass);
                                Console.WriteLine($"Enjoy your Single Class Pass for {classNames[Convert.ToInt32(className)]}");
                                break;
                            case 2: FitnessStudio.BuyAClassPass(customerID, className, ClassPassOption.TenClassPass);
                                FitnessStudio.createTransaction(180, customerID, TypeOfTransaction.ClassPass);
                                Console.WriteLine($"Enjoy your Ten Class Pass for {classNames[Convert.ToInt32(className)]}");
                                break;
                            case 3: FitnessStudio.BuyAClassPass(customerID, className, ClassPassOption.TwentyClassPass);
                                FitnessStudio.createTransaction(350, customerID, TypeOfTransaction.ClassPass);
                                Console.WriteLine($"Enjoy your Twenty Class Pass for {classNames[Convert.ToInt32(className)]}");
                                break;
                        } 
                        /*Console.WriteLine("Would you like to add another Class?: ");
                        var yesNo = Enum.GetNames(typeof(YesNo));
                        for (var i=0; i<yesNo.Length; i++)
                        {
                            Console.WriteLine($"{i}.{yesNo[i]}");
                        }
                        var yesNoOption = Enum.Parse<YesNo>(Console.ReadLine());
                        Console.WriteLine(yesNoOption);
                        while (true)
                        {
                            for (var i = 0; i < classNames.Length; i++)
                            {
                                Console.WriteLine($"{i}.{classNames[i]}");
                            }
                            var className = Enum.Parse<TitleofClass>(Console.ReadLine());
                            Console.WriteLine("Select a ClassPass option: ");
                            var classpassOptions = Enum.GetNames(typeof(ClassPassOption));
                            for (var n = 0; n < classpassOptions.Length; n++)
                            {
                                Console.WriteLine($"{n}.{classpassOptions[n]}");
                            }
                        }*/


                        break;
                    case "3":
                        Console.WriteLine("CustomerID: ");
                        var customeriD = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Select a membership type: ");
                        //converting enum into array below then printing values
                        var membershipTypes = Enum.GetNames(typeof(MembershipOption));

                        for (var i = 0; i < membershipTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{membershipTypes[i]}");
                        }
                        var memberType = Enum.Parse<MembershipOption>(Console.ReadLine());
                        FitnessStudio.BuyAMembership(customeriD, memberType);
                        FitnessStudio.createTransaction(0, customeriD, TypeOfTransaction.Membership);
                        break;
                    case "4":
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

