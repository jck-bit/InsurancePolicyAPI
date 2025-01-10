using System.ComponentModel.DataAnnotations;

namespace InsurancePolicyAPI.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Policy Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Policy Type is required.")]
        [RegularExpression("^(Life|Health|Vehicle|Universal Life)$", ErrorMessage = "Invalid policy type. Allowed types are: Life, Health, Vehicle, Universal Life.")]
        public required string Type { get; set; }

        [Required(ErrorMessage = "Premium is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Premium must be a positive number.")]
        public decimal Premium { get; set; }

        [Required(ErrorMessage = "Coverage is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Coverage must be a positive number.")]
        public decimal Coverage { get; set; }
    }
}
