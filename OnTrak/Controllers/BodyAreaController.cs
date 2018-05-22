using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities;
using OnTrak.Models.Repository.BodyData;
using OnTrak.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Controllers
{
    public class BodyAreaController : Controller
    {
        private IBodyAreaRepository bodyAreaRepository;
        private IBodyPartRepository bodyPartRepository;
        public BodyAreaController(IBodyAreaRepository bAreaRepo, IBodyPartRepository bPartRepo)
        {
            bodyAreaRepository = bAreaRepo;
            bodyPartRepository = bPartRepo;
        }

        public ViewResult Index() => View(bodyAreaRepository.BodyAreas);
        public ViewResult Edit(int? id) {

            if (id == null || id <= 0)
            {
               
            }
            BodyArea bodArea = bodyAreaRepository.getBodyAreaById(id);
            BodyAreaViewModel bAreaModel = new BodyAreaViewModel {
                Name = bodArea.Name,
                Id = bodArea.Id,
                BodyParts = bodyPartRepository.BodyParts.ToList(),
                NumberOfParts = bodArea.NumberOfParts,
                Description = bodArea.Description,
                Image = bodArea.Image
            };
            return View(bAreaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BodyAreaViewModel bodyAreaModel, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            BodyArea bArea = new BodyArea
            {
                Id = bodyAreaModel.Id,
                Name = bodyAreaModel.Name,
                Description = bodyAreaModel.Description,
                NumberOfParts = bodyAreaModel.NumberOfParts,
                Image = bodyAreaModel.Image
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bArea.Image = memoryStream.ToArray();
                }
            }


            if (ModelState.IsValid)
            {
                bodyAreaRepository.SaveBodyArea(bArea);
                TempData["Message"] = $"{bArea.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
                return View(bodyAreaModel);
        }
    }
}
