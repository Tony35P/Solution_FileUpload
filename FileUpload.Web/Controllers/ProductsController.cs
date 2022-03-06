using FileUpload.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Web.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(ProductVM record)
        {
            return View();
        }
    }
}