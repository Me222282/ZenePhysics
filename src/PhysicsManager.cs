using System;
using System.Collections.Generic;

namespace Zene.Physics
{
    public class PhysicsManager<ObjT, BoxT>
        where ObjT : IPhysicsObject<BoxT>
        where BoxT : IPhysicsBounds
    {
        public PhysicsManager(ICollisionManager<ObjT, BoxT> collisionManager)
        {
            _collisionManager = collisionManager;
        }

        public List<ObjT> Objects { get; } = new List<ObjT>();
        public List<IForceController> GlobalForces { get; } = new List<IForceController>();

        private readonly ICollisionManager<ObjT, BoxT> _collisionManager;

        public void ManageFrame(double frameTime)
        {
            // Initial forces
            foreach (ObjT obj in Objects)
            {
                if (obj.Static) { return; }

                // Resolve forces
                for (int i = 0; i < obj.Forces.Count; i++)
                {
                    obj.ResultantForce += obj.Forces[i].GetForce(obj, out _);
                }

                for (int i = 0; i < GlobalForces.Count; i++)
                {
                    obj.PushForce(GlobalForces[i].GetForce(obj, out _));
                }

                // Apply forces
                obj.Acceleration = obj.ResultantForce / obj.Mass;
                obj.Velocity += obj.Acceleration;
                obj.ResultantForce = 0d;
            }

            // Find collisions
            _collisionManager.ManageCollisions(Objects);

            // Collision forces
            // Apply final velocity
            foreach (ObjT obj in Objects)
            {
                if (obj.Static) { return; }
                /*
                // Resolve collisions
                for (int i = 0; i < obj.Collisions.Count; i++)
                {
                    double l = obj.Collisions[i].PathPercentage;
                    // Final velocity
                    double v = obj.Velocity.Length;
                    // Initial velocity
                    double u = (obj.Velocity - obj.Acceleration).Length;
                    // Displacement
                    double s = v * l;

                    // Time taken
                    double t = (2d * s) / (v + u);

                    double ot = 1d - obj.Collisions[i].Object.CompressiveStrength;

                    obj.ResultantForce += (obj.Mass * -obj.Velocity) / (t + ot);
                }

                // Apply forces
                obj.Acceleration = obj.ResultantForce / obj.Mass;
                obj.Velocity += obj.Acceleration;
                obj.ResultantForce = 0d;*/

                obj.COM += obj.Velocity * frameTime;
            }
        }
        
        public static void ResolveCollision(ObjT obj, Collision collision)
        {
            double l = collision.PathPercentage;
            // Final velocity
            double v = obj.Velocity.Length;
            // Initial velocity
            double u = (obj.Velocity - obj.Acceleration).Length;
            // Displacement
            double s = v * l;

            // Time taken
            double t = (2d * s) / (v + u);

            double ot = 1d - collision.Object.CompressiveStrength;

            //obj.ResultantForce += (obj.Mass * -obj.Velocity) / (t + ot);
            obj.Velocity += (-obj.Velocity) / (t + ot);
        }
    }
}
