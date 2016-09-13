using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class StoreController : Controller
    {
        StoreEntities storeDB = new StoreEntities();
        // GET: Store
         // GET: /Store/
        public ActionResult Index()
        {
            var products = storeDB.Products.ToList();           
            return View(products);
        }
        //
        // GET: /Store/Browse
      public ActionResult Browse(string genre)
        {
            if (!string.IsNullOrEmpty(genre))
            {
                var genreModel = storeDB.Genres.Include("Products").SingleOrDefault(g => g.Name == genre);
                return View(genreModel);
            }
            return RedirectToAction("Index");
        }
        //
        // GET: /Store/Details
      public ActionResult Details(int? id)
         {
            var count = storeDB.Products.Count();
            TempData["count"] = count.ToString();
            var Product = storeDB.Products.Find(id);
            return View(Product);
         }

      //
      // GET: /Store/GenreMenu
      [ChildActionOnly]
      public ActionResult GenreMenu()
      {
          var genres = storeDB.Genres.ToList();
          return PartialView(genres);
          //storeDB.Products.Where(c => (c.Title.Contains("") || c.Genre.Name.Contains(""))).ToList();
      }

      // GET: /Store/GenreMenuDropDown
      [ChildActionOnly]
      public ActionResult GenreMenuDropDown()
      {
          var genres = storeDB.Genres.ToList();
          return PartialView(genres);
      }

      public ActionResult Search(string SearchText)
      {
          if (!string.IsNullOrEmpty(SearchText))
          {
            var Products = storeDB.Products.Where(c => (c.Title.Contains(SearchText) || c.Genre.Name.Contains(SearchText))).ToList();
            return View(Products);
          }
          return View();
      }
    }
}