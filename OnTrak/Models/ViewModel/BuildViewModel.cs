using OnTrak.Models.Data.EFRepo;
using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities;
using OnTrak.Models.Repository.BodyData;
using OnTrak.Models.Repository.EFRepository;
using OnTrak.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTrak.Models.ExtensionMethods;
using OnTrak.Models.Entities.Body;

namespace OnTrak.Models.ViewModel
{
    public static class BuildViewModel
    {
        public static BodyAreaViewModel CreateBAreaViewModel(this IBodyAreaRepository bArea, IBodyPartRepository bPart, int? Id, DBGetter db)
        {
            BodyArea bodyArea = bArea.getBodyAreaById(Id);
            BodyAreaViewModel bAreaVM = new BodyAreaViewModel()
            {
                Name = bodyArea.Name,
                BodyAreaId = bodyArea.BodyAreaId,
                Description = bodyArea.Description,
                Image = bodyArea.Image,
                BodyParts = bodyArea.GetBodyPartsVM(db)
            };
            return bAreaVM;
        }


        public static MuscleViewModel CreateMuscleViewModel(this IMuscleRepository muscleRepo, IBodyPartRepository bPartRepo, int? Id)
        {
            Muscle muscle = muscleRepo.getMusceById(Id);
            MuscleViewModel muscleVM = new MuscleViewModel()
            {
                BodyPartId = muscle.BodyPartId,
                Description = muscle.Description,
                Image = muscle.Image,
                MuscleId = muscle.MuscleId,
                Name = muscle.Name,
                BodyParts = bPartRepo.BodyParts.ToList()
            };
            return muscleVM;
        }

        public static BodyAreaViewModel CreateBAreaViewModel(this BodyArea bArea, IBodyAreaRepository bAreaRepo, IBodyPartRepository bPartRepo, DBGetter db)
        {
            BodyAreaViewModel bAreaVM = new BodyAreaViewModel()
            {
                Name = bArea.Name,
                BodyAreaId = bArea.BodyAreaId,
                Description = bArea.Description,
                Image = bArea.Image,
                BodyParts = bArea.GetBodyPartsVM(db)
                
            };
            return bAreaVM;
        }

        public static MuscleViewModel CreateMuscleViewModel(this Muscle muscle, DBGetter db)
        {
            MuscleViewModel muscleVM = new MuscleViewModel()
            {
                BodyPartId = muscle.BodyPartId,
                Description = muscle.Description,
                Image = muscle.Image,
                MuscleId = muscle.MuscleId,
                Name = muscle.Name,
                BodyParts = db.bodyParts
            };

            return muscleVM;
        }

        public static ICollection<BodyPartsViewModel> GetBodyPartsVM(this BodyAreaViewModel bAreaVM, DBGetter db)
        {
            List<BodyPartsViewModel> bPartVMs = new List<BodyPartsViewModel>();
            foreach (var bPart in db.bodyParts)
            {
                if (bPart.BodyAreaId == bAreaVM.BodyAreaId)
                {
                    bPartVMs.Add(new BodyPartsViewModel()
                    {
                        Name = bPart.Name,
                        BodyAreaId = bPart.BodyAreaId,
                        Description = bPart.Description,
                        Image = bPart.Image,
                        BodyPartId = bPart.BodyPartId,
                        Muscles = bPart.GetListMuscleVM(db)
                    });
                }

            }

            return bPartVMs;
        }
        public static ICollection<BodyPartsViewModel> GetBodyPartsVM(this BodyArea bArea, DBGetter db)
        {
            List<BodyPartsViewModel> bPartVMs = new List<BodyPartsViewModel>();
            foreach (var bPart in db.bodyParts)
            {
                if (bPart.BodyAreaId == bArea.BodyAreaId)
                {
                    bPartVMs.Add(new BodyPartsViewModel()
                    {
                        Name = bPart.Name,
                        BodyAreaId = bPart.BodyAreaId,
                        Description = bPart.Description,
                        Image = bPart.Image,
                        BodyPartId = bPart.BodyPartId,
                        Muscles = bPart.GetListMuscleVM(db)
                    });
                }

            }

            return bPartVMs;
        }

        public static ICollection<MuscleViewModel> GetListMuscleVM (this BodyPartsViewModel bPartVM, DBGetter db)
        {
            List<MuscleViewModel> muscles = new List<MuscleViewModel>();
            foreach (var muscle in db.muscles)
            {
                if (muscle.BodyPartId == bPartVM.BodyPartId)
                {
                    muscles.Add(new MuscleViewModel()
                    {
                        BodyPartId = muscle.BodyPartId,
                        Description = muscle.Description,
                        Image = muscle.Image,
                        MuscleId = muscle.MuscleId,
                        Name = muscle.Name,
                        BodyParts = db.bodyParts
                    });
                }
               
            }

            return muscles;
        }

        public static ICollection<MuscleViewModel> GetListMuscleVM(this BodyPart bPart, DBGetter db)
        {
            List<MuscleViewModel> muscles = new List<MuscleViewModel>();
            foreach (var muscle in db.muscles)
            {
                if (muscle.BodyPartId == bPart.BodyPartId)
                {
                    muscles.Add(muscle.CreateMuscleViewModel(db));
                }

            }

            return muscles;
        }

        public static List<BodyAreaViewModel> CreateListBAreaVM(this List<BodyArea> bAreas, IBodyPartRepository bPart, IBodyAreaRepository bAreaRepo, DBGetter db)
        {
            List<BodyAreaViewModel> bAreasVM = new List<BodyAreaViewModel>();
            foreach (var bArea in bAreas)
            {
                bAreasVM.Add(bArea.CreateBAreaViewModel(bAreaRepo, bPart, db));
            }
            return bAreasVM;
        }

        public static BodyPartsViewModel CreateBPartViewModel(this IBodyPartRepository bPart, IBodyAreaRepository bodyArea, int? Id, DBGetter db)
        {
            BodyPart bodyPart = bPart.getBodyPartById(Id);
            BodyPartsViewModel bPartVM = new BodyPartsViewModel()
            {
                Name = bodyPart.Name,
                BodyAreaId = bodyPart.BodyAreaId,
                Description = bodyPart.Description,
                Image = bodyPart.Image,
                BodyPartId = bodyPart.BodyPartId,
                BodyAreas = bodyArea.BodyAreas.ToList(),
                Muscles = bodyPart.GetListMuscleVM(db)
            };

            return bPartVM;
        }
    }
}
