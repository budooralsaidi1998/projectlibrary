using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Transactions;
using Systemlibrary.models;
using Systemlibrary.Reposertity;

namespace Systemlibrary
{
    public class Program
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
                     
                            Console.WriteLine("enter the name : ");
                            string name=Console.ReadLine();

                            Console.WriteLine("enter the email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("enter the password");
                            int pass=int.Parse(Console.ReadLine());

                            var adminreg = new adming { admin_name = name, admin_email = email, admin_password = pass };
                            AdminRepo.Add(adminreg);
                            Console.WriteLine("Success Added");
                            Console.WriteLine("");
                            Console.ReadLine();

                        


                            break;
                        case "2":
                        static void loginAdmin(AdminRepo adminRepo,bookRepo book )
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
                                    menuAdmin(adminRepo,book);
                                }
                            }



                        }
                        loginAdmin(AdminRepo,bookRepo);


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
                        static void userLogin(userRepo userrepo, bookRepo bookrepo)
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
                                    UserMenu(userrepo, bookrepo);
                                }
                            }



                        }
                        userLogin(userRepo , bookRepo );
                        break;
                        case "5":
                        
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            


            static void menuAdmin(AdminRepo adminprocess, bookRepo bookRepo) {
             
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
                            
                            bookmenu(bookRepo);
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

            static void UserMenu(userRepo userr,bookRepo bookrepo)
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

                        

                            GetBook(bookrepo);



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


            static void bookmenu(bookRepo addbook)
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

                           //static void AddbOOK(bookRepo addbook)
                           // {
                               Console.WriteLine(" add the new book : ");
                                Console.Write(" Name book : ");
                                string namebook = Console.ReadLine();
                               
                                Console.Write(" borrow book  : ");
                               int borrowbook  = int.Parse(Console.ReadLine());

                                Console.Write(" author  book : ");
                                string author = Console.ReadLine();

                                Console.Write(" copies book : ");  
                                int  numcopis  =int.Parse(Console.ReadLine());
                                

                                Console.Write(" price  book : ");

                                double price = double.Parse(Console.ReadLine());

                                Console.Write("enter the category id : ");
                                int id = int.Parse(Console.ReadLine());
                                  var book = new book { namebook=namebook , copies_number=borrowbook, author=author,borrowcopies=numcopis,price_book=price,categoryid=id };
                                  addbook.Add(book);
                                  Console.WriteLine("book added successfully!");
                                
                                


                            //}

                            //AddbOOK(bookRepo);
                            
                           
                            break;
                        case "2":
                         
                                Console.Write("enter the name you want to search : ");
                                string name = Console.ReadLine();

                                book getbookbyname =addbook.GetByName(name);

                                if(getbookbyname != null)
                                {
                                Console.WriteLine($"id book : {getbookbyname.bookid}" +
                                                   $"the name book : {getbookbyname.namebook}\t" +
                                                   $" the author : {getbookbyname.author}");
                                }
                              
                            




                            break;
                        case "3":
                            static void UpdateBook(bookRepo bookrepo)
                            {

                                GetBook(bookrepo);
                                Console.WriteLine("enter the name of book : ");
                                string bookname = Console.ReadLine();
                               
                                book  booknameupdated = bookrepo.GetByName(bookname);
                                if(booknameupdated != null)
                                {
                                    Console.Write("Enter new author name: ");
                                  string author = Console.ReadLine();

                                    booknameupdated.author = author;
                                    bookrepo.Update();                                 
                                }
                               
                            }
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
            static void GetBook(bookRepo bookrepo)
            {
                var getbook = bookrepo.GetAll();
                Console.WriteLine(" Book details:");
                foreach (var book in getbook)
                {
                    Console.WriteLine($"book name : {book.namebook}\t" +
                                      $" book author : {book.author} \t" +
                                      $"book category : {book.category}\t" +
                                      $"book borrow: {book.borrowcopies}\t" +
                                      $"book number of copies: {book.copies_number}");
                }
            }
        }

    }

    }

