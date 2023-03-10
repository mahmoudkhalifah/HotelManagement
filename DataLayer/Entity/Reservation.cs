using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Reservation
    {
        public int ReservationID { get; set; }



        #region Room
        [MaxLength(50)]
        public string RoomType { get; set; }
        public int RoomFloor { get; set; }
        public int RoomNum { get; set; }
        public int GuestsNum { get; set; }
        #endregion

        public int BreakfastQty { get; set; }
        public int LunchQty { get; set; }
        public int DinnerQty { get; set; }
        public bool Cleaning { get; set; }
        public bool Towel { get; set; }
        public bool SweetSurprise { get; set; }
        public bool SupplyStatus { get; set; }
        public bool CheckIn { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime LeavingDate { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        [ForeignKey("PaymentID")]
        public Payment Payment { get; set; }
    }
}
