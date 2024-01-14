using FortisGroup.DATABASE;
using FortisGroup.MODELS.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT01.Models;
using Rotativa;
using System.Linq;

namespace PROJECT01.Controllers
{
    public class ItemController : Controller
    {
        ApplicationDbContext db;

        public ItemController()
        {
            db = new ApplicationDbContext();
        }


        public IActionResult Index(IndexItemVM model)
        {
            ICollection<Item> items = new List<Item>();

            items = db.ItemTB.Include(c => c.Category).ToList();

            model.ListAllItem = items.Select(x => new ListItemVM()
            {
                ID = x.ID,
                Name = x.Name,
                Status = x.Status,
                CategoryName = x.Category?.Name
            }
            ).ToList();

            return View(model);
        }




        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateItemVM();

            model.Categories = db.CategoryTB.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateItemVM model)
        {

            if(ModelState.IsValid) 
            {

                var have = db.ItemTB.FirstOrDefault(c => c.Name == model.Name);

                if (have != null)
                {
                    ViewBag.ErrorMessage = "This item name already exist !";
                }
                else
                {
                    var item = new Item()
                    {
                        Name = model.Name,
                        Status = model.Status,
                        CategoryID = model.CategoryID
                    };

                    db.ItemTB.Add(item);

                    int rowAffected = db.SaveChanges();

                    if (rowAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }

            }

            model.Categories = db.CategoryTB.ToList();

            return View(model); 
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Id is not set !";
                return View("_ApplicationError");
            }

            var existingItem = db.ItemTB.FirstOrDefault(c => c.ID == id);

            if (existingItem == null)
            {
                ViewBag.ErrorMessage = $"Did not find any item with Id {id}";

                return View("_ApplicationError");
            }

            var editItemVM = new EditItemVM()
            {
                ID = existingItem.ID,
                Name = existingItem.Name,
                Status = existingItem.Status
            };

            

            return View(editItemVM);


        }

        [HttpPost]
        public IActionResult Edit(EditItemVM model)
        {
            if (ModelState.IsValid)
            {
                var item = new Item()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Status = model.Status
                };

                db.ItemTB.Update(item);

                int rowAffected = db.SaveChanges();

                if (rowAffected > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        public IActionResult Delete(int? id) 
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Id is not set !";
                return View("_ApplicationError");
            }

            var existingItem = db.ItemTB.FirstOrDefault(c => c.ID == id);

            if (existingItem == null)
            {
                ViewBag.ErrorMessage = $"Did not find any item with Id {id}";

                return View("_ApplicationError");
            }

            var editItemVM = new DeleteItemVM()
            {
                ID = existingItem.ID,
                Name = existingItem.Name,
                Status = existingItem.Status
            };



            return View(editItemVM);


        }

        [HttpPost]
        public IActionResult Delete(EditItemVM model) 
        {
            if (ModelState.IsValid)
            {
                var item = new Item()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Status = model.Status
                };

                db.ItemTB.Remove(item);

                int rowAffected = db.SaveChanges();

                if (rowAffected > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
