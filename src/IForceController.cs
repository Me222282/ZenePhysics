using Zene.Structs;

namespace Zene.Physics
{
    public interface IForceController
    {
        public double Strength { get; set; }
        public bool Pressure { get; }

        public Vector2 GetForce<T>(IPhysicsObject<T> @object, out Vector2 point) where T : IPhysicsBounds;
        public Pressure GetPressure<T>(IPhysicsObject<T> @object) where T : IPhysicsBounds;
    }
}
