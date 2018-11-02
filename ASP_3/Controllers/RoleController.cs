using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_3.Models;

namespace ASP_3.Controllers
{
    public class RoleController : Controller
    {
        private Singletone singletone = Singletone.Instens;

        //private string menu = @"<div class=""menu"">
        //<a href = ""~/Views/Home/Index.cshtml"" > Add User</a>
        //<a href = ""~/Views/Home/ShowUsers.cshtml"" > Users List</a>
        //<a href = ""~/Views/Role/Index.cshtml"" > Add Role</a>
        //<a href = ""~/Views/Role/ShowRole.cshtml"" > Roles List</a>
        //</div>";
        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelRole role)
        {
            if (ModelState.IsValid)
            {
                Role rol = new Role(role.Name);
                singletone.AddRoles(rol);
                ViewBag.Roles = singletone.GetRoles();

                return RedirectToAction("ShowRole");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult ShowRole()
        {
            ViewBag.Roles = singletone.GetRoles();
            return View();
        }
        [HttpGet]
        public ActionResult EditRole(int id)
        {
            var Curr_role = singletone.GetRoles().Find(Role => Role.Id == id);
            ViewBag.Role = Curr_role;
            return View();
        }

        [HttpPost]
        public ActionResult EditRole(ModelRole Rol, int id)
        {
            if (ModelState.IsValid)
            {
                var Curr_role = singletone.GetRoles().Find(Role => Role.Id == id);
                Curr_role.Edit_Role(Rol.Name);
                ViewBag.Roles = singletone.GetRoles();
                return RedirectToAction("ShowRole");
            }
            else
            {
                var Curr_role = singletone.GetRoles().Find(Role => Role.Id == id);
                ViewBag.Role = Curr_role;
                return View("EditRole");
            }
        }

        public ActionResult DeleteRole(int id)
        {
            var Curr_role = singletone.GetRoles().Find(Role => Role.Id == id);
            singletone.GetRoles().Remove(Curr_role);
            ViewBag.Roles = singletone.GetRoles();
            return View("ShowRole");
        }

    }

}