using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }
        public char Figure { get; set; }
        public GameObjectType GameObjectType { get; set; }

    }
}
