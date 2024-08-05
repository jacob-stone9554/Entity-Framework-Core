using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstEFCoreApp
{
    public class Author
    {
        /*
         * This field holds the primary key of the Author row in the DB. Note that the foreign key in the Book class has the same name.
         */
        public int AuthorId { get; set; } 

        /*
         * These two properties are mapped to table columns.
         */
        public string Name { get; set; }
        public string WebUrl { get; set; }
    }
}
