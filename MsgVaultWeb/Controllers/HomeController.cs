using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MsgVaultWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            MsgVaultService client = new MsgVaultService();
            List<MongoMail> emails = client.GetEmailsPage(0, 20);
            return View(emails);
        }
	}
}