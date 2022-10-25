using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    // MVC コントローラ空
    [AllowAnonymous]//認証していない状態でアクセスできる
    public class LoginController : Controller
    {
        readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName,Password")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.membershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    //認証をつかさどるクラス　認証状態を保持　ユーザー名を認証クッキーに保持
                    //認証クッキーがブラウザに保持されている場合は認証状態であると判断
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Todoes");
                }
            }

            //Message プロパティを定義
            ViewBag.Message = "ログイン失敗";
            return View(model);
        }

        //Logout
        public ActionResult SignOut()
        {
            //認証クッキーを削除
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }
    }
}