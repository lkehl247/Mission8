namespace Mission8.Models
{
    public class QuadrantViewModel
    {
        public List<Task> Quadrant1 { get; set; } = new();
        public List<Task> Quadrant2 { get; set; } = new();
        public List<Task> Quadrant3 { get; set; } = new();
        public List<Task> Quadrant4 { get; set; } = new();
    }
}