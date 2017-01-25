using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GITRhytify.Controllers
{
    public class HomeController : Controller
    {
        // Comments added ;
        public string serverAddress = "";
        public string userName = "";
        public string passWord = "";
        //private static System.Collections.ObjectModel.ReadOnlyCollection<CatalogNode> staticTpcNodes;

        public ActionResult GIT()
        {
            ViewBag.Message = "Your GIT page.";

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string serveraddress, string username, string password)
        {
            if (serveraddress == "" || username == "" || password == "")
            {
                ViewBag.Message = "Login Failed. Please Enter the Details Correctly";
                ViewBag.HasMessage = "true";
                return View("Index");
            }
            else
            {
                return RedirectToAction("ControlTree", "Home", new { serveraddress = serveraddress, username = username, pwd = password });
            }
          //  return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ControlTree(string serveraddress, string username, string password)
        {

            // serverAddress = ConfigurationManager.AppSettings["URL"].ToString();  
            // userName = ConfigurationManager.AppSettings["UserName"].ToString();
            // passWord = ConfigurationManager.AppSettings["PassWord"].ToString();
            serverAddress = serveraddress;
            userName = username;
            passWord = password;
            var ProjectCollectionList = new List<string>();
            var test = new Dictionary<string, string>();
            if (serverAddress != "")
            {
                //staticTpcNodes = objTFSDeltaClass.TFSConnectionDetails(serverAddress, userName, passWord);
                //staticTpcNodes.Take(staticTpcNodes.Count - 1);
            }
            //if (staticTpcNodes != null)
            //{
            //    foreach (CatalogNode tpcNode in staticTpcNodes)
            //    {
            //        teamCollectionList.Add(tpcNode.Resource.DisplayName);
            //    }
            //}


            return View("Control Tree");
        }
    }
}