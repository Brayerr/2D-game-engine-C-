using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2D_game_engine
{
    delegate void InitializeTileMapDele(Tile[,] tileMap, int rows, int columns);

    public abstract class TheEngine
    {
        private Vector2 screenSize = new Vector2(512, 512);
        public string title { get; protected set; }
        private Canvas window = null;
        private Thread gameLoopThread = null;
        private int threadSleepTime = 1;
        private Color BGColor = Color.Gray;

        public static Tile[,] tileMap = new Tile[8, 8];



        public TheEngine(Vector2 screenSize, string title)
        {
            this.screenSize = screenSize;
            this.title = title;

            window = new Canvas();
            window.Size = new Size((int)screenSize.x, (int)screenSize.y);
            window.Text = this.title;
            window.Paint += Window_Paint;


            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(window);
        }

        private void Window_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.Clear(BGColor);

            foreach (var item in tileMap)
            {
                graphics.DrawRectangle(new Pen(Color.Black), item.position.x, item.position.y, item.scale.x, item.scale.y);
            }
        }

        public static void InitializeTileMap(Tile[,] map, int rows, int columns)
        {
            Vector2 tilePos = new Vector2(30, 0);
            for (int i = 0; i < rows; i++)
            {
                tilePos = new Vector2(30, tilePos.y + 30);

                for (int j = 0; j < columns; j++)
                {
                    map[i, j] = new Tile((tilePos), new Vector2(30, 30));
                    tilePos = new Vector2(tilePos.x + 30, tilePos.y);
                }
            }
        }





        void GameLoop()
        {
            OnLoad();

            while (gameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    window.BeginInvoke((MethodInvoker) delegate { window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(threadSleepTime);

                }
                catch 
                {
                    Log.ErrorMessage("Game still loading...");
                }
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
    }
}
