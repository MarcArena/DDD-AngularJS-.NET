using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Domain.Modules.Hotel.Entities
{
    public enum RateTypes { PerNight, Stay };

    public class Hotel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }

        private IList<Rate> _hotelRates = new List<Rate>();

        public IEnumerable<Rate> rates
        {
            get { return _hotelRates; }
        }

        public void AddRate(RateTypes rateType, string boardType, double value, int nights)
        {
            if (this._hotelRates == null)            
                _hotelRates = new List<Rate>();            
    
            var existsRate = _hotelRates.FirstOrDefault(c => c.rateType == rateType && c.boardType == boardType && c.value == value);

            if (existsRate != null) _hotelRates.Remove(existsRate);
            
            this._hotelRates.Add(new Rate(rateType_: rateType, boardType_: boardType, value_: value, nights: nights ));
        }
    }

    public class Rate
    {
        public Rate(RateTypes rateType_, string boardType_, double value_, int nights)
        {
            rateType = rateType_;
            boardType = boardType_;
            value = value_;

            SetFinalPrice(nights);
        }

        public RateTypes rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
        public double finalPrice { get; set; }

        public void SetFinalPrice(int numberOfNights)
        {
            this.finalPrice =
                this.rateType == RateTypes.PerNight ?
                this.value * numberOfNights :
                this.value;
        }
    }


}
