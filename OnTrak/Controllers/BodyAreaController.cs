using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities;
using OnTrak.Models.Repository.BodyData;
using OnTrak.Models.ViewModel;
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

        public ViewResult Index() => View(bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository));
        public ViewResult Edit(int? Id) {
            return View(bodyAreaRepository.CreateBAreaViewModel(bodyPartRepository, Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BodyAreaViewModel bodyAreaModel, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            BodyArea bArea = new BodyArea
            {
                BodyAreaId = bodyAreaModel.BodyAreaId,
                Name = bodyAreaModel.Name,
                Description = bodyAreaModel.Description,
                NumberOfParts = bodyAreaModel.NumberOfParts,
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bArea.Image = memoryStream.ToArray();
                }
            }
            else
            {
                bArea.Image = bodyAreaRepository.getBodyAreaById(bodyAreaModel.BodyAreaId).Image;
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

        public ActionResult RetrieveImage(int Id)
        {

            byte[] cover = GetImageFromDataBase(Id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            var photo = bodyAreaRepository.getBodyAreaById(Id).Image;
            byte[] cover = photo;
            return cover;
        }
    }
}
