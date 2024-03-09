using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Assignment.Models;

namespace Assignment.Controllers.Account

{
    public class AccountController : Controller
    {

       
            public IActionResult login()
            {
                ViewData["error"] = "";
                return View();
            }

            [HttpPost]
            public IActionResult Login(Userlogin model)
            {
                //check from db
                string connString = "server=ENGKALIT; database=Bookshop;integrated security=true; TrustServerCertificate=True;";
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string query = $"select count(*) total from login where UserName='{model.Username}' and Password='{model.Password}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        //user is valid
                        //create session
                        HttpContext.Session.SetString("UserName", model.Username);

                        //give auth cookie
                        var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim(ClaimTypes.Role,"Admin")

                    };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var princible = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(princible);




                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //user is invalid
                        ViewData["error"] = "Invalid Credentials";
                        return View(model);
                    }


                }

            }

            public IActionResult logout()
            {
                HttpContext.Session.Remove("username");
                HttpContext.SignOutAsync();
                return RedirectToAction("login");
            }
        }

    }
