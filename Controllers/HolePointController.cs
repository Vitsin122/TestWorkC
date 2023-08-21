using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using TestWorkC.DataContext;
using TestWorkC.Models;

namespace TestWorkC.Controllers
{

    public class HolePointController : Controller
    {
        NpgApplicationContext context;

        public HolePointController (NpgApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(context.HolePoints.ToArray());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Json(context.HolePoints.Single(m => m.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(HolePoints points)
        {
            var hasHole = context.Holes.Where(m => m.Id == points.Id).FirstOrDefault();

            if (hasHole != null)
            {
                context.HolePoints.Add(points);
                context.SaveChanges();
                return Json(points);
            }

            return BadRequest("Wrong HoleId");
        }
        [HttpPut]
        public IActionResult Edit(HolePoints points)
        {
            var toUpdate = context.HolePoints.Where(m => m.Id == points.Id).FirstOrDefault();
            var hasHole = context.Holes.Where(m => m.Id == points.HoleId).FirstOrDefault();

            if (toUpdate != null && hasHole != null)
            {
                toUpdate.X = points.X;
                toUpdate.Y = points.Y;
                toUpdate.Z = points.Z;
                toUpdate.HoleId = points.HoleId;
                context.HolePoints.Update(toUpdate);
                context.SaveChanges();
                return Json(points);
            }

            return BadRequest("Wrong HoleId");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var toDelete = context.HolePoints.Single(m => m.Id == id);
                context.HolePoints.Remove(toDelete);
                context.SaveChanges();
                return Json(toDelete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
