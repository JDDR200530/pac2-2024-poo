using System.ComponentModel.DataAnnotations;

namespace BlogUNAH.API.Database.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        // Data Annotations
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0}  de la categories es requerido")]
        public string Name { get; set; }
        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "La {0} debe tener al menos {1} caracteres")]
        public string Description { get; set; }

    }
}