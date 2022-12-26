using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_game_engine
{
    class Demo : TheEngine
    {
        InitializeTileMapDele dele = (InitializeTileMap);
        public Demo(Vector2 screenSize, string title) : base(screenSize, title)
        {

        }


        public override void OnLoad()
        {
            Log.InfoMessage("Game loaded.");
            dele?.Invoke(tileMap, 8, 8);
            Log.InfoMessage("TileMap loaded.");
        }
        public override void OnDraw()
        {
            
        }


        public override void OnUpdate()
        {
                     
        }


    }
}
