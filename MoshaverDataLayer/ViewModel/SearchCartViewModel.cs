using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.ViewModel
{
    public class SearchCartViewModel
    {
        public int MelkId { get; set; }
        public string melkimgL { get; set; }
        public string melkimgS { get; set; }
        public string melkimgB { get; set; }
        public string Title { get; set; }
        public string emkanat { get; set; }
        public double PriceAll { get; set; }
        public int Rooms { get; set; }
        public int Wc { get; set; }
        public int Meter { get; set; }
        public int cityID { get; set; }
        public int typemelk { get; set; }
    }
}
