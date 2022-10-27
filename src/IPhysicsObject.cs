using System;
using System.Collections.Generic;
using Zene.Structs;

namespace Zene.Physics
{
    public interface IPhysicsObject<T> where T : IPhysicsBounds
    {
        public T Bounds { get; }
        public IBox BoundingBox { get; }
        public double Mass { get; }
        public double CompressiveStrength { get; }
        /// <summary>
        /// Centre of Mass. The reference location for the object.
        /// </summary>
        public Vector2 COM { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Radian Rotation { get; set; }

        public bool Static { get; }

        public Vector2 ResultantForce { get; set; }
        public List<IForceController> Forces { get; }
        //public List<Collision> Collisions { get; }

        public void PushForce(Vector2 force);
    }
}
