using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using ASP_3.Models;

namespace ASP_3.Controllers
{
    public class HomeController : Controller
    {
        private Singletone singletone = Singletone.Instens;
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ShowItems();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ModelUser modelUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User(modelUser.FirstName, modelUser.LastName, modelUser.Login, modelUser.Password, modelUser.Email, modelUser.Phone);
                var get_role = singletone.GetRoles().Find(Role => Role.Id == Convert.ToInt32(modelUser.role));
                user.AddRole(get_role);
                singletone.AddUsers(user);
                ViewBag.listUser = singletone.GetUsers();
                return RedirectToAction("ShowUsers");
            }
            else
            {
                ShowItems();
                return View("Index");
            }

        }

        private void ShowItems()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (Role VARIABLE in singletone.GetRoles())
            {
                item.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
            }

            ViewBag.Item = item;
        }

        public ActionResult ShowUsers()
        {
            ViewBag.listUser = singletone.GetUsers();
            return View();
        }


        public ActionResult More(int id)
        {

            var Curr_user = singletone.GetUsers().Find(User => User.Id == id);
            ViewBag.user = Curr_user;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var Curr_user = singletone.GetUsers().Find(User => User.Id == id);
            ViewBag.user = Curr_user;
            ShowItemSelected(Curr_user);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ModelUser user, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Curr_User = singletone.GetUsers().Find(User => User.Id == id);
                    Curr_User.Renam_User(user.FirstName, user.LastName, user.Login, user.Password, user.Email, user.Phone);
                    var get_role = singletone.GetRoles().Find(Role => Role.Id == Convert.ToInt32(user.role));
                    Curr_User.AddRole(get_role);
                    ViewBag.listUser = singletone.GetUsers();
                    return RedirectToAction("ShowUsers");
                }
                else
                {
                    var Curr_user = singletone.GetUsers().Find(User => User.Id == id);
                    ViewBag.user = Curr_user;
                    ShowItemSelected(Curr_user);
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Exseption = e.Message;
                return View("~/Views/Error.cshtml");
            }

        }

        private void ShowItemSelected(User user)
        {
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (Role VARIABLE in singletone.GetRoles())
            {
                if (user != null)
                {
                    if (user.Role != null)
                    {
                        if (user.Role.Name.Equals(VARIABLE.Name))
                        {
                            item.Add(new SelectListItem { Selected = true, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                        }
                        else
                        {
                            item.Add(new SelectListItem { Selected = false, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                        }
                    }
                    else
                    {
                        item.Add(new SelectListItem { Selected = false, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                    }
                }
                else
                {
                    item.Add(new SelectListItem { Selected = false, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                }
            }

            ViewBag.Item = item;
        }

        public ActionResult DeleteUser(int id)
        {
            var Curr_user = singletone.GetUsers().Find(User => User.Id == id);
            singletone.GetUsers().Remove(Curr_user);
            ViewBag.listUser = singletone.GetUsers();
            return View("ShowUsers");
        }
    }
}