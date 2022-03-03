using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Express;

namespace GameEngine
{
    class DemoGame : Express.Gengine
    {
        public DemoGame() : base(new Vector2(615,515), "GameEngine Demo") { }
    }
}
