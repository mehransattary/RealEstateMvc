using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.ViewModel
{
    public  class SearchViewModel
    {
        public int typemelk { get; set; }
        public int typecustumerId { get; set; }
        public int typeMahdodeId { get; set; }
        public double PriceFirst { get; set; }
        public double PriceEnd { get; set; }
        public int MinMeter { get; set; }
        public int MaxMeter { get; set; }
    }
}
