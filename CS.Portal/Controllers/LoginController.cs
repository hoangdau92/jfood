using CS.Portal.Common;
using CS.Portal.Core.DAO;
using CS.Portal.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Core_MVC.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Home");
            }
            else
                return View();
        }

        #region Login,Logout
   
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string strUserName = model.UserName.Trim();
                string strPass = Encryptor.MD5Hash(model.Password);
                CSF_Users_DAO objUserDao = new CSF_Users_DAO();
                int intResult = objUserDao.Login(strUserName, strPass);
                switch (intResult)
                {
                    case 0://Tên đăng nhập hoặc mật khẩu không đúng
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
                        break;
                    case 1://Đăng nhập thành công
                        if (model.RememberPass)
                        {
                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.UserName.Trim(), DateTime.Now, DateTime.Now.AddMinutes(60), false, "");
                            //Encrypt the ticket
                            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                            //Create a cookie and add the encrypted ticket to the cookie as data
                            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                            //Add the cookie to the outgoing cookie collection
                            Response.Cookies.Add(authCookie);
                        }
                        FormsAuthentication.SetAuthCookie(model.UserName.Trim(), false);
                        string url = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"];
                        return Redirect(url + "/admin/qt_home");
                    case -1:
                        ModelState.AddModelError("", "Tài khoản chưa được click hoạt!");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Mật khẩu không đúng!");
                        break;
                    default:
                        break;
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}
