using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameEngine.Express;
using System.Windows.Forms;

namespace GameEngine
{
    class DemoGame : Express.Gengine
    {
        Sprite2D player;

        bool left, right, up, down;

        string[,] Map =
        {
            {".",".",".",".",".",".","." },
            {".",".",".",".",".","g","." },
            {".",".",".",".","g","g","." },
            {".",".","g","g","g","g","." },
            {"g","g","g","g","g","g","g" },
            {".",".",".",".",".",".","." },
        };

        public DemoGame() : base(new Vector2(615, 515), "GameEngine Demo") { }

        public override void OnLoad()
        {
            BGcolor = Color.Black;

            //player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Teste");
            //player = new Sprite2D(new Vector2(10, 10), new Vector2(30, 30), "Players/Player Grey/Player_Idle", "Player");

            for(int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if(Map[j,i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 49, j * 49), new Vector2(50, 50), "Tiles/b_tiles/Ground_Areia", "Ground");
                    }
                }
            }

            player = new Sprite2D(new Vector2(30,30), new Vector2(30,30), "Players/Player Grey/Player_Idle", "Player");
        }

        public override void OnDraw()
        {

        }

        public override void OnUpdate()
        {
            if (up)
            {
                player.Position.Y -= 5f;
            }

            if (down)
            {
                player.Position.Y += 5f;
            }

            if (left)
            {
                player.Position.X -= 5f;
            }

            if (right)
            {
                player.Position.X += 5f;
            }
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
        }
    }
}
