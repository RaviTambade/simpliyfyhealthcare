# Entity Framework Code-First approach

To apply the **Entity Framework Code-First approach** for a `Product` entity using **SQL Server** in an ASP.NET MVC application, you need to follow a series of steps. Below is a step-by-step guide on how to set up the Entity Framework Code-First approach for your `Product` entity:

### Steps to Use Entity Framework Code-First with SQL Server

#### 1. **Install Entity Framework NuGet Package**
First, make sure you have Entity Framework installed in your project. If it’s not already installed, you can add it via NuGet.

- Open **NuGet Package Manager** in Visual Studio.
- Search for `EntityFramework` and install it, or use the **Package Manager Console** to run the following command:

```bash
Install-Package EntityFramework
```

#### 2. **Create the Product Entity Class**
Define a `Product` class that will be your model. This class will represent a table in your SQL Server database.

Create a new class `Product.cs` inside the `Models` folder (or create a `Models` folder if it doesn't exist).

```csharp
using System.ComponentModel.DataAnnotations;

namespace YourApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Product name (required)

        public decimal Price { get; set; } // Product price

        public int Stock { get; set; } // Product stock quantity

        public string Description { get; set; } // Product description
    }
}
```

- The `ProductId` property is marked as the primary key by convention. Entity Framework recognizes properties named `Id` or `[EntityName]Id` as primary keys by default.
- The `[Required]` and `[StringLength]` attributes are data annotations for validation.

#### 3. **Create the DbContext Class**
Create a `DbContext` class that will represent the session between your application and the database. It will manage the `Product` entity.

Create a new class `ApplicationDbContext.cs` inside the `Models` folder (or create a `Models` folder if it doesn't exist).

```csharp
using System.Data.Entity;

namespace YourApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") // The connection string name
        {
        }

        public DbSet<Product> Products { get; set; } // Represents the Product table
    }
}
```

In the constructor, `"DefaultConnection"` is the name of the connection string that will be used to connect to the database. You will define this connection string in the `Web.config` file.

#### 4. **Add the Connection String in Web.config**
In the `Web.config` file, add a connection string to your SQL Server database:

```xml
<connectionStrings>
    <add name="DefaultConnection" connectionString="Server=YOUR_SERVER_NAME;Database=YourDatabaseName;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Replace:
- `YOUR_SERVER_NAME` with the name of your SQL Server instance (e.g., `localhost` or `.\SQLEXPRESS`).
- `YourDatabaseName` with the desired database name.

#### 5. **Enable Migrations (Optional)**
Entity Framework migrations allow you to evolve your database schema as your model changes. To enable migrations, follow these steps:

- Open the **Package Manager Console** in Visual Studio (`Tools` -> `NuGet Package Manager` -> `Package Manager Console`).
- Run the following commands:

```bash
Enable-Migrations
```

This command creates a `Migrations` folder in your project.

#### 6. **Create Initial Migration (Database Schema)**
Now, create a migration to generate the database schema based on your model.

Run the following command in the **Package Manager Console**:

```bash
Add-Migration InitialCreate
```

This command generates a migration file inside the `Migrations` folder, which contains the necessary SQL to create the database schema.

#### 7. **Update the Database**
Now, apply the migration to your SQL Server database using the following command:

```bash
Update-Database
```

This will create the `Products` table in the database based on your `Product` model.

#### 8. **Use the DbContext in Your Controllers**
You can now use the `ApplicationDbContext` to interact with the database in your controllers.

For example, create a `ProductsController` to handle CRUD operations on `Product` entities.

```csharp
using System.Linq;
using System.Web.Mvc;
using YourApp.Models;

namespace YourApp.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); // DbContext instance

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.ToList();  // Retrieve all products
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Price,Stock,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);  // Add product to DbContext
                db.SaveChanges();          // Save changes to database
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);  // Find product by ID
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Price,Stock,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;  // Modify the entity
                db.SaveChanges();  // Save changes to database
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);  // Find product by ID
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);  // Find product by ID
            db.Products.Remove(product);  // Remove product from DbContext
            db.SaveChanges();  // Save changes to database
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();  // Dispose DbContext
            }
            base.Dispose(disposing);
        }
    }
}
```

### 9. **Run the Application**
Now, when you run the application, you should be able to interact with the `Product` entity using the CRUD operations defined in the controller. The data will be stored in your SQL Server database.

### Conclusion:
By following these steps, you've successfully implemented the Entity Framework Code-First approach for a `Product` entity in your ASP.NET MVC application with SQL Server. You've defined your entity, created a `DbContext` for database interaction, added migrations, and performed CRUD operations.