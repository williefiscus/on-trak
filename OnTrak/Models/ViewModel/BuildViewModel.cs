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

namespace OnTrak.Models.ViewModel
{
    public static class BuildViewModel
    {
        public static BodyAreaViewModel createBAreaViewModel(this IBodyAreaRepository bArea, IBodyPartRepository bPart, int? Id)
        {
            BodyArea bodyArea = bArea.getBodyAreaById(Id);
            BodyAreaViewModel bAreaVM = new BodyAreaViewModel()
            {
                Name = bodyArea.Name,
                Id = bodyArea.Id,
                Description = bodyArea.Description,
                NumberOfParts = bodyArea.NumberOfParts,
                Image = bodyArea.Image,
                BodyParts = bPart.BodyParts.ToList()
            };
            return bAreaVM;
        }

        public static BodyAreaViewModel createBAreaViewModel(this BodyArea bArea, IBodyPartRepository bPart)
        {
            BodyAreaViewModel bAreaVM = new BodyAreaViewModel()
            {
                Name = bArea.Name,
                Id = bArea.Id,
                Description = bArea.Description,
                NumberOfParts = bArea.NumberOfParts,
                Image = bArea.Image,
                BodyParts = bPart.BodyParts.ToList()
            };
            return bAreaVM;
        }

        public static List<BodyAreaViewModel> createListBAreaVM(this List<BodyArea> bAreas, IBodyPartRepository bPart) {
            List<BodyAreaViewModel> bAreasVM = new List<BodyAreaViewModel>();
            foreach (var bArea in bAreas)
            {
                bAreasVM.Add(bArea.createBAreaViewModel(bPart));
            }
            return bAreasVM;
        }
    }
}
