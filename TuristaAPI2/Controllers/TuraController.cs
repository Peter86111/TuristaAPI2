using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;
using TuristaAPI2.Models;

namespace TuristaAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TuraController : ControllerBase
    {
        [HttpPut("Modosit")]
        public async Task<IActionResult> PutModosit(Tura tura)
        {
            try
            {
                using (var cx = new TuristadbContext())
                {

                    cx.Update(tura);
                    await cx.SaveChangesAsync();
                    return StatusCode(200, "Sikeres módosítás!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Hiányzó túra!");
            }
        }
    }
}
