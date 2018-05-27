using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTrak.Migrations;
using OnTrak.Models.Data.EFRepo;
using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities.Body;
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
    public class MuscleController : Controller
    {

        private IBodyAreaRepository bodyAreaRepository;
        private IBodyPartRepository bodyPartRepository;
        private IMuscleRepository muscleRepository;
        public DBGetter dbGetter = new DBGetter();
        public MuscleController(IBodyAreaRepository bAreaRepo, IBodyPartRepository bPartRepo, IMuscleRepository muscleRepo)
        {
            bodyAreaRepository = bAreaRepo;
            bodyPartRepository = bPartRepo;
            muscleRepository = muscleRepo;
            dbGetter.AssignData(muscleRepository.Muscles.ToList(), bodyAreaRepository.BodyAreas.ToList(), bodyPartRepository.BodyParts.ToList());
        }



        public ViewResult Create()
        {
            MuscleViewModel muscleVM = new MuscleViewModel
            {
                BodyParts = bodyPartRepository.BodyParts.ToList()
            };
            return View(muscleVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MuscleViewModel muscleVM, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            Muscle muscle = new Muscle
            {
               BodyPartId = muscleVM.BodyPartId,
               Description = muscleVM.Description,
               Image = muscleVM.Image,
               MuscleId = muscleVM.MuscleId,
               Name = muscleVM.Name
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    muscle.Image = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                muscleRepository.SaveMuscle(muscle);
                TempData["Message"] = $"{muscle.Name} has been created";
                return RedirectToAction("Index", "BodyArea", bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository, bodyAreaRepository, dbGetter));
            }
            else
                return RedirectToAction("Index", "BodyArea", bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository, bodyAreaRepository, dbGetter));
        }



        public ViewResult Edit(int? Id)
        {
            return View(muscleRepository.getMusceById(Id).CreateMuscleViewModel(dbGetter));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MuscleViewModel muscleVM, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            Muscle muscle = new Muscle
            {
                BodyPartId = muscleVM.BodyPartId,
                Name = muscleVM.Name,
                Description = muscleVM.Description,
                MuscleId = muscleVM.MuscleId
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    muscle.Image = memoryStream.ToArray();
                }
            }
            else
            {
                muscle.Image = muscleRepository.getMusceById(muscle.MuscleId).Image;
            }


            if (ModelState.IsValid)
            {
                muscleRepository.SaveMuscle(muscle);
                TempData["Message"] = $"{muscle.Name} has been saved";
                return RedirectToAction("Index", "BodyArea");
            }
            else
                return View(muscleVM);
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
            var photo = muscleRepository.getMusceById(Id).Image;
            byte[] cover = photo;
            return cover;
        }
    }
}
