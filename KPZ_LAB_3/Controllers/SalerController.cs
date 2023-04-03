using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KPZ_LAB_3.Repository;
using KPZ_LAB_3.Repository.Models;
using KPZ_LAB_3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KPZ_LAB_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalerController : ControllerBase
    {
        private readonly JewelryStoreDbContext _context;
        private readonly IMapper _mapper;

        public SalerController(JewelryStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all salers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalerViewModel>>> GetSalers()
        {
            var salers = await _context.Salers.ToListAsync();
            //return Ok(_mapper.Map<List<SalerViewModel>>(salers));


            return Ok(_mapper.Map<List<UpdateSalerViewModel>>(salers));

        }

        /// <summary>
        /// Get specific saler by using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SalerViewModel>>> GetSaler(int id)
        {
            var saler = await _context.Salers.FindAsync(id);

            if (saler == null) return NotFound();

            return Ok(_mapper.Map<SalerViewModel>(saler));
        }

        /// <remarks>
        ///     Sample request:
        ///         PUT {
        ///             "name": "example",
        ///             "isManager": false
        ///             }
        /// </remarks>
        /// <summary>
        /// Alter saler info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saler"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaler(int id, [FromBody]UpdateSalerViewModel saler)
        {
            //if (id != saler.Id) return BadRequest();

            _context.Entry(saler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalerExists(id))
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

        /// <remarks>
        ///     Sample request:
        ///         POST {
        ///             "id": 2,
        ///             "name": "example",
        ///             "isManager": false
        ///             }
        /// </remarks>
        /// <summary>
        /// Create new saler
        /// </summary>
        /// <param name="saler"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateSaler([FromBody]SalerViewModel saler)
        {
            var model = _mapper.Map<Saler>(saler);

            _context.Salers.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaler", new { id = model.Id }, saler);
        }


       /// <summary>
       /// Delete specific saler by using id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaler(int id)
        {
            var saler = await _context.Salers.FindAsync(id);
            
            if (saler == null) return NotFound();

            _context.Salers.Remove(saler);

            await _context.SaveChangesAsync();

            return NoContent();
        }

       
        private bool SalerExists(int id)
        {
            return _context.Salers.Any(e => e.Id == id);
        }
    }
}
