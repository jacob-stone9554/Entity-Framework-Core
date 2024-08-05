using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstEFCoreApp
{
    /*
     * Note that EF Core maps .NET Classes to DB tables
     */
    public class Book
    {
        /*
         * A class that will be mapped to a table needs a primary key.
         * Using this naming convention (the first field, BookId) tells EF Core this is the primary key
         */
        public int BookId { get; set; }

        /*
         * These properties three properties are mapped to table columns.
         */
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        
        /*
         * The AuthorId foreign key is used in the database to link a row in the books table to a row in the author table
         */
        public int AuthorId { get; set; }

        /*
         * The Author property is an EF Core navigational property.
         * EF Core uses this on a save to see whether the Book has an Author class attached. If so, it sets the foreign key, AuthorId.
         */
        public Author Author { get; set; }

        /*
         * Upon loading a Book class, the method Include will fill this property with the Author class that's linked to this Book class by using the foreign key,
         * AuthorId.
         */

    }
}
