using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Gym.GymSubscription.GymSubscriptionPayment
{
    public class clsInsertGymSubscriptionPaymentDTO
    {
        [Required(ErrorMessage = "Gym Subscription ID is Required")]
        public int? GymSubscriptionID { get; set; }

        [Required(ErrorMessage = "Payment Amount is Required")]
        public decimal? PaymentAmount { get; set; }

        [Required(ErrorMessage = "Currency ID is Required")]
        public byte? CurrencyID { get; set; }

        public decimal? PaymentAmountInCurrentCurrency { get; set; }

        public decimal? CurrencyPerDollar { get; set; }

        [Required(ErrorMessage = "Payment Method ID is Required")]
        public int? PaymentMethodID { get; set; }

        public string? Details { get; set; }
    }
}