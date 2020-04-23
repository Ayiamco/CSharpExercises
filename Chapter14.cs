using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Chapter14
    {
        public class Book
        //Chapter 14 Question20 
        {
            // class feilds:  title, author, publisher, release date and ISBN-number.
            public string title;
            public string author;
            public string publisher;
            public DateTime release_date;
            public string ISBN_number;

            //constructor
            public Book(string book_title, string book_author = "N/A", string book_publisher = "N/A", string book_release_date = "N/A", string book_ISBN_number = "N/A")
            {
                this.title = book_title;
                this.author = book_author;
                this.publisher = book_publisher;
                this.ISBN_number = book_ISBN_number;
                if (book_release_date == "N/A")
                {
                    this.release_date = new DateTime();
                }
                else
                {
                    try
                    {
                        this.release_date = DateTime.Parse(book_release_date);
                    }
                    catch (FormatException)
                    {
                        this.release_date = new DateTime();
                    }
                }



            }
        }

       public class Library
        //Chapter 14 Question 20
        {
            public static int book_count = 0;
            public Dictionary<string, string> book_register_title = new Dictionary<string, string>();
            public Dictionary<string, string> book_register_authors = new Dictionary<string, string>();
            public Library()
            {

            }

            public string AddBook(Book new_book)
            {
                string author = new_book.author;
                string release_date = Convert.ToString(new_book.release_date);
                string ISBN_number = new_book.ISBN_number;
                string storage_string = "";
                storage_string = storage_string + "author:" + author + ";";
                storage_string = storage_string + "release_date:" + release_date + ";";
                storage_string = storage_string + "ISBN_numner" + ISBN_number;
                book_register_title.Add(new_book.title, storage_string);
                if (book_register_authors.ContainsKey(new_book.author))
                {
                    string old_values = book_register_authors[new_book.author];
                    book_register_authors.Remove(new_book.author);
                    book_register_authors.Add(new_book.author, old_values + new_book.title + ",");
                }
                else
                {
                    book_register_authors.Add(new_book.author, new_book.title + ",");
                }

                return storage_string;
            }

            public string BooksBy(string author)
            {
                try
                {
                    //returns all the books from particular author
                    return book_register_authors[author];
                }
                catch
                {
                    //no entry of author
                    return "No books found for author";
                }
            }

            public string GetInfo(string book_title)
            {
                //returns author,publisher,release_date and isbn number of book
                return book_register_title[book_title];

            }



        }
    }
}

   
