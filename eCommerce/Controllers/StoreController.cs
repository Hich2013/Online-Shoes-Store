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
        MusicStoreEntities storeDB = new MusicStoreEntities();
        // GET: Store
         // GET: /Store/
        public ActionResult Index()
        {
            var album1 = storeDB.Albums.Where(c => c.Title == "A Copland Celebration, Vol. I").FirstOrDefault();
            var album2 = storeDB.Albums.Where(c => c.Title == "Worlds").FirstOrDefault();
            var album3 = storeDB.Albums.Where(c => c.Title == "For Those About To Rock We Salute You").FirstOrDefault();
            var album4 = storeDB.Albums.Where(c => c.Title == "Let There Be Rock").FirstOrDefault();
            var album5 = storeDB.Albums.Where(c => c.Title == "Balls to the Wall").FirstOrDefault();
            var top5 = new List<Album>();           
            top5.Add(album1);
            top5.Add(album2);
            top5.Add(album3);
            top5.Add(album4);
            top5.Add(album5);            
            return View(top5);
        }
        //
        // GET: /Store/Browse
      public ActionResult Browse(string genre)
        {
            if (!string.IsNullOrEmpty(genre))
            {
                var genreModel = storeDB.Genres.Include("Albums").SingleOrDefault(g => g.Name == genre);
                return View(genreModel);
            }
            return RedirectToAction("Index");

        }
        //
        // GET: /Store/Details
      public ActionResult Details(int? id)
         {
            var count = storeDB.Albums.Count();
            TempData["count"] = count.ToString();
            var album = storeDB.Albums.Find(id);
            return View(album);
         }

      //
      // GET: /Store/GenreMenu
      [ChildActionOnly]
      public ActionResult GenreMenu()
      {
          var genres = storeDB.Genres.ToList();
          return PartialView(genres);
          //storeDB.Albums.Where(c => (c.Title.Contains("") || c.Genre.Name.Contains(""))).ToList();
      }
    }
}