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

        public Image[] movingLeftAnimations = new Image[3] {Properties.Resources.walk_left_1, Properties.Resources.walk_left_2, Properties.Resources.walk_left_3 };

        public Image[] movingRightAnimations = new Image[3] {Properties.Resources.walk_right_1, Properties.Resources.walk_right_2, Properties.Resources.walk_right_3 };

        public Image standingStillImage = Properties.Resources.standing;

        private int animationPhase = 0;

        public int playerSpeed = 1;

        public Player()
        {
            x = 10;
            y = 380;
            width = 40;
            height = 40;
            playerImage = Properties.Resources.standing;
            playerRec = new Rectangle(x, y, width, height);
        }

        public void DrawPlayer(Graphics g)
        {
            g.DrawImage(playerImage, playerRec);
        }

        public void MovePlayer(bool Left)
        {
            if(Left)
            {
                x -= playerSpeed;
            }
            else
            {
                x += playerSpeed;
            }
            playerRec.Location = new Point(x, y);
        }


    }
}
