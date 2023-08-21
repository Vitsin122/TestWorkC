using Microsoft.AspNetCore.Mvc;
using TestWorkC.DataContext;
using TestWorkC.Models;

namespace TestWorkC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrillBlockController : Controller
    {
        NpgApplicationContext context;
        public DrillBlockController(NpgApplicationContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult All()
        {
            return Json(context.DrillBlocks.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Json(context.DrillBlocks.Single(m => m.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(DrillBlock drillBlock)
        {
            context.DrillBlocks.Add(drillBlock);    
            context.SaveChanges();
            return Json(drillBlock);
        }
        [HttpPut]
        public IActionResult Update(DrillBlock drillBlock)
        {
            try
            {
                var toUpdate = context.DrillBlocks.FirstOrDefault(m => m.Id == drillBlock.Id);

                toUpdate.Name = drillBlock.Name;
                toUpdate.UpdateDate = drillBlock.UpdateDate;

                context.DrillBlocks.Update(toUpdate);
                context.SaveChanges();

                return Json(toUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var delete = context.DrillBlocks.Single(m => m.Id == id);
                context.DrillBlocks.Remove(delete);
                context.SaveChanges();

                return Json(delete);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
