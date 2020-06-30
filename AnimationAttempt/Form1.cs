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
        Player player = new Player();

        public bool playerLeft, playerRight;

        List<Projectile> projectile = new List<Projectile>();

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            player.DrawPlayer(g, playerMoving());
            foreach (Projectile m in projectile)
            {
                m.drawProjectile(g);
                m.moveProjectile(g);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    playerLeft = true;
                    break;

                case Keys.Right:
                case Keys.D:
                    playerRight = true;
                    break;
            }


            if (e.KeyData == Keys.Space) { projectile.Add(new Projectile(player.playerRec)); }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    playerLeft = false;
                    break;

                case Keys.Right:
                case Keys.D:
                    playerRight = false;
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
    }
}
