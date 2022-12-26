using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_game_engine
{
    public class Tile
    {
        public Vector2 position;
        public Vector2 scale;

        public Tile(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }
    }
}
