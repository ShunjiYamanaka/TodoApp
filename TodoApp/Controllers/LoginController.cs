using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    //認証しなくてもアクセス可とする
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //値を書き換える必要がないのでReadonly
        readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, Password")] LoginViewModel model) 
        {
            
            if (ModelState.IsValid) 
            {
                if (this.membershipProvider.ValidateUser(model.UserName, model.PassWord)) 
                {
                    //UserName, Passwordが正しい
                    //cookieを保持する
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Todoes");
                }
            }
            //Login失敗
            ViewBag.Message = "ログインに失敗しました。";
            return View(model);
        }

        public ActionResult SignOut() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}