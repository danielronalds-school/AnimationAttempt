using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AnimationAttempt
{
    class Projectile
    {
        public int x, y, width, height;

        private int projectileSpeed = 5;

        public Image projectileImage;

        public Rectangle projectileRec;

        public Projectile(Rectangle playerRec)
        {
            x = 10;
            y = 380;
            width = 60;
            height = 30;

            x = playerRec.X + playerRec.Width / 2;
            y = playerRec.Y;//+ playerRec.Height;

            projectileImage = Properties.Resources.plasmabolt;
            projectileRec = new Rectangle(x, y, width, height);

        }

        public void drawProjectile(Graphics g)
        {
            g.DrawImage(projectileImage, projectileRec);

        }

        public void moveProjectile(Graphics g)
        {
            x += projectileSpeed;
            projectileRec.Location = new Point(x, y);
        }

    }
}
