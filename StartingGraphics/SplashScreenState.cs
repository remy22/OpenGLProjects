﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    class SplashScreenState : IGameObject
    {
        StateSystem _stateSystem;
        double _delayInSeconds = 3;
        public SplashScreenState(StateSystem system)
        {
            _stateSystem = system;
        }

        public void Update(double elapsedTime)
        {
            _delayInSeconds -= elapsedTime;
            if (_delayInSeconds <= 0)
            {
                _delayInSeconds = 3;
                _stateSystem.ChangeState("title_menu");
            }
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glFinish();

        }
    }
}
