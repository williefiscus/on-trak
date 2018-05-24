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

namespace OnTrak.Models.ViewModel
{
    public static class BuildViewModel
    {
        public static BodyAreaViewModel CreateBAreaViewModel(this IBodyAreaRepository bArea, IBodyPartRepository bPart, int? Id)
        {
            BodyArea bodyArea = bArea.getBodyAreaById(Id);
            BodyAreaViewModel bAreaVM = new BodyAreaViewModel()
            {
                Name = bodyArea.Name,
                BodyAreaId = bodyArea.BodyAreaId,
                Description = bodyArea.Description,
                Image = bodyArea.Image,
                BodyParts = bodyArea.gGetBodyParts(bPart)
            };
            return bAreaVM;
        }

        public static BodyAreaViewModel CreateBAreaViewModel(this BodyArea bArea, IBodyPartRepository bPart)
        {
            BodyAreaViewModel bAreaVM = new BodyAreaViewModel()
            {
                Name = bArea.Name,
                BodyAreaId = bArea.BodyAreaId,
                Description = bArea.Description,
                Image = bArea.Image,
                BodyParts = bArea.gGetBodyParts(bPart)
            };
            return bAreaVM;
        }
        public static ICollection<BodyPart> gGetBodyParts(this BodyArea bArea, IBodyPartRepository bodyParts)
        {
            List<BodyPart> bParts = new List<BodyPart>();
            foreach (var part in bodyParts.BodyParts)
            {
                if (bArea.BodyAreaId == part.BodyAreaId)
                {
                    bParts.Add(part);
                }
            }
            return bParts;
        }

        public static List<BodyAreaViewModel> CreateListBAreaVM(this List<BodyArea> bAreas, IBodyPartRepository bPart)
        {
            List<BodyAreaViewModel> bAreasVM = new List<BodyAreaViewModel>();
            foreach (var bArea in bAreas)
            {
                bAreasVM.Add(bArea.CreateBAreaViewModel(bPart));
            }
            return bAreasVM;
        }

        public static BodyPartsViewModel CreateBPartViewModel(this IBodyPartRepository bPart, IBodyAreaRepository bodyArea, int? Id)
        {
            BodyPart bodyPart = bPart.getBodyPartById(Id);
            BodyPartsViewModel bPartVM = new BodyPartsViewModel()
            {
                Name = bodyPart.Name,
                BodyAreaId = bodyPart.BodyAreaId,
                Description = bodyPart.Description,
                Image = bodyPart.Image,
                BodyPartId = bodyPart.BodyPartId,
                BodyAreas = bodyArea.BodyAreas.ToList()
            };

            return bPartVM;
        }
    }
}
