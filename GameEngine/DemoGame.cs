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
        //Sprite2D player2;

        bool left, right, up, down;

        Vector2 lastPos = Vector2.Zero();

        string[,] Map =
        {
            /*Intro: Tudo que for g é Ground
             tudo que é c é coletavel no cenario;*/

            {"g","g","g","g","g","g","g","g","g","g","g","g","g","g","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".","p",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g",".",".",".",".",".",".",".",".",".",".",".",".",".","g",},
            {"g","g","g","g","g","g","g","g","g","g","g","g","g","g","g",},
        };

        public DemoGame() : base(new Vector2(615, 515), "GameEngine Demo") { }

        public override void OnLoad()
        {
            BGcolor = Color.Black;
            CameraZoom = new Vector2(.8f, .8f);
            Sprite2D groundRef = new Sprite2D("Tiles/b_tiles/Ground_Areia");
            Sprite2D CoinRef = new Sprite2D("Tiles/c_tiles/colectc");

            //player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Teste");
            //player = new Sprite2D(new Vector2(10, 10), new Vector2(30, 30), "Players/Player Grey/Player_Idle", "Player");

            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if(Map[j,i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 50f, j * 50f), new Vector2(50, 50), groundRef, "Ground");
                    }

                    if (Map[j, i] == "c")
                    {
                        new Sprite2D(new Vector2(i * 50f, j * 50f), new Vector2(20, 20), CoinRef, "Coin");
                    }

                    if (Map[j, i] == "p")
                    {
                        player = new Sprite2D(new Vector2(i * 50f, j * 50f), new Vector2(30, 30), "Players/Player Grey/Player_Idle", "Player");
                    }
                }
            }



            #region Descrição para add Player
            //player = new Sprite2D(new Vector2(Start Player position X, Start Player position Y), new Vector2(Tamanho X, Tamanho Y), "Pasta/SubPasta/Nome Sprite", "Tag");
            #endregion

            //Add o - Camera.Position; Caso de algum bug, retirar;
            //player = new Sprite2D(new Vector2(100 - CameraPosition.X,100 - CameraPosition.Y), new Vector2(30,30), "Players/Player Grey/Player_Idle", "Player");
           
        }

        public override void OnDraw()
        {

        }


        public override void OnUpdate()
        {
            int Times = 0;
            Times++;

            if (player == null)
                return;
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

            Sprite2D coin = player.IsCollidind("Coin");
            if(coin != null)
            {
                coin.DestroySelf();
            }

            if(player.IsCollidind("Ground") != null)
            {
                //Log.Info($"Colidindo {Times}");
                //Times++;
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            else
            {
                #region Obs.:
                //if(Times > 10)
                //{
                //    lastPos = player.Position;
                //    Times = 0;
                //}
                #endregion

                lastPos.X = player.Position.X;
                lastPos.Y = player.Position.Y;
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
