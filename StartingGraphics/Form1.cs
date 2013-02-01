﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;

namespace GameStructure
{
    
    public partial class Form1 : Form
    {
        FastLoop _fastLoop;
        bool _fullscreen = false;
        StateSystem _stateSystem = new StateSystem();

        public Form1()
        {
            
            _fastLoop = new FastLoop(GameLoop);

            InitializeComponent();
            _openGLControl.InitializeContexts();


            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }





            _stateSystem.AddState("splash", new SplashScreenState(_stateSystem));
            _stateSystem.AddState("title_menu", new TitleMenuState());
            _stateSystem.ChangeState("splash");
        }

        void GameLoop(double elapsedTime)
        {   
            _stateSystem.Update(elapsedTime);
            _stateSystem.Render();
            _openGLControl.Refresh();
        }
    }

}