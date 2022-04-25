using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerceApp.Shared.Models;

namespace eCommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly eCommerceDbContext _context;

        public ProductsController(eCommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        [HttpGet("code/{productCode}")]
        public async Task<ActionResult<Products>> GetProductsForCode(string productCode)
        {
            var products = await _context.Products.Where(p => p.ProductCode == productCode).Select(p => p).FirstOrDefaultAsync();

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }



        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProducstResponse> PostProducts(Products products)
        {
            try
            {
                _context.Products.Add(products);
                await _context.SaveChangesAsync();

                return new ProducstResponse() { ok = true, msj = "El pruducto se a agregado con exito..." };
            }
            catch (Exception)
            {

                return new ProducstResponse() {msj = "Ocurrio un error..." };
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
