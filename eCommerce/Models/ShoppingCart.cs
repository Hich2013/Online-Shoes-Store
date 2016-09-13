using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Models
{
    public partial class ShoppingCart
    {
        StoreEntities storeDB = new StoreEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        // Sends cookies to clients 
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a random GUID 
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to cliend as a cookie
                    context.Session[CartSessionKey] = tempCartId;
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void AddToCart(Product Product, int quantity)
        {
            // Get the matching cart and Product instances
            var cartItem = storeDB.Carts.SingleOrDefault(c => c.cartId == ShoppingCartId && c.ProductId == Product.ProductId);

            if (cartItem == null)
            {
                // Create new cart item if no cart item exists
                cartItem = new Cart
                {
                    ProductId = Product.ProductId,
                    cartId = ShoppingCartId,
                    Count = quantity,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                // If item already exists in the cart, add one to the quantity
                cartItem.Count += quantity;
            }
            storeDB.SaveChanges();
        }

        /*public void UpdateCart(Product Product, int quantity)
        {
            var cartItem = storeDB.Carts.SingleOrDefault()
        }*/

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Carts.Single(
                cart => cart.cartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {                
                 storeDB.Carts.Remove(cartItem);
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.cartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }

        public void UpdateCart(int id, int count)
        {
            var cartItem = storeDB.Carts.Single(
                cart => cart.cartId == ShoppingCartId
                && cart.RecordId == id);

            if (cartItem != null)
            {
                cartItem.Count = count;
            }
            // Save changes 
            storeDB.SaveChanges();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.cartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetSubTotal()
        {
            // Multiply Product price by count of that Product to get 
            // the current price for each of those Products in the cart
            // sum all Product price totals to get the cart total
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.cartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }
        
        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(c => c.cartId == ShoppingCartId).ToList();
        }
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
               { 
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Product.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.cartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.cartId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}