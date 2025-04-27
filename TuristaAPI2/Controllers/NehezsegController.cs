using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuristaAPI2.Models;

namespace TuristaAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NehezsegController : ControllerBase
    {
        [HttpPost("Uj")]
        public async Task<IActionResult> PostUj(Nehezseg nehezseg)
        {
            try
            {
                using (var cx = new TuristadbContext())
                {
                    await cx.AddAsync(nehezseg);
                    await cx.SaveChangesAsync();
                    return StatusCode(200, "Sikeres mentés.");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return StatusCode(406, $"Már létező jelzés: {nehezseg.Jelzes}");
                }
                else
                {
                    return StatusCode(400, $"Hiba a rögzítés közben: {ex.Message}");
                }
            }           
        }

        [HttpDelete]
        public IActionResult Delete(Nehezseg nehezseg)
        {
            try
            {
                using (var cx = new TuristadbContext())
                {
                    cx.Remove(nehezseg);
                    cx.SaveChanges();
                    return StatusCode(200, "Sikeres törlés.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Nem létező nehézségi fok.");
            }
        }
    }
}
