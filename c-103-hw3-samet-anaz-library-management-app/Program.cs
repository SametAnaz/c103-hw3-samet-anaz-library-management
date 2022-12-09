using ai;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Menu
{
    class Program
    {



        static void Main(string[] args)
        {


            List<Book> books = new List<Book>();
            string filePath = "library.dat";



            // Ask the user to enter their password
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();



            // Check if the username is correct
            if (password == "admin")
            {
                Console.WriteLine("Login successful!");

                MenuScreen(books, filePath);
            }
            else
            {

                Console.WriteLine("Login failed. Invalid password.");

                Main(args);
            }

            Console.Clear();
            // Redirect user to menu screen



            // Create a new List<Book> to store the books in the library
            

            // Check if the .dat file exists
            
            if (!File.Exists(filePath))
            {
                // Create a new empty .dat file
                FileStream fileStream = File.Create(filePath);
                fileStream.Close();
            }

            // Call the AddBooks() function and pass the filePath as a parameter
            AddBooks(books, filePath);


        }

        static void MenuScreen(List<Book> books, string filePath)
        {

            // Set the initial selection to the first option
            int mainChoice = 1;



            while (true)
            {
                Thread.Sleep(50);


                Console.Clear();
                Console.CursorVisible = false;

                Console.WriteLine("//////////////////////  LİBRARY MANAGEMENT  //////////////////////");

                // Listing Menus

                Console.WriteLine();
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("1. Add Books");
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("2. Edit Books");
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("3. Search Books");
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("4. List Books");
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("5. Exit");

                if (mainChoice == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 3);
                    Console.Write("1. Add Books");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(0, 3);
                    Console.Write("1. Add Books");
                }

                Console.WriteLine();

                if (mainChoice == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 4);
                    Console.Write("2. Edit Books");
                    Console.ResetColor();
                }

                else
                {
                    Console.SetCursorPosition(0, 4);
                    Console.Write("2. Edit Books");
                }

                Console.WriteLine();

                if (mainChoice == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 5);
                    Console.Write("3. Search Books");
                    Console.ResetColor();

                }
                else
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("3. Search Books");
                }
                Console.WriteLine();

                if (mainChoice == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 6);
                    Console.Write("4. List Books");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(0, 6);
                    Console.Write("4. List Books");
                }
                Console.WriteLine();

                if (mainChoice == 5)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 7);
                    Console.Write("5. Exit");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(0, 7);
                    Console.Write("5. Exit");
                }
                Console.WriteLine();

                // Check for user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.Escape)
                    {
                        MenuScreen(books, filePath);

                    }


                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        // Move the selection up
                        mainChoice--;
                        if (mainChoice < 1)
                        {
                            mainChoice = 5;
                        }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        // Move the selection down
                        mainChoice++;
                        if (mainChoice > 5)
                        {
                            mainChoice = 1;
                        }
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        // Handle the selected option





                        switch (mainChoice)
                        {
                            case 1:
                                AddBooks(books, filePath);
                                break;
                            case 2:
                                EditBooks();
                                break;
                            case 3:
                                SearchBooks();
                                break;
                            case 4:
                                ListBooks();
                                break;
                            case 5:
                                Exit(); 
                                break;


                        }





                        Console.ReadLine();

                    }



                }

            }

        }


        public static void AddBooks(List<Book> books, string filePath)
        {
            while (true)
            {


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.Escape)
                    {
                        MenuScreen(books, filePath);

                    }
                    
                    else
                    {
                        Console.Clear();
                        // Get the book details from the user
                        Console.Write("Enter the book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter the book ID:");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter the book author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter the book year: ");
                        int year = int.Parse(Console.ReadLine());

                        // Create a new book object with the entered details
                        Book book = new Book()
                        {
                            Title = title,
                            Author = author,
                            Year = year,
                            ID = id
                        };

                        // Add the book to the list of books
                        books.Add(book);

                        // Serialize and save the book to the .dat file
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        using (FileStream fileStream = File.Open(filePath, FileMode.Open))
                        {
                            binaryFormatter.Serialize(fileStream, book);
                        }



                        MenuScreen(books, filePath);   




                    }
                    


                }
            }

        }



        static void EditBooks()
        {
            while (true)
            {


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.Escape)
                    {
                        

                    }
                    else
                    {
                        Console.Clear();
                        string EditBooks;
                        Console.WriteLine("Null");
                        EditBooks = Console.ReadLine();

                    }


                }
            }

        }


        static void SearchBooks()
        {
            while (true)
            {


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.Escape)
                    {
                       

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Book ID:");



                    }


                }
            }

        }




        static void ListBooks()
        {
            while (true)
            {


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.Escape)
                    {
                        

                    }

                    else
                    {
                        Console.Clear();
                        

                    }



                }
            }

        }






        static void Exit()
        {
            while (true)
            {


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        
                    }


                }
            }

        }




    }

    

}