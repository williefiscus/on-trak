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
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }
        public int? Id { get; set; }
        public int? BodyAreaId { get; set; }
        public int? BodyPartId { get; set; }
        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder("?");
                if (Id != null && Id > 0)
                {
                    param.Append(String.Format("{0}={1}&", "id", Id));
                }
                if (BodyAreaId != null && BodyAreaId > 0)
                {
                    param.Append(String.Format("{0}={1}&", "BodyAreaId", BodyAreaId));
                }
                if (BodyPartId != null && BodyPartId > 0)
                {
                    param.Append(String.Format("{0}={1}&", "BodyPart", BodyPartId));
                }
                return param.ToString().Substring(0, param.Length - 1);
            }
        }
    }
}
