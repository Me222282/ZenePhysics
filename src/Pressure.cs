using Zene.Structs;

namespace Zene.Physics
{
    public struct Pressure
    {
        public Pressure(Vector2 a, Vector2 b, double strength)
        {
            Strength = strength;
            Area = a.Distance(b);
            Position = a.Lerp(b, 0.5);
            Direction = a.PerpDot(b);
        }

        public double Strength { get; }

        public double Area { get; }
        public Vector2 Position { get; }
        public Vector2 Direction { get; }
    }
}
