using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstEFCoreApp
{
    public class AppDbContext : DbContext
    {
        /*
         * The database connection string holds info about the DB
         *      - how to find the database server
         *      - the name of the database
         *      - authorization access to the database
         */
        private const string connectionString =
            @"Server=(localdb)\mssqllocaldb;
              Database=MyFirstEfCoreDb;
              Trusted_Connection=True";

        /*
         * In a console app, you configure EF Core's database options by overriding the OnConfiguring method.
         * In this particular case, you are telling it that you are using a SQL Server DB by using the .UseSqlServer() method.
         */
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString);
        }

        /*
         * By creating a property called Books of type DbSet<Book>, you are telling EF Core that there's a database table
         * named Books, and it has the columns and keys as found in the Book class
         */
        public DbSet<Book> Books { get; set; }

        /*
         * Note that our database should have a property called Author, but we didn't specify a DbSet<> for it here.
         * We did that on purpose, as EF Core will find that table using the navigational property of type Author in the Book class.
         */
    }
}
