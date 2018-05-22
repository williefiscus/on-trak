using Microsoft.AspNetCore.Mvc;
using OnTrak.Models.WebsiteMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Controllers
{
    public class PartialController : Controller
    {
        public ActionResult RetrieveImage(byte[] image)
        {
            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }
    }
}
