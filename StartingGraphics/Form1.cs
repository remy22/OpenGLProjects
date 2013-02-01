﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.DevIl;

namespace GameStructure
{
    
    public partial class Form1 : Form
    {
        FastLoop _fastLoop;
        bool _fullscreen = false;
        StateSystem _stateSystem = new StateSystem();

        TextureManager _textureManager = new TextureManager();

        public Form1()
        {
           
            InitializeComponent();
            _openGLControl.InitializeContexts();

            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            _textureManager.LoadTexture("title", "workingTitle.tif");

            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(1280, 720);
            }

            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
            
            _fastLoop = new FastLoop(GameLoop);

            _stateSystem.AddState("splash", new SplashScreenState(_stateSystem));
            _stateSystem.AddState("title_menu", new TitleMenuState());
            _stateSystem.AddState("sprite_test", new DrawSpriteState(_textureManager));

            _stateSystem.ChangeState("sprite_test");
        }

        void GameLoop(double elapsedTime)
        {   
            _stateSystem.Update(elapsedTime);
            _stateSystem.Render();
            _openGLControl.Refresh();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
    }

}