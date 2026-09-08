using System;
using System.ComponentModel.DataAnnotations;

namespace GYM_DTO.Object.FitnessType
{
    public class clsBaseFitnessTypeDTO
    {
        [Required(ErrorMessage = "Fitness type name is required.")]
        public string? FitnessTypeName { get; set; }
    }
}