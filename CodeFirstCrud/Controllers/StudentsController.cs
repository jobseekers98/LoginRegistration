using CodeFirstCrud.Models;
using DAL.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BAL;
using BAL.IRepository;
using MODEL;
using DAL;

namespace CodeFirstCrud.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService studentService;
        private ILogger<StudentsController> _logger;
        private DatabaseContext DataContext;

        public StudentsController(ILogger<StudentsController> logger, IStudentService _studentService, DatabaseContext _DataContext)
        {
            studentService = _studentService;
            _logger = logger;
            DataContext = _DataContext;
        }

        //[Authorize]
        public async Task<IActionResult> Index(int? userId)
        {
          
            //try
            //{
            //    int a = 12;
            //    int b = 0;
            //    int c = a / b;
            //    var studentList = await Context.tbl_Student.Where(s => s.Status == true).ToListAsync();
            //    return View(studentList);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.ToString());

            //}
            //return View();



            var student= await studentService.GetStudent(userId);
            return View(student);


        }
        //Get Method code
        [HttpGet]
        public async Task<IActionResult>  AddOrEdit(int id) 
        {

            //Student obj = new Student();
            //return View(obj);
            if (id == 0)
            {

                Student obj = new Student();
                return View(obj);

            }
            else 
            {
                var student = await studentService.GetStudentId(id);
                return View(student);
            }


        }

       // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Student student)
        {
            int result  = await studentService.AddorUpdate(student);
            //return RedirectToAction("Index", "Students");
            if (result == 1)
            {
                return RedirectToAction("Index", "Students");
            }
            else if (result == 2)
            {
                return RedirectToAction("Index", "Students");
            }
            else
            {
                ViewBag.msg = "Email already exixt";
                return View(student);

            }

        }


        //Delete method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id > 0)
            {
                await studentService.DeleteStudent(id);

            }
            //var employee = await Context.tbl_Student.FindAsync(id);
            //employee.Status = false;
            //Context.Update(employee);
            //await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> AddOrEdit(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var CheckEmail = student.Email;
        //        student.Status = true;
        //        var check = Context.tbl_Student.Where(x => x.Email == CheckEmail).ToList();



        //        if (student.Id == 0)
        //        {
        //            if (check.Count > 0)
        //            {
        //                ViewBag.Duplicate = "Enter another Email" + " " + CheckEmail + " " + "is already exists in Database!";
        //                return View(student);

        //            }
        //            else
        //            {
        //                Context.Add(student);
        //                await Context.SaveChangesAsync();
        //                ViewBag.data = "Record has been Created!";
        //                // return View(student);
        //                return RedirectToAction("Index", "Students");

        //            }
        //        }
        //        else
        //        {
        //            Context.Update(student);
        //            await Context.SaveChangesAsync();
        //            return RedirectToAction("Index", "Students");
        //        }
        //    }
        //    else
        //    {
        //        return View(student);


        //    }

        //}

        ////Delete method
        //public async Task<IActionResult> Delete(int? id)
        //{


        //    var employee = await Context.tbl_Student.FindAsync(id);
        //    employee.Status = false;
        //    Context.Update(employee);
        //    await Context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


        public IActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            //objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {

                var user = DataContext.tbl_Student.Where(x => x.Email == objLoginModel.Email && x.Password == objLoginModel.Password).FirstOrDefault();
                if (user == null)
                {
                    //Add logic here to display some message to user
                    ViewBag.Message = "Invalid Credential";
                    return View(objLoginModel);
                }
                else
                {
                    //A claim is a statement about a subject by an issuer and
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.
                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim("FavoriteDrink","Tea")
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal, new AuthenticationProperties() /*{ IsPersistent = objLoginModel.RememberLogin }*/);


                    return RedirectToAction("Index", "Students");
                }
            }
            else
            {
                return RedirectToAction("Login", "Students");
            }
        }


        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page
            return LocalRedirect("/");
        }









    }
}
