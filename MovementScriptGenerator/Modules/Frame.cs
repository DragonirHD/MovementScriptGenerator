
namespace MovementScriptGenerator.Modules
{
    public class Frame
    {
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public float Duration { get; set; }
        public float HoldTime { get; set; }
        public string Transition { get; set; }
        public float Fov { get; set; }
    }
}
