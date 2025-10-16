using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI_backend.DTOs;
using ProductAPI_backend.Models;
using ProductAPI_backend.Services;

namespace ProductTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public ProductsController(ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO, Guid> service,
            IValidator<ProductInsertDTO> insertValidator,
            IValidator<ProductUpdateDTO> updateValidator)
        {

            _service = service;
            _productInsertValidator = insertValidator;
            _productUpdateValidator = updateValidator;
        }

        private readonly ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO, Guid> _service;
        private IValidator<ProductInsertDTO> _productInsertValidator;
        private IValidator<ProductUpdateDTO> _productUpdateValidator;

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetProducts() => await _service.Get();


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById([FromRoute] Guid id)
        {
            var skateDto = await _service.GetById(id);
            return skateDto == null ? NotFound() : Ok(skateDto);
        }


        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductInsertDTO productInsertDTO)
        {
            var validationResult = await _productInsertValidator.ValidateAsync(productInsertDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (!_service.Validate(productInsertDTO))
            {
                return BadRequest(_service.Errors);
            }


            var productDto = await _service.Add(productInsertDTO);

            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromRoute] Guid id, [FromBody] ProductUpdateDTO productUpdateDTO)
        {

            var validationResult = await _productUpdateValidator.ValidateAsync(productUpdateDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (!_service.Validate(productUpdateDTO))
            {
                return BadRequest(_service.Errors);
            }

            var productDto = await _service.Update(id, productUpdateDTO);

            return productDto == null
                ? NotFound()
                : Ok(productDto);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProductDTO>> DeleteSkate(Guid id)
        {
            var skateDto = await _service.Delete(id);
            return skateDto == null ? NotFound() : Ok(skateDto);
        }
    }




}
