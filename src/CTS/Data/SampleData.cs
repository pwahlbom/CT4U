using CTS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CTS.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            //----------------------------------------------------------------------------------------------------
            // Here commences the template generate code
            // Had to put my data loading after the users are created as the Userid is need to create the first receipt
            //var db = serviceProvider.GetService<ApplicationDbContext>();
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            db.Database.EnsureCreated();

            // Ensure Philip (IsAdmin)
            var philip = await userManager.FindByNameAsync("philip@wahlbom.net");
            if (philip == null)
            {
                // create user
                philip = new ApplicationUser
                {
                    UserName = "philip@wahlbom.net",
                    Email = "philip@wahlbom.net"
                };
                await userManager.CreateAsync(philip, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(philip, new Claim("IsAdmin", "true"));
            }

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
                await userManager.AddClaimAsync(stephen, new Claim("IsEmployee", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(mike, new Claim("IsEmployee", "true"));
            }
            //----------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------
            // Below here  is where the custom sample data is loaded
            //var db = serviceProvider.GetService<ApplicationDbContext>();
            //await db.Database.EnsureCreatedAsync();

            //----------------------------------------------------------------------------------------------------
            // Go ahead and remove all our records so we can repopulate from scratch
            db.Products.RemoveRange(db.Products);
            db.Receipts.RemoveRange(db.Receipts);
            db.Items.RemoveRange(db.Items);
            db.SaveChanges();
            //var test = db.Receipts.Count();
            //----------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------
            // Load up the Products table
            if (!db.Products.Any())
            {
                db.Products.AddRange(
                    new Product { Name = "Mouthwash", MeasurementUnits = "ounces", Notes = "" },
                    new Product { Name = "Paper Towels", MeasurementUnits = "rolls", Notes = "" },
                    new Product { Name = "Milk", MeasurementUnits = "gallons", Notes = "How often do I REALLY need to go buy milk??!!" },
                    new Product { Name = "Sugar", MeasurementUnits = "pounds", Notes = "" },
                    new Product { Name = "Razor Cartridges", MeasurementUnits = "pieces", Notes = "" },
                    new Product { Name = "Liquid Laundry Detergent", MeasurementUnits = "loads", Notes = "" },
                    new Product { Name = "Ball Point Pens", MeasurementUnits = "pieces", Notes = "" },
                    new Product { Name = "Printer Paper", MeasurementUnits = "sheets", Notes = "I think we buy more paper than we realize" },
                    new Product { Name = "Coffee Beans", MeasurementUnits = "ounces", Notes = "Be sure to buy the French roast!" },
                    new Product { Name = "Beer", MeasurementUnits = "16oz units", Notes = "Whether cans or bottles, we're tracing beer by the 16oz unit" }
                );
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------
            // Load up the Receipts table
            // We need userid a few times so lets just store it in a variable
            //Philip = await userManager.FindByNameAsync("philip@wahlbom.net");
            var PhilipsId = philip.Id;
            //var PhilipsId = db.Users.FirstOrDefault(u => u.UserName == "philip@wahlbom.net").Id;

            if (!db.Receipts.Any())
            {
                db.Receipts.AddRange(
                    new Receipt { PurchaseDate = Convert.ToDateTime("5/14/2016"), ApplicationUserId = PhilipsId, Note = "Cupboard empty, HAD to go shopping!" },
                    new Receipt { PurchaseDate = Convert.ToDateTime("6/2/2016"), ApplicationUserId = PhilipsId, Note = "Cooked dinner for Susie, needed stuff" },
                    new Receipt { PurchaseDate = Convert.ToDateTime("7/21/2016"), ApplicationUserId = PhilipsId, Note = "Resupply" },
                    new Receipt { PurchaseDate = Convert.ToDateTime("8/9/2016"), ApplicationUserId = PhilipsId, Note = "Friends coming over tomorrrow" }
                );
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------
            // Load up the Items table
            // Lets go ahead and grab the three receipt IDs and 10 product IDs
            var ReceiptId1 = db.Receipts.FirstOrDefault(r => r.PurchaseDate == Convert.ToDateTime("5/14/2016")).Id;
            var ReceiptId2 = db.Receipts.FirstOrDefault(r => r.PurchaseDate == Convert.ToDateTime("6/2/2016")).Id;
            var ReceiptId3 = db.Receipts.FirstOrDefault(r => r.PurchaseDate == Convert.ToDateTime("7/21/2016")).Id;
            var ReceiptId4 = db.Receipts.FirstOrDefault(r => r.PurchaseDate == Convert.ToDateTime("8/9/2016")).Id;

            var ProductIdA = db.Products.FirstOrDefault(p => p.Name == "Mouthwash").Id;
            var ProductIdB = db.Products.FirstOrDefault(p => p.Name == "Paper Towels").Id;
            var ProductIdC = db.Products.FirstOrDefault(p => p.Name == "Milk").Id;
            var ProductIdD = db.Products.FirstOrDefault(p => p.Name == "Sugar").Id;
            var ProductIdE = db.Products.FirstOrDefault(p => p.Name == "Razor Cartridges").Id;
            var ProductIdF = db.Products.FirstOrDefault(p => p.Name == "Liquid Laundry Detergent").Id;
            var ProductIdG = db.Products.FirstOrDefault(p => p.Name == "Ball Point Pens").Id;
            var ProductIdH = db.Products.FirstOrDefault(p => p.Name == "Printer Paper").Id;
            var ProductIdI = db.Products.FirstOrDefault(p => p.Name == "Coffee Beans").Id;
            var ProductIdJ = db.Products.FirstOrDefault(p => p.Name == "Beer").Id;

            // Let's randomize the UnitsPurchased
            Random rnd = new Random();

            // And finally add the many Items
            if (!db.Items.Any())
            {
                db.Items.AddRange(

                    // The first receipt
                    new Item { Id = 1, ReceiptId = ReceiptId1, ProductId = ProductIdA, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 2, ReceiptId = ReceiptId1, ProductId = ProductIdB, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 3, ReceiptId = ReceiptId1, ProductId = ProductIdC, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 4, ReceiptId = ReceiptId1, ProductId = ProductIdD, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 5, ReceiptId = ReceiptId1, ProductId = ProductIdE, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 6, ReceiptId = ReceiptId1, ProductId = ProductIdF, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 7, ReceiptId = ReceiptId1, ProductId = ProductIdG, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 8, ReceiptId = ReceiptId1, ProductId = ProductIdH, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 9, ReceiptId = ReceiptId1, ProductId = ProductIdI, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 10, ReceiptId = ReceiptId1, ProductId = ProductIdJ, UnitsPurchased = rnd.Next(1, 53) },

                    // The second receipt
                    new Item { Id = 11, ReceiptId = ReceiptId2, ProductId = ProductIdB, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 12, ReceiptId = ReceiptId2, ProductId = ProductIdC, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 13, ReceiptId = ReceiptId2, ProductId = ProductIdD, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 14, ReceiptId = ReceiptId2, ProductId = ProductIdE, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 15, ReceiptId = ReceiptId2, ProductId = ProductIdF, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 16, ReceiptId = ReceiptId2, ProductId = ProductIdG, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 17, ReceiptId = ReceiptId2, ProductId = ProductIdH, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 18, ReceiptId = ReceiptId2, ProductId = ProductIdI, UnitsPurchased = rnd.Next(1, 53) },

                    // The third receipt
                    new Item { Id = 19, ReceiptId = ReceiptId3, ProductId = ProductIdA, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 20, ReceiptId = ReceiptId3, ProductId = ProductIdB, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 21, ReceiptId = ReceiptId3, ProductId = ProductIdC, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 22, ReceiptId = ReceiptId3, ProductId = ProductIdD, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 23, ReceiptId = ReceiptId3, ProductId = ProductIdH, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 24, ReceiptId = ReceiptId3, ProductId = ProductIdI, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 25, ReceiptId = ReceiptId3, ProductId = ProductIdJ, UnitsPurchased = rnd.Next(1, 53) },

                    // The fourth receipt
                    new Item { Id = 26, ReceiptId = ReceiptId4, ProductId = ProductIdD, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 27, ReceiptId = ReceiptId4, ProductId = ProductIdE, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 28, ReceiptId = ReceiptId4, ProductId = ProductIdF, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 29, ReceiptId = ReceiptId4, ProductId = ProductIdG, UnitsPurchased = rnd.Next(1, 53) },
                    new Item { Id = 30, ReceiptId = ReceiptId4, ProductId = ProductIdH, UnitsPurchased = rnd.Next(1, 53) }
                );
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------------
        }
    }
}