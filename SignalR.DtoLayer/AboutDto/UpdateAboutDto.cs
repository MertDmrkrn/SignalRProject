using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
    public class UpdateAboutDto
    {
        //güncelleme işleminde silmedim çünkü id'ye göre verileri güncelleyeceğiz
        public int AboutID { get; set; }

        public string ImgUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
