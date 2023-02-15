using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SPTC.ApplicationData
{
    public partial class Tarifs
    {
        public string CorrectImage
        {
            get
            {
                if (String.IsNullOrEmpty(tarifs_photo) || String.IsNullOrWhiteSpace(tarifs_photo))
                {
                    return "/Resources/picture.jpg";
                }
                else
                {
                    return AppDomain.CurrentDomain.BaseDirectory + "../../Resources/" + tarifs_photo;
                }
            }
        }
    }
}
