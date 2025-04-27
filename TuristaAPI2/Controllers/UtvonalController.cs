using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Digests;
using System.Text.Json.Nodes;
using TuristaAPI2.Models;

namespace TuristaAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UtvonalController : ControllerBase
    {
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                using (var cx = new TuristadbContext())
                {
                    var response = cx.Utvonals
                        .Include(u => u.Nehezseg)
                        .ToList();
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Hiba a beolvasás közben: {ex.Message}");
            }
        }

        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            try
            {
                using (var cx = new TuristadbContext())
                {
                    var result = cx.Utvonals
                        .Include(u => u.Nehezseg)
                        .FirstOrDefault(u => u.Id == id);
                    if (result != null)
                    {
                        var JsonObject = new JsonObject
                        {
                            ["id"] = result.Id,
                            ["allomasok"] = result.Allomasok,
                            ["tav"] = result.Tav,
                            ["nehezseg"] = result.Nehezseg.Leiras
                        };
                        return StatusCode(200, JsonObject);
                    }
                    else 
                    {
                        return StatusCode(419, "Valószínűleg nincs ilyen túra.");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
