using Maraton.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Maraton.Models.Dto;

namespace Maraton.Controllers
{
    [Route("Eredmények")]
    [ApiController]
    public class EredmenyekController : ControllerBase
    {
        private readonly Eredmenyek  EredmenyContext;

        

        [HttpPost]
        public async Task<ActionResult<Eredmenyek>> Post(CreateEredmenyekDto CreateEredmenyekDto)
        {
            var os = new Eredmenyek
            {
                Kor  =CreateEredmenyekDto.kor,
                Ido = CreateEredmenyekDto.ido,
                Futo = CreateEredmenyekDto.futo,

               
            };

            if (os == null)
            {
                await EredmenyContext.Eredmenyek.AddAsync(os);
                return StatusCode(201, os);

            }
            return BadRequest();


        }
        [HttpGet]
        public async Task<ActionResult<Eredmenyek>> Get()
        {
            return Ok(await EredmenyContext.Eredmenyek.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Eredmenyek>> GetById(Guid id)
        {
            var os = EredmenyContext.Eredmenyek.FirstOrDefaultAsync(x => x.Id == id);
            if (os != null)
            {
                return Ok(os);
            }

            return NotFound(new { Message = "Nincs ilyen találat" });
        }
    }
}
