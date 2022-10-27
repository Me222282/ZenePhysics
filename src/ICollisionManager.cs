using System.Collections.Generic;

namespace Zene.Physics
{
    public interface ICollisionManager<T, B>
        where T : IPhysicsObject<B>
        where B : IPhysicsBounds
    {
        public void ManageCollisions(List<T> objs);
    }
}
