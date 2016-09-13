using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace eCommerce.Models
{
    public class SampleData : DropCreateDatabaseAlways<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Men" },                
                new Genre { Name = "Women" },
                new Genre { Name = "Kids" },
                new Genre { Name = "Men Running" },
                new Genre { Name = "Women Running" }
            };

            var Brands = new List<Brand>
            {
                new Brand { Name = "Adidas" },                
                new Brand { Name = "Sebago" },
                new Brand { Name = "Converse" },
                new Brand { Name = "Nike" }
            };

            new List<Product>
            {
                new Product { Title = "Casual F11", Genre = genres.Single(g => g.Name == "Men"), Price = 55.90M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/nike_women_casual_1.jpg" },
                new Product { Title = "Casual F12", Genre = genres.Single(g => g.Name == "Men"), Price = 59.90M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/adidas_casual_men_2.jpg" },
                new Product { Title = "Casual F13", Genre = genres.Single(g => g.Name == "Men"), Price = 50.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/adidas_casual_men_3.jpg" },
                new Product { Title = "Casual F09", Genre = genres.Single(g => g.Name == "Women"), Price = 51.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/adidas_casual_women_1.jpg" },
                new Product { Title = "Casual F14", Genre = genres.Single(g => g.Name == "Men"), Price = 55.90M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/nike_men_casual_1.jpg" },
                new Product { Title = "Casual F15", Genre = genres.Single(g => g.Name == "Men"), Price = 58.90M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/nike_men_casual_2.jpg" },
                new Product { Title = "Casual F16", Genre = genres.Single(g => g.Name == "Men"), Price = 45.90M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/nike_men_casual_3.jpg" },
                new Product { Title = "Casual F17", Genre = genres.Single(g => g.Name == "Men"), Price = 65.90M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/nike_men_casual_4.jpg" },
                new Product { Title = "Casual F18", Genre = genres.Single(g => g.Name == "Women"), Price = 45.90M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/nike_women_casual_1.jpg" },
                new Product { Title = "Casual F19", Genre = genres.Single(g => g.Name == "Women"), Price = 49.90M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/nike_women_casual_2.jpg" },
                new Product { Title = "Casual F20", Genre = genres.Single(g => g.Name == "Kids"), Price = 35.90M, Brand = Brands.Single(a => a.Name == "Converse"), ProductArtUrl = "~/Content/Images/converse_casual_kids_1.jpg" },
                new Product { Title = "Casual F21", Genre = genres.Single(g => g.Name == "Kids"), Price = 33.90M, Brand = Brands.Single(a => a.Name == "Converse"), ProductArtUrl = "~/Content/Images/converse_casual_kids_2.jpg" },
                new Product { Title = "Casual F22", Genre = genres.Single(g => g.Name == "Kids"), Price = 45.90M, Brand = Brands.Single(a => a.Name == "Converse"), ProductArtUrl = "~/Content/Images/converse_casual_kids_3.jpg" },
                new Product { Title = "Casual F23", Genre = genres.Single(g => g.Name == "Kids"), Price = 36.90M, Brand = Brands.Single(a => a.Name == "Converse"), ProductArtUrl = "~/Content/Images/converse_casual_kids_4.jpg" },
                new Product { Title = "Casual F24", Genre = genres.Single(g => g.Name == "Kids"), Price = 40.90M, Brand = Brands.Single(a => a.Name == "Converse"), ProductArtUrl = "~/Content/Images/converse_casual_kids_5.jpg" },
                new Product { Title = "Casual F25", Genre = genres.Single(g => g.Name == "Men"), Price = 65.90M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_men_1.jpg" },
                new Product { Title = "Casual F26", Genre = genres.Single(g => g.Name == "Men"), Price = 75.90M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_men_2.jpg" },
                new Product { Title = "Casual F27", Genre = genres.Single(g => g.Name == "Men"), Price = 55.90M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_men_3.jpg" },
                new Product { Title = "Casual F28", Genre = genres.Single(g => g.Name == "Men"), Price = 70.90M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_men_4.jpg" },
                new Product { Title = "Casual F29", Genre = genres.Single(g => g.Name == "Men"), Price = 60.90M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_men_5.jpg" },
                new Product { Title = "Casual F30", Genre = genres.Single(g => g.Name == "Women"), Price = 65.90M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_men_6.jpg" },
                new Product { Title = "Casual F31", Genre = genres.Single(g => g.Name == "Women"), Price = 65.00M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_women_1.jpg" },
                new Product { Title = "Casual F32", Genre = genres.Single(g => g.Name == "Women"), Price = 60.00M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_women_2.jpg" },
                new Product { Title = "Casual F33", Genre = genres.Single(g => g.Name == "Women"), Price = 75.00M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_women_3.jpg" },
                new Product { Title = "Casual F34", Genre = genres.Single(g => g.Name == "Women"), Price = 55.00M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_women_4.jpg" },
                new Product { Title = "Casual F35", Genre = genres.Single(g => g.Name == "Women"), Price = 72.00M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_women_5.jpg" },
                new Product { Title = "Casual F36", Genre = genres.Single(g => g.Name == "Women"), Price = 67.00M, Brand = Brands.Single(a => a.Name == "Sebago"), ProductArtUrl = "~/Content/Images/sebago_women_6.jpg" },
                new Product { Title = "Running F90", Genre = genres.Single(g => g.Name == "Men Running"), Price = 65.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/running_adidas_men_1.jpg" },
                new Product { Title = "Running F95", Genre = genres.Single(g => g.Name == "Men Running"), Price = 70.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/running_adidas_men_2.jpg" },
                new Product { Title = "Running F93", Genre = genres.Single(g => g.Name == "Men Running"), Price = 71.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/running_adidas_men_3.jpg" },
                new Product { Title = "Running F92", Genre = genres.Single(g => g.Name == "Women Running"), Price = 55.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/running_adidas_women_1.jpg" },
                new Product { Title = "Running F96", Genre = genres.Single(g => g.Name == "Women Running"), Price = 85.00M, Brand = Brands.Single(a => a.Name == "Adidas"), ProductArtUrl = "~/Content/Images/running_adidas_women_2.jpg" },
                new Product { Title = "Running F97", Genre = genres.Single(g => g.Name == "Men Running"), Price = 85.00M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/running_nike_men_1.jpg" },
                new Product { Title = "Running F105", Genre = genres.Single(g => g.Name == "Men Running"), Price = 99.00M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/running_nike_men_2.jpg" },
                new Product { Title = "Running F85", Genre = genres.Single(g => g.Name == "Men Running"), Price = 65.00M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/running_nike_men_3.jpg" },
                new Product { Title = "Running F103", Genre = genres.Single(g => g.Name == "Men Running"), Price = 95.00M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/running_nike_men_4.jpg" },
                new Product { Title = "Running F110", Genre = genres.Single(g => g.Name == "Women Running"), Price = 75.00M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/running_nike_women_2.jpg" },
                new Product { Title = "Running F104", Genre = genres.Single(g => g.Name == "Women Running"), Price = 90.00M, Brand = Brands.Single(a => a.Name == "Nike"), ProductArtUrl = "~/Content/Images/running_nike_zomen_1.jpg" },




            }.ForEach(a => context.Products.Add(a));
            base.Seed(context);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}