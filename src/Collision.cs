namespace Zene.Physics
{
    public readonly struct Collision
    {
        public Collision(IPhysicsObject<IPhysicsBounds> obj, double pp)
        {
            Object = obj;
            PathPercentage = pp;
        }

        public IPhysicsObject<IPhysicsBounds> Object { get; }
        public double PathPercentage { get; }
    }
}
