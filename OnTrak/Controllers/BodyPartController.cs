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
    public class BodyPartController : Controller
    {

        private IBodyAreaRepository bodyAreaRepository;
        private IBodyPartRepository bodyPartRepository;
        public BodyPartController(IBodyAreaRepository bAreaRepo, IBodyPartRepository bPartRepo)
        {
            bodyAreaRepository = bAreaRepo;
            bodyPartRepository = bPartRepo;
        }

        public ViewResult Create()
        {
            BodyPartsViewModel bPartVM = new BodyPartsViewModel
            {
                BodyAreas = bodyAreaRepository.BodyAreas.ToList()
            };
            return View(bPartVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BodyPartsViewModel bodyPart, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            ModelState.Remove("Id");
            BodyPart bPart = new BodyPart
            {
                BodyPartId = bodyPart.BodyPartId,
                Name = bodyPart.Name,
                Description = bodyPart.Description,
                BodyAreaId = bodyPart.BodyAreaId,
                NumberOfMuscles = bodyPart.NumberOfMuscles
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bodyPart.Image = memoryStream.ToArray();
                }
            }
            BodyAreaViewModel BA = bodyAreaRepository.CreateBAreaViewModel(bodyPartRepository, bodyPart.BodyAreaId);

                //context.BodyAreas.FirstOrDefault(ba => ba.Id == bodyPart.BodyAreaId);
            if (ModelState.IsValid)
            {
                bodyPartRepository.SaveBodyPart(bPart);
                TempData["Message"] = $"{bodyPart.Name} has been saved";
                return RedirectToAction("Index", "BodyArea", bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository));
            }
            else
                return RedirectToAction("Index", "BodyArea", bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository));
        }


        public ViewResult Edit(int? Id)
        {
            return View(bodyPartRepository.CreateBPartViewModel(bodyAreaRepository, Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BodyPartsViewModel bodyPartVM, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            BodyPart bPart = new BodyPart
            {
                BodyPartId = bodyPartVM.BodyPartId,
                Name = bodyPartVM.Name,
                Description = bodyPartVM.Description,
                NumberOfMuscles = bodyPartVM.NumberOfMuscles,
                BodyAreaId = bodyPartVM.BodyAreaId,
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bPart.Image = memoryStream.ToArray();
                }
            }
            else
            {
                bPart.Image = bodyAreaRepository.getBodyAreaById(bPart.BodyPartId).Image;
            }


            if (ModelState.IsValid)
            {
                bodyPartRepository.SaveBodyPart(bPart);
                TempData["Message"] = $"{bPart.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
                return View(bodyPartVM);
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
