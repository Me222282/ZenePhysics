using Zene.Structs;

namespace Zene.Physics
{
    public struct PhysicsBounds : IPhysicsBounds, IBox
    {
        public PhysicsBounds(Vector2 location, Vector2 size)
        {
            _location = location;
            _size = size;
        }

        IBox IPhysicsBounds.Box => this;

        public double Left
        {
            get => _location.X - (_size.X * 0.5);
            set
            {
                double old = _location.X - (_size.X * 0.5);
                double dif = old - value;

                _size.X += dif;
                _location.X -= dif * 0.5;
            }
        }
        public double Right
        {
            get => _location.X + (_size.X * 0.5);
            set
            {
                double old = _location.X + (_size.X * 0.5);
                double dif = value - old;

                _size.X += dif;
                _location.X += dif * 0.5;
            }
        }
        public double Top
        {
            get => _location.Y + (_size.Y * 0.5);
            set
            {
                double old = _location.Y + (_size.Y * 0.5);
                double dif = value - old;

                _size.Y += dif;
                _location.Y += dif * 0.5;
            }
        }
        public double Bottom
        {
            get => _location.Y - (_size.Y * 0.5);
            set
            {
                double old = _location.Y - (_size.Y * 0.5);
                double dif = old - value;

                _size.Y += dif;
                _location.Y -= dif * 0.5;
            }
        }

        private Vector2 _location;
        public Vector2 Location
        {
            get => _location;
            set => _location = value;
        }
        Vector2 IBox.Centre => _location;

        private Vector2 _size;
        public Vector2 Size
        {
            get => _size;
            set => _size = value;
        }

        public double X
        {
            get => _location.X;
            set => _location.X = value;
        }
        public double Y
        {
            get => _location.Y;
            set => _location.Y = value;
        }
        public double Width
        {
            get => _size.X;
            set => _size.X = value;
        }
        public double Height
        {
            get => _size.Y;
            set => _size.Y = value;
        }
    }
}
