using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestWorkC.Models
{
    public class DrillBlock : BaseModel
    {
        public string Name { get; set; } = null!;
        public DateOnly UpdateDate { get; set; }
        
    }
}
