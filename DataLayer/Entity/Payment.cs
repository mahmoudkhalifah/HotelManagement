using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Payment
    {
        public int PaymentID { get; set; }
        
        public float TotalBill { get; set; }
        public float FoodBill { get; set; }

        [MaxLength(25)]
        public string CardType { get; set; }
        [MaxLength(10)]
        public string CardCVV { get; set; }
        [MaxLength(10)]
        public string CardExp { get; set; }
        [MaxLength(16)]
        public string CardNumber { get; set; }

        public Reservation Reservation { get; set; }
    }
}
