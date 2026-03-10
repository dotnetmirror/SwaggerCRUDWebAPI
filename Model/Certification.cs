using System.ComponentModel.DataAnnotations;

namespace SwaggerCRUDWebAPI.Model
{
    public class Certification
    {
        [Required]
        public string? Code { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime ExamDate { get; set; }

    }
}
