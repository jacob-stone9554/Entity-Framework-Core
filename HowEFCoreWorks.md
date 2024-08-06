# Entity Framework Core - Under the hood

While you can use and write EF Core application code without knowing how it works, it is worthwile to understand what is happening behind the scenes.

## Modeling the Database

Before you can do ANYTHING with the database, EF Core must go through the process of modeling the database. This 'modeling' is EF Core's way of figuring out what the database needs to look like by looking at the existing classes and any EF Core configuration data that might be present. The model that is produced will be used with ALL database access.

The modeling process occurs the first time you create the application's DbContext. (in our case, it is AppDbContext. It has one property, DbSet<Book> books.) There are five steps in the modeling process that occur:
1. Ef Core looks at all DbSet<> properties that are present. From these, it defines the names of the tables from the names of the DbSets
2. EF Core looks through all the classes that are referred to in DbSet<>, and looks at the properties of these classes to determine column names, data types, etc.
3. EF Core looks for any classes that the DbSet<> class refers to. (In our case, the book class refers to the Author class.) Any classes that are found are scanned similarly to step 2, with the name of the class as the name of the table, and the types/names of the columns and so on.
4. EF Core runs the virtual method OnModelCreating inside of the application's DbContext. In our example we did not do this (as it wasn't necessary) so that method is not present in our code (it is inherited from DbContext). If necessary, you can Override this method and provide it with extra information via a fluent API for further configuration.
5. EF Core creates an internal model of the database using all of the information it has gathered.

*Note* -> Learning LINQ will be essential to you. EF Core uses LINQ commands for database accesses.   