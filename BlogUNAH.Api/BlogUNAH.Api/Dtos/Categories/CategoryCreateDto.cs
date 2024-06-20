using System.ComponentModel.DataAnnotations;

namespace BlogUNAH.Api.Dtos.Categories
{
    public class CategoryCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es requirido")]
        
        public string Name { get; set; }
        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "La {0} debe tener al menos {1} caracteres")]

        public string Description { get; set; }
    }
}
