using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    
    class DrawSpriteState : IGameObject
    {
        TextureManager _textureManager;

        public DrawSpriteState(TextureManager textureManager)
        {
            _textureManager = textureManager;
        }
        double _currentRotation = 0;

        public void Update(double elapsedTime)
        {
            _currentRotation = 10 * elapsedTime;
        }

        public void Render()
        {

            double height = 200;
            double width = 200;
            double halfHeight = height / 2;
            double halfWidth = width / 2;

            double x = 0;
            double y = 0;
            double z = 10;

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glRotated(_currentRotation, 1, 1, 1);
            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                Gl.glVertex3d(x-halfWidth, y+halfHeight, z);
                Gl.glVertex3d(x+halfWidth, y+halfHeight, z);
                Gl.glVertex3d(x-halfWidth, y-halfHeight, z);

                Gl.glVertex3d(x+halfWidth, y+halfHeight, z);
                Gl.glVertex3d(x+halfWidth, y-halfHeight, z);
                Gl.glVertex3d(x-halfWidth, y-halfHeight, z);
            }
            Gl.glEnd();
        }
    }
}
