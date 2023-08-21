namespace TestWorkC.Models
{
    public class Hole : BaseModel
    {
        public string Name { get; set; } = null!;
        public int DrillBlockId { get; set; }
        public double DEPTH { get; set; }
    }
}
