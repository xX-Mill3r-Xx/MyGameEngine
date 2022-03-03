using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameEngine.Express;

namespace GameEngine
{
    class DemoGame : Express.Gengine
    {
        Shape2D player;
        public DemoGame() : base(new Vector2(615, 515), "GameEngine Demo") { }

        public override void OnLoad()
        {
            BGcolor = Color.Black;

            player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Teste");
        }

        public override void OnDraw()
        {

        }

        public override void OnUpdate()
        {
           
        }
    }
}
