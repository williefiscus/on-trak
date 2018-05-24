using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTrak.Models.UIModel
{
    public class SmallButtonModel
    {
        public string Action { get; set; }
        public string Controller { get
            {
                string controller = "";
                if (BodyAreaId != null || BodyAreaId > 0)
                {
                    controller = "BodyArea";
                }
                if (BodyPartId != null || BodyPartId > 0)
                {
                    controller = "BodyPart";
                }
                if (MuscleId != null || MuscleId > 0)
                {
                    controller = "Muscle";
                }
                return controller;

            }
        }
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }
        public int? Id { get; set; }
        public int? BodyAreaId { get; set; }
        public int? BodyPartId { get; set; }
        public int? MuscleId { get; set; }
        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder("?");
                if (Id != null && Id > 0)
                {
                    param.Append(String.Format("{0}={1}&", "Id", Id));
                }
                if (BodyAreaId != null || BodyAreaId > 0)
                {
                    param.Append(String.Format("{0}={1}&", "Id", BodyAreaId));
                }
                if (BodyPartId != null || BodyPartId > 0)
                {
                    param.Append(String.Format("{0}={1}&", "Id", BodyPartId));
                }
                if (MuscleId != null || MuscleId > 0)
                {
                    param.Append(String.Format("{0}={1}&", "Id", MuscleId));
                }
                return param.ToString().Substring(0, param.Length - 1);
            }
        }
    }
}
