using Bookingg.Data;
using Bookingg.DataAccess.Repository.Core;
using Bookingg.DataAccess.Repository.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryReposiotry, CategoryRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
/*
 * The three lifetime we have is singleton scoped and transient
 * Singletong means will be created one object through out the lifecycle and that will be used 
 * unless you restart the application
 * Scoped means that when you hit the button  and request is received that will be the scoped of that object,
 * when you hit the button at next time  or on the next request, a new object instance will be created
 * Transient is the smallest of all lifetime, means every time it will create a new object.
 * So let;s say you hit a button and on that button, click if you request your database three times
 * transient will create three instance of the db context, you must be very careful about , because if an object 
 * is requested 100 times , then it will create 100 differenc instances of the object
 * whenever we request an object of a category repository , it will give us the implementation 
 * which we have defined inside CategoryRepository
 */
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

/*
 * Section 6 - Infos
 * First We create a model for product
 * For Each Product we can have a list price like we want to give them a special price on each product
 * Excpet from ListPrice we will create a price property , if they want to get just one product
 * Also Will have a property Price50 if they want to buy at least 50 books -> better price e.t.c
 * 
 * A book will have a category and cover type .. so will have relathionship with above mentioned entites
 * 
 * When combine insert and update action method called upsert
 * upsert one action method to handle both the scenarios
 * When we want on product page, think about what will be every detail that we want to display or get from the user
 * based on some dropdown user will select which category or cover type want for the product
 * 
 * I will use IEnumerbale<SelectListItem> In order to retieve all informations and i will call this CategoryList in order to project on the view with a dropdown menu
 * 
 * 
 * VIEWBAG : transfers data from the Controller to View, Ideal for situations in which the temporary data is not a model
 *           Any number of properties and values can be assigned in a ViewBag
 *           The ViewBag's life only lasts during the current http request. ViewBag values will be null 
 *           if redirection occurs
 *           So We will transfer our categorylist and cover lyst with a viewbg in the view
 *           Is actually a wrapper around ViewData
 * VIEWDATA : transfers data from the Controller to View , not vice-versa.Ideal for situations in which the temporary data
 *            is not in a model
 *            is derived from ViewDataDictionary which is a dictionary type
 *            ViewData value must be type cast before use
 *            ViewBag Internally Inserts Data Into ViewData dictionary.So the key of ViewData and the property of the ViewBag must not match
 *            
 * 
 * TEMPDATA : TempData can be used to store data between two consecutive requests
 *            TempData internally use Session to store the data. So think of it as a short lived session
 *            TempData can be used to store only one time messages like error messages, validation messages
 *            
 *            In order to work with images on forms tou need : enctype="multipart/form-data"
 *            
 *            // Use of sweetalert2.github.io
 *            
 *            In order to access the wwwroot folder we need web hosting environment 
 *            so we would have to get that using dependency injection 
 *            we just need to extract that and use it
 *            
 *            when i upload file with the same name everything will be a mess so i use 
 *            Guid.NewGuid().ToString()
 *            
 * Data from the API Call and and from the ajax request must be same case sensitive
 * 
 * Steps to Load a Data Table
 * 1) in the layout load css file, js file
 * 2) in the view page create a section Scripts for all the scripts toy will need
 * 3) in wwwroot/js folder you hit with ajax call in table we want to load data with api call
 * 4) columns in the ajax call must match with columns in datatable html
 * 
 * when we update an imger we must delete the image which exists inside wwwroot/images/products
 * 
 * if we don't put an hidden input field in upsert.cshtml always the id will be zero
 * 
 * with that way the id will populated:
 *  <input asp-for="product.Id" hidden />
 * we also add a hidden property for image url 
 */
