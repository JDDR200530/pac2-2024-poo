
using BlogUNAH.Api.Dtos.Categories;
using BlogUNAH.Api.Services.Interfaces;
using BlogUNAH.API.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BlogUNAH.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private List<Category> _categories;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            // Eliminamos
            //    _categories = new List<Category>
            //    {
            //        new Category { Id = Guid.Parse("b8822aaf-b34c-4c06-bb9c-d56a6e784f01"), Name ="Javascript", Description ="El lenguaje mas facil del mundo" },
            //        new Category { Id = Guid.Parse("6e517a89-71e3-4404-aa9b-346af4698c7e"), Name ="IA", Description ="Tecnologia de moda 2024" },
            //        new Category { Id = Guid.Parse("43efe324-1a6c-44fa-b876-f9900809257c"), Name ="Node.JS", Description ="Entrono de ejecuccion de JavaScriot" }
            //    };
            this._categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriesService.GetCategoriesListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var category = await _categoriesService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { Message = $"No se encontró la categoría: {id}" });
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryCreateDto dto)
        {
            //bool categoryExist = _categories.Any(x => x.
            //Name.ToUpper().Trim().Contains(category.Name.ToUpper()));

            //if (!categoryExist)
            //{
            //    return BadRequest("La categoria ya esta registrada");
            //}

            //category.Id = Guid.NewGuid();

            //_categories.Add(category);
            /////if (category.Name.Equals("") { }
            ///VALIDACION DENTRO DEL CONTROLLER
            //if (string.IsNullOrEmpty(category.Name)) 
            //{
            //    return BadRequest(new { Message = "El nombre de la categoria es requerido" });
            //}
            //if(!string.IsNullOrEmpty(category.Description) && category.Description.Length < 10)
            //{
            //    return BadRequest(new {Message = "La descripción debe tener al menos 10 catacteres"});
            //}
            await _categoriesService.CreateAsync(dto);



            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(CategoryEditDto dto, Guid id)
        {
            var result = await _categoriesService.EditAsync(dto, id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _categoriesService.GetCategoryByIdAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            await _categoriesService.DeleteAsync(id);
            return Ok();
        }
    }
}
