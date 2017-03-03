# Online Shoes Store 

   Folowing my friend's interest in setting up an online business, I decided to craft a simple yet attractive platform for his users to purchase products. This is a light-weight web app 
   designed in ASP .NET MVC 4.5 as the back-end framework and jQuery/Ajax, HTML and CSS/BootStrap as front-end. 
   
![one_shoes](https://cloud.githubusercontent.com/assets/19439711/23486704/7a91202e-fe96-11e6-9845-93568d845002.png)

![shoes_2](https://cloud.githubusercontent.com/assets/19439711/23486905/a2308d26-fe97-11e6-9fe8-4da44cca3787.png)


## Main Features 

   - Inventory Manager
   - Role Manager
   - Shopping Cart with fresh updates 
   - Role-Based Security 
   - Entity Framework 
       

### Views 
 
* Home (`home.chstml`)
* Login and Register  (`login.chstml`, `register.chtml`)
* Product listing (`index.chstml`)
* Product Detail (`details.chstml`)
* Shopping Cart Summary (`cart.chstml`)
* Review Shopping Cart (`review.chstml`) 
* Checkout (`checkout.chstml`)
* Store Manager 
* Role Management 

### Controllers
     
* Inventory Manager  (```/StoreManager```) 
 This allows to perform Create, Delete, Read, and Update operations on the existing inventory.
 This operation is only accessible to a user with role `admin` or `super Admin`  

* Shopping Cart (```/ShoppingCart```)
This app includes a shopping cart feature that allows to select items and update the 
quantity at any time. A logo of the updated quantity is displayed at all times in all views as 
part of the shared layout. 

* Roles Manager (```/Roles```)
This application builds on top of Microsoft Asp.NET Identity module (that allows for persisting users and roles) to 
allow for Role-Based Security 
Roles can be listed, created, deleted, and updated (A sample route would be: `/Roles/Edit/5`). 
This will also show a list of users/roles association. 
Roles can also be added/deleted to users under `\DeleteRoleForUser` or `\AddRoleToUser` by selecting the role 
and providing the username of the user.

* Account Manager
This allows for users to be registered and allows admin users to delete or modify users. It uses the built-in 
Microsoft Asp .net Identity module for salt/hashing and authorization filtering.

### Migrations 

There is currently a migration file under the migration folder that seeds a collection of sample products into the database at run-time.

## Installing / Deployment
This application currently runs on my local environment (localhost) and SQL Server. If you would like to run it on your machine and any environment all you need is: 
* Install Visual Studio if it is not already (Express is free!)
* Clone the repository 
* Change the `connection string` in the `web.config` file to point to your server/database 
* Give it a build and Run! 

## Contributing 
Please read the Installing step and feel free to fork and clone. If you encounter a bug, please feel free to submit a Pull Request! 
Any feedback is greatly appreciated. 
    
## ToDo: 
- Switch to using bootstrap for some of the views 
- Adding a repository layer and use dependency injection to resolve repositories into controllers 
This will improve testability and help the solution become scalable.    

## Authors 
- Hichem Rehouma - Initial work 
## Acknowledgements 
- Hat tip to Microsoft ASP .NET for the excellent API documentation and templates 
- My friend Maksim who is an e-commerce lover and inspired me to look into the e-commerce technology trends   




