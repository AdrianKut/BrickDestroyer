using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickDestroyer
{
    class Ball : IPos
    {
        private static float speedBall = 10f;
        
        public int xPos { get; set; }
        public int yPos { get; set; }

        public PictureBox pictureBox;

        public float angleX = speedBall, angleY = speedBall;

        public Ball(int xPos, int yPos, PictureBox pictureBox)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.pictureBox = pictureBox;
        }


        public void Move(int widthPanel, int heightPanel)
        {
            if (xPos < 0 || xPos > widthPanel - 20)
            {
                angleX = -angleX;
            }

            if (yPos < 0 || yPos > heightPanel - 20)
            {
                angleY = -angleY;
            }

            xPos = xPos + (int)angleX;
            yPos = yPos + (int)angleY;
            pictureBox.Location = new System.Drawing.Point(xPos, yPos);
        }

        public void ResetPosition()
        {
            xPos = 327;
            yPos = 593;
        }

        public void IncreaseSpeed()
        {
            angleX *= 1.1f;
            angleY *= 1.1f;
        }

        public void ChangeVelocity()
        {
            angleY = -angleY;
        }

        public void ChangeVelocityAfterHitWithBlocks()
        {
            angleY = -angleY;
            angleX = -angleX;
        }

        public void ResetSpeed()
        {
            angleX = speedBall;
            angleY = speedBall;
        }

       
    }
}
