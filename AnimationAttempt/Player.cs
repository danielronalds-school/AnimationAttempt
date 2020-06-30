using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AnimationAttempt
{
    class Player
    {
        public int x, y, width, height;
        public Image playerImage;

        public Rectangle playerRec;

        
        public Player()
        {
            x = 10;
            y = 10;
            width = 40;
            height = 40;
            playerImage = Properties.Resources.standing;
            playerRec = new Rectangle(x, y, width, height);
        }

        public void DrawPlayer(Graphics g)
        {
            g.DrawImage(playerImage, playerRec);
        }

    }
}
