using Assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Assignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment.Controllers.Account
{
    [Authorize]

    public class CustomerRepController : Controller
    {
        CustomerDetails cust;

        public CustomerRepController()
        {
            cust = new CustomerDetails();
        }
        public IActionResult Signin()

        {
            try
            {
                if (HttpContext.Session.GetString("UserName") == null)
                {
                    return RedirectToAction("login", "Account");

                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();

            }
        }

        public IActionResult inddex()
        {
            try
            {
                var data = cust.getAll();
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();

            }
        }

        public IActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();

            }
        }
            [HttpPost]
        public IActionResult Register(Data model)
        {


            cust.Register(model.Full_Name,model.Email,model.Phone);
            return RedirectToAction("inddex");
        }
        public IActionResult update() {

            return View(); 
        }
        [HttpPost]
        //public IActionResult update(Data model)
        //{
        //    cust.update(model.Full_Name, model.Email, model.Phone);
        //    return RedirectToAction("index");
        //}
        public IActionResult update(Data model)
        {
            cust.update(model.Id,model.Full_Name, model.Email, model.Phone);
            return RedirectToAction("inddex");
        }
        public IActionResult Dlete()
        {  return View();
        }
        [HttpPost]
        public IActionResult Delete(Data model)
        {

            cust.delete(model.Id);
            return RedirectToAction("Index");
        }

    }
}

  
        