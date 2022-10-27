using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zene.Structs;

namespace Zene.Physics
{
    public interface IPhysicsBounds
    {
        public IBox Box { get; }
    }
}
