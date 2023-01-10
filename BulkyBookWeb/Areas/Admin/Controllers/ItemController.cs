using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Sd.Role_Admin)]
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IUnitOfWork unitOfWork, ILogger<ItemController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objItemsList = _unitOfWork.Item.GetAll();
            return View(objItemsList);
        }
        //GetCreate
        public IActionResult Create()
        {
            return View();
        }

        //create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order Can not Match The Name ");
            //}
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            _unitOfWork.Item.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Item Created Successfully";
            return RedirectToAction("Index");

        }

        //
        //editCreate
        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();

            }

            var itemFromDbFirst = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);
            if (itemFromDbFirst == null)
            {
                return NotFound();
            }
            return View(itemFromDbFirst);
        }

        //edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order Can not Match The Name ");
            //}
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            _unitOfWork.Item.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Item Updated Successfully";
            return RedirectToAction("Index");

        }


        //deleteget
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }

            var item = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Item.GetFirstOrDefault(c => c.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Item.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Item Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
