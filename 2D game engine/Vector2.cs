using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_game_engine
{
    public struct Vector2
    {
        public float x { get; private set; }
        public float y { get; private set; }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
