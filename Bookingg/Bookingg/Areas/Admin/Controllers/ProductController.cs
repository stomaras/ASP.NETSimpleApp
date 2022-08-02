using Booking.Models;
using Booking.Models.ViewModels;
using Bookingg.Data;
using Bookingg.DataAccess.Repository.Core;
using Bookingg.DataAccess.Repository.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookingg.Areas.Admin.Controllers
{
    /*
     * Category Controller , we can take that to move into admin area, bcause that is a management controller
     * which will be managed the category and only admins should be able to do that
     * 
     */
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private ApplicationDbContext _db;
        private UnitOfWork _unitOfWork;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _unitOfWork = new UnitOfWork(_db);
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }
        public IActionResult Create()
        {

            return View();
        }

   

        // GET
        public IActionResult Upsert(int? id)
        {
            ProductViewModel productVM = new ProductViewModel()
            {
                product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i=> new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };
            if (id is null || id == 0)
            {
                // Create Product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                // tightly binded View
                return View(productVM);

            }
            else
            {
                productVM.product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                return View(productVM);
                // update product
            }
           
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel obj, IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    // means file was uploaded
                    
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName+extension),FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.product.ImageUrl = @"\images\products\" + fileName + extension;
                }
                if (obj.product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.product);
                    TempData["success"] = "Product Created Succesfully";
                }
                else
                {
                    _unitOfWork.Product.Update(obj.product);
                    TempData["success"] = "Product Updated Succesfully";
                }
                
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            var CoverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj is null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType Deleted Succesfully";
            return RedirectToAction("Index");

        }

        #region  API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");
            return Json(new {data = productList});
        }

        [HttpDelete]
        public IActionResult DeleteAPI(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj is null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
