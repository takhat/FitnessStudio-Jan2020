using System;

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
                Console.WriteLine("2. Sign up for a class");
                Console.WriteLine("3. Withdraw from a class");
                Console.WriteLine("4. View all transactions");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option) //"switch" is a simplified form of an if statement for an equlaity comparison
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the fitness studio!");
                        return;
                    case "1":
                        Console.Write("Customer name: ");
                        var customerName = Console.ReadLine();
                        Console.Write("Email Address: ");
                        var customerAddress = Console.ReadLine();
                        Console.Write("Customer Phone: ");
                        var customerPhone = Console.ReadLine();
                        Console.Write("Date of Birth: ");
                        var dateOfBirth = Console.ReadLine();
                        Console.WriteLine("Select a Membership type: ");
                        //converting enum into array below then printing values
                        var membershipTypes = Enum.GetNames(typeof(TypeOfMembership));
                        for (var i = 0; i < membershipTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {membershipTypes[i]}");
                        }
                        //var membershipType = (TypeOfMembership)Enum.Parse(typeof(TypeOfMembership),Console.ReadLine());

                        var membershipType = Enum.Parse<TypeOfMembership>(Console.ReadLine());
                        break;
                    case "2":
                        
                        

                        break;
                        
                    case "3":
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
