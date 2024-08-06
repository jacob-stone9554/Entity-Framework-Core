using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstEFCoreApp
{
    public class Commands
    {
        public static void ListAll()
        {
            /*
             * Create the application's DbContext through which all database accesses are done.
             */
            using (var db = new AppDbContext())
            {
                foreach (var book in
                    /*
                     * load all books that are present in the database. AsNoTracking indicates that this is read-only access
                     * the .Include causes the author information to be loaded with each book.
                     */
                    db.Books.AsNoTracking()
                    .Include(book => book.Author))
                {
                    var webUrl = book.Author.WebUrl == null ? "- no web URL given -" : book.Author.WebUrl;
                    Console.WriteLine(
                        $"{book.Title} by {book.Author.Name}");
                    Console.WriteLine(
                        $"Published on {book.PublishedOn:dd-MMM-yyyy}       {webUrl}");
                }
            }
        }
    }
}
