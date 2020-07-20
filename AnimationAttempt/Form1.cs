using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace AnimationAttempt
{
    public partial class Form1 : Form
    {
        Graphics g;
        Player player = new Player(10, 380);
        Player player2 = new Player(300,380);

        public bool playerLeft, playerRight;
        public bool player2Left, player2Right;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            player.DrawPlayer(g, playerMoving()); // Player 1
            player2.DrawPlayer(g, player2Moving()); // Player 2
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {

                // Player 1
                case Keys.A:
                    playerLeft = true;
                    break;
                case Keys.D:
                    playerRight = true;
                    break;

                // Player 2
                case Keys.Right:
                    player2Right = true;
                    break;
                case Keys.Left:
                    player2Left = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                // Player 1
                case Keys.A:
                    playerLeft = false;
                    break;
                case Keys.D:
                    playerRight = false;
                    break;

                // Player 2
                case Keys.Right:
                    player2Right = false;
                    break;
                case Keys.Left:
                    player2Left = false;
                    break;
            }
        }

        private void tmrPlayer_Tick(object sender, EventArgs e)
        {
            if(playerLeft)
            {
                player.MovePlayer(true);

            }
            else if(playerRight)
            {
                player.MovePlayer(false);
            }
            if (player2Left)
            {
                player2.MovePlayer(true);

            }
            else if (player2Right)
            {
                player2.MovePlayer(false);
            }
            Canvas.Invalidate();
        }

        private bool playerMoving()
        {
            if(playerLeft || playerRight)
            {
                return true;
            }
            return false;
        }

        private bool player2Moving()
        {
            if (player2Left || player2Right)
            {
                return true;
            }
            return false;
        }
    }
}
