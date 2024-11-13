using Microsoft.Identity.Client;
using System.Reflection;
using Systemlibrary.models;
using Systemlibrary.Reposertity;

namespace Systemlibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var dbContext = new ApplicationContext();

            // Create repositories
            var AdminRepo = new AdminRepo(dbContext);
            var bookRepo = new bookRepo(dbContext);
            var borrowRepo = new borrowRepo(dbContext);
            var categoryRepo = new categoryRepo(dbContext);
            var userRepo = new userRepo(dbContext);


           
                bool running = true;
                while (running)
                {
                Console.Clear();
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1.register admin ");
                    Console.WriteLine("2.login admin ");
                    Console.WriteLine("3.register user  ");
                    Console.WriteLine("4.login user ");
                     Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                        static void RegisterAdmin(AdminRepo adminRepo)

                        {
                            Console.WriteLine("enter the name : ");
                            string name=Console.ReadLine();

                            Console.WriteLine("enter the email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("enter the password");
                            int pass=int.Parse(Console.ReadLine());

                            var adminreg = new adming { admin_name = name, admin_email = email, admin_password = pass };
                            adminRepo.Add(adminreg);
                            Console.WriteLine("Success Added");
                            Console.WriteLine("");
                            Console.ReadLine();

                        }

                        RegisterAdmin(AdminRepo);

                            break;
                        case "2":
                        static void loginAdmin(AdminRepo adminRepo)
                        {


                            Console.WriteLine("enter the email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("enter the password");
                            int pass = int.Parse(Console.ReadLine());

                            var adminlogin = adminRepo.GetAllAdmin();
                            foreach(var admin in  adminlogin)
                            {
                                if(email == admin.admin_email || pass == admin.admin_password)
                                {
                                    menuAdmin();
                                }
                            }



                        }
                        loginAdmin(AdminRepo);


                        break;
                        case "3":
                        static void RegisterUser(userRepo userrepo)

                        {
                            Console.WriteLine("enter the name : ");
                            string name = Console.ReadLine();

                            Console.WriteLine("enter the email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("enter the password");
                            string pass = Console.ReadLine();
                            Console.WriteLine("Enter gender (Male, Female):");
                            string input = Console.ReadLine();

                            // Try to parse the input string into a Gender enum value
                            if (Enum.TryParse(input, true, out GenderType gender))
                            {
                                var usering = new user { userName = name, userEmail = email, Password = pass, RGender = gender };
                                userrepo.Add(usering);
                                Console.WriteLine("Success Added");
                                Console.WriteLine("");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter Male, Female");
                            }
                        }

                        RegisterUser(userRepo);




                        break;
                        case "4":
                        static void userLogin(userRepo userrepo)
                        {


                            Console.WriteLine("enter the email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("enter the password");
                            string pass =Console.ReadLine();

                            var userloging = userrepo.GetAll();
                            foreach (var loginuser in userloging )
                            {
                                if (email == loginuser.userEmail || pass == loginuser.Password)
                                {
                                    UserMenu();
                                }
                            }



                        }
                        userLogin(userRepo);
                        break;
                        case "5":
                        
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            


            static void menuAdmin() {
                bool running = true;
                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1.BOOKS PROCESS");
                    Console.WriteLine("2.CATEGORY PROCESS ");
                    Console.WriteLine("3.USER PROCESS ");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            bookmenu();
                            break;
                        case "2":
                            Categorymenu();
                            break;
                        case "3":
                            User();
                            break;
                        case "4":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            static void UserMenu()
            {
                bool running = true;
                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1.View Book");
                    Console.WriteLine("2.view Category");
                    Console.WriteLine("3.Borrow book ");
                    Console.WriteLine("3.Return book ");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                         
                            break;
                        case "2":
                          
                            break;
                        case "3":
                         
                            break;
                        case "4":
                       
                            break;

                        case "5":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }


            static void bookmenu()
            {
                bool running = true;
                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. add new book");
                    Console.WriteLine("2. get book by name");
                    Console.WriteLine("3.update book ");
                    Console.WriteLine("4. delete book ");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":

                            
                           
                            break;
                        case "2":
                         
                            break;
                        case "3":
                          
                            break;
                        case "4":
                           
                            break;
                        case "5":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            static void Categorymenu()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. add new Category");
                    Console.WriteLine("2. get Category by name");
                    Console.WriteLine("3.update Category ");
                    Console.WriteLine("4. delete Category ");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":

                            break;
                        case "2":

                            break;
                        case "3":

                            break;
                        case "4":

                            break;
                        case "5":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            static void User()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. add new user");
                    Console.WriteLine("2. get user by name");
                    Console.WriteLine("3.update user ");
                    Console.WriteLine("4. delete user ");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":

                            break;
                        case "2":

                            break;
                        case "3":

                            break;
                        case "4":

                            break;
                        case "5":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

    }

    }

