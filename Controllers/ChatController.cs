using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatRoom.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View("Chat");
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SendMessage(string message) {
            string path = Server.MapPath("~/Content/ChatLog/ChatLog.txt");
            using (var tw = new StreamWriter(path, true))
            {
                //< div class='msgln'>(".date("g:i A").") <b>".$_SESSION['name']."</b>: ".stripslashes(htmlspecialchars($text))."<br></div>
                tw.WriteLine("<div class='msgln'>(" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "): " + message + "<br></div>");
            }
            return Json("succes", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult RetrieveMessages()
        {
            string[] result = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatLog/ChatLog.txt"));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}