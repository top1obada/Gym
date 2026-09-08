using System;
using System.ComponentModel.DataAnnotations;

namespace GYM_DTO.Object.GymSubscriptionType
{
    public class clsGymSubscriptionTypeLimitsDTO
    {
        [Required(ErrorMessage = "Available fitness types count is required.")]
        public int? AvailableFitnessTypesCount { get; set; }

        [Required(ErrorMessage = "Available trainees count is required.")]
        public int? AvailableTraineesCountByFitnessType { get; set; }

        [Required(ErrorMessage = "Available sections count is required.")]
        public int? AvailableFitnessTypesSectionsCount { get; set; }
    }
}
