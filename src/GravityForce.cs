﻿using System;
using Zene.Structs;

namespace Zene.Physics
{
    public class GravityForce : IForceController
    {
        public GravityForce(double strength)
        {
            Strength = strength;
        }

        public double Strength { get; set; }
        bool IForceController.Pressure => false;

        public Vector2 GetForce<T>(IPhysicsObject<T> @object, out Vector2 point) where T : IPhysicsBounds
        {
            point = @object.COM;
            return (0d, -Strength * @object.Mass);
        }
        public Pressure GetPressure<T>(IPhysicsObject<T> @object) where T : IPhysicsBounds
        {
            throw new NotSupportedException();
        }
    }
}
