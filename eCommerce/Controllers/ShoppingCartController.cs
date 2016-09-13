using eCommerce.Models;
using eCommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        StoreEntities storeDB = new StoreEntities();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartSubTotal = cart.GetSubTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5?quantity=XXX
        public ActionResult AddToCart(int id, string quantity)
        {
            int quantityNumber;
            if(!Int32.TryParse(quantity, out quantityNumber))
                quantity = "1";

            if (string.IsNullOrEmpty(quantity))
                quantity = "1";
            // Retrieve the Product from the database
            var addedProduct = storeDB.Products
                .Single(Product => Product.ProductId == id);
 
            quantityNumber = Int32.Parse(quantity);
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProduct, quantityNumber);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/UpdateCart?title=X&?quantity=Y
        [HttpPost]
        public void UpdateCart(List<cartItem> cartItemsUpdate)
        {
            // Get the Cart 
            var cart = ShoppingCart.GetCart(this.HttpContext);

            foreach (cartItem itemToUpdate in cartItemsUpdate)
            {
                cart.UpdateCart(itemToUpdate.recordId, Int32.Parse(itemToUpdate.quantity));
            }
        }

        public class cartItem
        {
             public int recordId { get; set;}
             public string quantity { get; set;}
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public void RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the Product to display confirmation
            string ProductName = storeDB.Carts
                .Single(item => item.RecordId == id).Product.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message        
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        //
        // GET: /ShoppingCart/Review
        public ActionResult Review()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartSubTotal = cart.GetSubTotal()
            };
            // Return the view
            return View(viewModel);
        }
               
    }
}