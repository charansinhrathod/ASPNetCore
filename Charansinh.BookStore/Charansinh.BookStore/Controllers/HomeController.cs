using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charansinh.BookStore.Controllers
{
    public class HomeController:Controller
    {
        //public string Index()
        //{
        //    return "Hello From Home Controller.";
        //}
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult Contactus()
        {
            return View();
        }
    }
}
