# intro to ef core

- understanding the structure of an ef core app
- accessing and updating a database with ef core
- exploring real world ef core applications
- deciding when it's appropriate to use ef core

EF Core is an object-relational mapper, or ORM. Put simply, an ORM is a library that connect object-oriented software to a relational database.

EF Core is multiplatform (Windows, Linux, macOS)

With EF Core, the right libraries, and right approach you can have quick development of database access code

EF Core maps aspects of a database to C# code. The mappings are as follows
	Table -> .NET Class
	Table Columns -> Class Properties/Fields
	Rows -> Elements in .NET Collections (Like a List<>)
	Primary Keys -> unique row -> a unique class instance
	Foreign Keys -> Reference to another class
	SQL (ex. WHERE) -> .NET LINQ (ex. Where(x => ...))

There are some downsides to using an orm:
	- object-relational impedance mismatch -> relational DBs and .NET classes aren't built the same. A primary key should be unique, but by default every .NET class is considered unique. 
	- SQL abstraction -> sometimes an ORM will do it's job too well, and hides the SQL 'magically'. This can mean you don't know exactly what queries are being executed, you could be using very inefficient queries.

EF Core does have ways to handle/work with NoSQL DBs as well.

See MyFirstEFCoreApp in the parent directory of this file.

In the first app, there are two tables:
	- Books: BookId (PK), Title, Description, PublishedOn, AuthorId  (FK)
	- Author: AuthorId (PK), Name, WebUrl

Before writing any database access code, you need to do two things:
	- Write the classes you want EF Core to map
	- Write the DbContext, the primary class that is used to configure/access the DB