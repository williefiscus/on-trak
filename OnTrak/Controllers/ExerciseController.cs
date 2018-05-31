using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTrak.Models.Data.EFRepo;
using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities.Activities;
using OnTrak.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Controllers
{
    public class ExerciseController : Controller
    {

        private IBodyAreaRepository bodyAreaRepository;
        private IBodyPartRepository bodyPartRepository;
        private IMuscleRepository muscleRepository;
        private IExerciseRepository exerciseRepository;
        public DBGetter dbGetter = new DBGetter();
        public ExerciseController(IBodyAreaRepository bAreaRepo, IBodyPartRepository bPartRepo, IMuscleRepository muscleRepo, IExerciseRepository exerciseRepo)
        {
            bodyAreaRepository = bAreaRepo;
            bodyPartRepository = bPartRepo;
            muscleRepository = muscleRepo;
            exerciseRepository = exerciseRepo;
            dbGetter.AssignData(muscleRepository.Muscles.ToList(), bodyAreaRepository.BodyAreas.ToList(), bodyPartRepository.BodyParts.ToList());
        }

        public ViewResult Index() {
            return View();
        }

        public ViewResult Create()
        {
            ExerciseViewModel exerciseVM = new ExerciseViewModel
            {
                BodyParts = bodyPartRepository.BodyParts.ToList(),
                BodyAreas = bodyAreaRepository.BodyAreas.ToList(),
                Muscles = muscleRepository.Muscles.ToList()
            };
            return View(exerciseVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseViewModel exerciseVM, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            Exercise exercise = new Exercise
            {
               
                Description = exerciseVM.Description,
                Name = exerciseVM.Name,
                ExerciseId = exerciseVM.ExerciseId,
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    exercise.Image = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                exerciseRepository.SaveExercise(exercise);
                TempData["Message"] = $"{exercise.Name} has been created";
                return RedirectToAction("Index", "BodyArea", bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository, bodyAreaRepository, dbGetter));
            }
            else
                return RedirectToAction("Index", "BodyArea", bodyAreaRepository.BodyAreas.ToList().CreateListBAreaVM(bodyPartRepository, bodyAreaRepository, dbGetter));
        }



        public ViewResult Edit(int? Id)
        {
            return View(muscleRepository.GetMusceById(Id).CreateMuscleViewModel(dbGetter));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExerciseViewModel exerciseVM, IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            Exercise exercise = new Exercise
            {
                Description = exerciseVM.Description,
                Name = exerciseVM.Name,
                ExerciseId = exerciseVM.ExerciseId,
            };
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    exercise.Image = memoryStream.ToArray();
                }
            }
            else
            {
                exercise.Image = exerciseRepository.GetExerciseById(exercise.ExerciseId).Image;
            }


            if (ModelState.IsValid)
            {
                exerciseRepository.SaveExercise(exercise);
                TempData["Message"] = $"{exercise.Name} has been saved";
                return RedirectToAction("Index", "BodyArea");
            }
            else
                return View(exerciseVM);
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
            var photo = muscleRepository.GetMusceById(Id).Image;
            byte[] cover = photo;
            return cover;
        }
    }
}
