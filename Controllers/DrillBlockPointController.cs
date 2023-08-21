using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using TestWorkC.DataContext;
using TestWorkC.Models;

namespace TestWorkC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrillBlockPointController : Controller
    {
        NpgApplicationContext context;

        public DrillBlockPointController(NpgApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(context.DrillBlocksPoints.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Json(context.DrillBlocksPoints.Single(m => m.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(DrillBlockPoints points)
        {
            var hasDrillBlock = context.DrillBlocks.Where(m => m.Id == points.DrillBlockId).FirstOrDefault();

            if (hasDrillBlock != null)
            {
                context.DrillBlocksPoints.Add(points);
                context.SaveChanges();
                return Json(points);
            }

            return BadRequest("No DrillBlockId");
        }
        [HttpPut]
        public IActionResult Update(DrillBlockPoints points)
        {
            var toUpdate = context.DrillBlocksPoints.Where(m => m.Id == points.Id).FirstOrDefault();
            var hasDrillBlock = context.DrillBlocks.Where(m => m.Id == points.DrillBlockId).FirstOrDefault();

            if (toUpdate != null && hasDrillBlock != null)
            {
                toUpdate.Sequence = points.Sequence;
                toUpdate.X = points.X;
                toUpdate.Y = points.Y;
                toUpdate.Z = points.Z;
                toUpdate.DrillBlockId = points.DrillBlockId;
                context.DrillBlocksPoints.Update(toUpdate);
                context.SaveChanges();

                return Json(points);
            }

            return BadRequest("No DrillBlockPointId or DrillBlockId");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var toDelete = context.DrillBlocksPoints.Where(m => m.Id == id).FirstOrDefault();

            if (toDelete != null)
            {
                context.DrillBlocksPoints.Remove(toDelete);
                context.SaveChanges();

                return Json(toDelete);
            }

            return BadRequest("Wrong Id");
        }

    }
}
