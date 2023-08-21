namespace TestWorkC.Models
{
    public class DrillBlockPoints : BaseModel
    {
        public int DrillBlockId { get; set; }
        public int Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
