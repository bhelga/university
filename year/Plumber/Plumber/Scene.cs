using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class Scene
    {
        List<GameObject> tubes;
        List<GameObject> background;

        private static Scene _scene;

        private Scene()
        {
        }
        
        public static Scene GetScene()
        {
            if (_scene == null)
            {
                
            }
            return _scene;
        }

    }
}
