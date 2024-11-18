using Azure.Identity;
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
          //  var bookRepo = new bookRepo(dbContext);
            var borrowRepo = new borrowRepo(dbContext);
          //  var categoryRepo = new categoryRepo(dbContext);
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
                        var bookrepo = new bookRepo(new ApplicationContext());
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
                        loginAdmin(AdminRepo, bookrepo);


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
                        var bookrepoo = new bookRepo(new ApplicationContext());
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
                                    UserMenu();
                                }
                            }



                        }
                        userLogin(userRepo , bookrepoo);
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
                var bookrepoo = new bookRepo(new ApplicationContext());
                var userre = new userRepo(new ApplicationContext());
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
                            UserMenu();
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
                var categoryRepository = new categoryRepo(new ApplicationContext());
                var borrowRepository = new borrowRepo(new ApplicationContext());
                var bookRepository = new bookRepo(new ApplicationContext());
                var userRepository = new userRepo(new ApplicationContext());
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

                        

                            GetBook(bookRepository);
                            Console.ReadLine();


                            break;
                        case "2":

                            static void viewcategory(categoryRepo cate, bookRepo bookRepo)
                            {
                                var categoryget = cate.GetAll();
                                foreach (var CAT in categoryget)
                                {
                                    if (categoryget != null)
                                    {
                                        Console.WriteLine($"Category ID: {CAT.CId}");
                                        Console.WriteLine($"Category Name: {CAT.cat_name}");
                                        Console.WriteLine($"Number of Books: {CAT.number_categery}");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Category not found.");
                                    }
                                }
                                    Console.WriteLine($"Books in this Category:");
                                    Console.Write("Enter Category ID to view its books: ");
                                    int categoryId = int.Parse(Console.ReadLine());

                                    var category = cate.GetByID(categoryId);

                                    // Get books in this category by categoryid
                                    var booksInCategory = bookRepo.GetAll().Where(b => b.categoryid == category.CId).ToList();

                                    if (booksInCategory.Any())
                                    {
                                        foreach (var book in booksInCategory)
                                        {
                                            Console.WriteLine($"- Book Name: {book.namebook}, Author: {book.author}, Copies Available: {book.borrowcopies}");
                                            Console.ReadLine() ;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No books available in this category.");
                                    }



                                }
                            
                            viewcategory(categoryRepository,bookRepository);
                            break;
                        case "3":
                             static void BorrowBook(borrowRepo borrowRepo, bookRepo bookRepo, userRepo userRepo)
                            {
                                Console.Write("Enter User ID: ");
                                int userId = int.Parse(Console.ReadLine());
                                var user = userRepo.GetByID(userId);  // Assuming you have a userRepo to manage users

                                if (user == null)
                                {
                                    Console.WriteLine("User not found.");
                                    return;
                                }

                                Console.Write("Enter Book ID to borrow: ");
                                int bookId = int.Parse(Console.ReadLine());
                                var book = bookRepo.GetByID(bookId);

                                if (book != null && book.borrowcopies > 0)
                                {
                                    // Create borrowing record
                                    var borrowing = new borrowing
                                    {
                                        userid = userId,
                                        bookid = bookId,
                                        borrow_date = DateTime.Now,
                                        return_date= 
                                        isreturn = false  // Mark as not returned
                                    };

                                    borrowRepo.Add(borrowing);

                                    // Decrease the borrowcopies count in the book
                                    book.borrowcopies--;
                                    bookRepo.Update(book.bookid, book.namebook, book.author, book.borrowcopies);  // Ensure the update method is implemented

                                    Console.WriteLine("Book borrowed successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Book not available or out of stock.");
                                }
                            }
                            BorrowBook(borrowRepository, bookRepository, userRepository);
                            break;
                        case "4":
                             static void ReturnBook(borrowRepo borrowRepo, bookRepo bookRepo)
                            {
                                Console.Write("Enter User ID: ");
                                int userId = int.Parse(Console.ReadLine());

                                Console.Write("Enter Book ID to return: ");
                                int bookId = int.Parse(Console.ReadLine());

                                var borrowingRecord = borrowRepo.GetAll().FirstOrDefault(b => b.userid  == userId && b.bookid == bookId && !b.isreturn);

                                if (borrowingRecord != null)
                                {
                                    // Mark as returned
                                    borrowingRecord.isreturn = true;
                                    borrowingRecord.return_date = DateTime.Now;

                                    // Update the borrow record in the database
                                    borrowRepo.Updaterecode(borrowingRecord);

                                    // Increase the borrowcopies in the book
                                    var book = bookRepo.GetByID(bookId);
                                    if (book != null)
                                    {
                                        book.borrowcopies++;
                                        bookRepo.Update(book.bookid, book.namebook, book.author, book.borrowcopies);  // Ensure the update method is implemented
                                    }

                                    Console.WriteLine("Book returned successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("No active borrowing record found for this book.");
                                }
                            }
                            ReturnBook(borrowRepository, bookRepository);
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
                var bookrepo = new bookRepo(new ApplicationContext());

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

                           static void AddbOOK(bookRepo addbook)
                            {
                               Console.WriteLine(" add the new book : ");
                                Console.Write(" Name book : ");
                                string namebook = Console.ReadLine();
                               
                                Console.Write(" borrow pirod  : ");
                               int borrowbook  = int.Parse(Console.ReadLine());

                                Console.Write(" author  book : ");
                                string author = Console.ReadLine();

                                Console.Write(" copies book : ");  
                                int  numcopis  =int.Parse(Console.ReadLine());
                                

                                Console.Write(" price  book : ");

                                double price = double.Parse(Console.ReadLine());

                                Console.Write("enter the category id : ");
                                int id = int.Parse(Console.ReadLine());

                                  var book = new book { namebook=namebook ,borrowcopies=numcopis , author=author,borrowpireod=borrowbook,price_book=price,categoryid=id };
                                  addbook.Add(book);
                                  Console.WriteLine("book added successfully!");
                                
                                


                            }

                            AddbOOK(bookrepo);
                            
                           
                            break;
                        case "2":
                         static void getbook(bookRepo addbook)
                            {


                                Console.Write("enter the name you want to search : ");
                                string name = Console.ReadLine();

                                book getbookbyname = addbook.GetByName(name);

                                if (getbookbyname != null)
                                {
                                    Console.WriteLine($"id book : {getbookbyname.bookid}" +
                                                       $"the name book : {getbookbyname.namebook}\t" +
                                                       $" the author : {getbookbyname.author}");
                                    Console.WriteLine("");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("not found book ");
                                }




                            }
                            getbook(bookrepo);

                            break;
                        case "3":
                          

                                GetBook(bookrepo);
                            
                            static void updatebook(bookRepo addbook)
                            {


                                Console.Write("Enter the ID of the book you want to update: ");
                                if (int.TryParse(Console.ReadLine(), out int bookId))
                                {
                                    // Fetch the book by ID
                                    var bookToUpdate = addbook.GetByID(bookId);

                                    if (bookToUpdate != null)
                                    {
                                        // Display current book details
                                        Console.WriteLine($"Current Name: {bookToUpdate.namebook}");
                                        Console.WriteLine($"Current Author: {bookToUpdate.author}");

                                        // Ask for new values for name and author
                                        Console.Write("Enter new name for the book: ");
                                        string newName = Console.ReadLine();

                                        Console.Write("Enter new author name: ");
                                        string newAuthor = Console.ReadLine();

                                        // Update the book with new name and author
                                        addbook.Update(bookId, newName, newAuthor);

                                        Console.WriteLine("Book updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No book found with that ID.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                }

                            }
                            updatebook(bookrepo);

                            break;
                        case "4":

                           
                            static void deletebook(bookRepo addbook)
                            {


                                Console.Write("Enter the ID of the book you want to delete: ");
                                if (int.TryParse(Console.ReadLine(), out int book_Id))
                                {
                                    var bookToDelete = addbook.GetByID(book_Id);

                                    if (bookToDelete != null)
                                    {
                                        addbook.Delete(book_Id);
                                        Console.WriteLine("Book deleted successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No book found with that ID.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                }
                            }
                            deletebook(bookrepo);
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


                var categoryRepository = new categoryRepo(new ApplicationContext());
               
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
                             static void AddCategory(categoryRepo repo)
                            {
                                Console.Write("Enter the category name: ");
                                string catName = Console.ReadLine();

                                Console.Write("Enter the number of categories: ");
                                int numberCategory = int.Parse(Console.ReadLine());

                                var newCategory = new category
                                {
                                    cat_name = catName,
                                    number_categery = numberCategory
                                };

                                repo.Add(newCategory);
                                Console.WriteLine("Category added successfully.");
                            }
                            AddCategory(categoryRepository);
                            break;
                        case "2":



                             static void GetCategoryByName(categoryRepo repo)
                            {
                                Console.Write("Enter the category name to search: ");
                                string catName = Console.ReadLine();

                                var category = repo.GetByName(catName);

                                if (category != null)
                                {
                                    Console.WriteLine($"Category name : {category.cat_name}, Number of Categories: {category.number_categery}");
                                }
                                else
                                {
                                    Console.WriteLine("Category not found.");
                                }
                            }
                            GetCategoryByName(categoryRepository);

                            break;
                        case "3":
                             static void UpdateCategory(categoryRepo repo)
                            {
                                Console.Write("Enter the ID of the category to update: ");
                                int categoryId = int.Parse(Console.ReadLine());

                                Console.Write("Enter new category name: ");
                                string newCatName = Console.ReadLine();

                                Console.Write("Enter new number of categories: ");
                                int newCategoryNumber = int.Parse(Console.ReadLine());

                                repo.Update(categoryId, newCatName, newCategoryNumber);
                                Console.WriteLine("Category updated successfully.");
                            }
                            UpdateCategory(categoryRepository);

                            break;
                        case "4":
                             static void DeleteCategory(categoryRepo repo)
                            {
                                Console.Write("Enter the ID of the category to delete: ");
                                int categoryId = int.Parse(Console.ReadLine());

                                repo.Delete(categoryId);
                                Console.WriteLine("Category deleted successfully.");
                            }
                            DeleteCategory(categoryRepository);


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
                    Console.WriteLine($"id book : {book.bookid}\t"+
                                        $"book name : {book.namebook}\t" +
                                      $" book author : {book.author} \t" +
                                      $"book category : {book.categoryid}\t" +
                                      $"book borrow: {book.borrowcopies}\t" +
                                      $"book number of copies: {book.borrowpireod}");
                }
            }
        }

    }

    }

