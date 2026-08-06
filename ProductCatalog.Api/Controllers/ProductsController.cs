using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IProductRepository repository,
            ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Consultando todos los productos.");

            var products = await _repository.GetAllAsync();

            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Consultando el producto con Id: {Id}", id);

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                _logger.LogWarning("Producto con Id: {Id} no fue encontrado.", id);
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _logger.LogInformation("Creando producto {Nombre}", product.Nombre);

            var result = await _repository.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            _logger.LogInformation("Iniciando actualización del producto con Id: {Id}", id);

            if (id != product.Id)
            {
                _logger.LogWarning("Discrepancia de datos: El Id de la ruta ({RouteId}) no coincide con el Id del producto ({ProductId}).", id, product.Id);
                return BadRequest();
            }

            await _repository.UpdateAsync(product);

            _logger.LogInformation("Producto con Id: {Id} actualizado correctamente.", id);
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Eliminando producto con Id: {Id}", id);
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        // GET api/products/search?name=mouse
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName(string name)
        {
            _logger.LogInformation("Buscando productos por nombre: {Name}", name);

            var products = await _repository.SearchByNameAsync(name);
            return Ok(products);
        }

        // GET api/products/category?category=Tecnología
        [HttpGet("category")]
        public async Task<IActionResult> SearchByCategory(string category)
        {
            _logger.LogInformation("Buscando productos por categoría: {Category}", category);

            var products = await _repository.SearchByCategoryAsync(category);
            return Ok(products);
        }

        // GET api/products/order/name
        [HttpGet("order/name")]
        public async Task<IActionResult> OrderByName()
        {
            _logger.LogInformation("Consultando productos ordenados por nombre.");

            var products = await _repository.OrderByNameAsync();
            return Ok(products);
        }

        // GET api/products/order/date
        [HttpGet("order/date")]
        public async Task<IActionResult> OrderByDate()
        {
            _logger.LogInformation("Consultando productos ordenados por fecha.");

            var products = await _repository.OrderByDateAsync();
            return Ok(products);
        }
        [HttpGet("error")]
        public IActionResult GenerateError()
        {
            throw new Exception("Este es un error de prueba.");
        }
    }
}