using System;
using Zene.Structs;

namespace Zene.Physics
{
    public class BasicForce : IForceController
    {
        public BasicForce(Vector2 direction, double strength)
        {
            Direction = direction.Normalised();
            Strength = strength;
        }

        public Vector2 Direction { get; set; }
        public double Strength { get; set; }
        bool IForceController.Pressure => false;

        public Vector2 GetForce<T>(IPhysicsObject<T> @object, out Vector2 point) where T : IPhysicsBounds
        {
            point = @object.COM;
            return Direction * Strength;
        }
        public Pressure GetPressure<T>(IPhysicsObject<T> @object) where T : IPhysicsBounds
        {
            throw new NotSupportedException();
        }
    }
}
