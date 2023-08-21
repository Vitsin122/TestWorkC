using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWorkC.Models;
using TestWorkC.DataContext;

namespace TestWorkC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HoleController : Controller
    {

        NpgApplicationContext context;
        public HoleController(NpgApplicationContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(context.Holes.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Json(context.Holes.Single(m => m.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(Hole hole)
        {
            var hasDrillBlok = context.DrillBlocks.Where(m => m.Id == hole.DrillBlockId).FirstOrDefault();

            if (hasDrillBlok != null)
            {
                context.Holes.Add(hole);
                context.SaveChanges();
                return Json(hole);
            }

            return BadRequest("No drillhole id");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var toDelete = context.Holes.Where(m => m.Id == id).FirstOrDefault();

            if (toDelete != null)
            {
                context.Holes.Remove(toDelete);
                context.SaveChanges();
                return Json(toDelete);
            }

            return BadRequest("No hole id");
        }
        [HttpPut]
        public IActionResult Edit(Hole hole) 
        {
            var toUpdate = context.Holes.Where(m => m.Id == hole.Id).FirstOrDefault();
            var hasDrillBlock = context.DrillBlocks.Where(m => m.Id == hole.DrillBlockId).FirstOrDefault();

            if (toUpdate != null &&  hasDrillBlock != null)
            {
                toUpdate.Name = hole.Name;
                toUpdate.DEPTH = hole.DEPTH;
                toUpdate.DrillBlockId = hole.DrillBlockId;

                context.Holes.Update(toUpdate);
                context.SaveChanges();
                return Json(hole);
            }

            return BadRequest("No holeId or DrillBlockId");
        }
    }
}
