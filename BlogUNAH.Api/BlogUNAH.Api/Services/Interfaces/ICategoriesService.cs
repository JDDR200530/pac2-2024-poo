using BlogUNAH.Api.Dtos.Categories;
using System.Reflection.Metadata.Ecma335;

namespace BlogUNAH.Api.Services.Interfaces
{
    public interface ICategoriesService
    {
        // Similar a una clse pero no es lo mismo (interfaz no permite crear logica{define un contrato})


        Task<List<CategoryDto>> GetCategoriesListAsync();

        Task<CategoryDto> GetCategoryByIdAsync(Guid id);

        Task<bool> CreateAsync(CategoryCreateDto dto);
        Task<bool> EditAsync(CategoryEditDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}