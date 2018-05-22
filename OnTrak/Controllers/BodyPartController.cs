using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Controllers
{
    public class BodyPartController : Controller
    {
        public ViewResult Create()
        {
            return View();
        }
    }
}
