using Assignment.Models;
using Assignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;

namespace Assignment.Controllers.Account
{
    [Authorize]
    public class ProductController : Controller
    {
     
        Products repo;
        public ProductController()
        {
            repo = new Products();


        }
        public IActionResult Index()
        {
            var data = repo.getAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(info model)
        {
            repo.create(model. P_Name, model. price );
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }
   
        [HttpPost]
        public IActionResult Edit(info model)
        {
            repo.Edit(model.P_id, model.P_Name, model.price);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Delete(info model)
        {

            repo.delete(model.P_id);
            return RedirectToAction("Index");
        }

    }
}
