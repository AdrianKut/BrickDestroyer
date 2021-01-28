using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickDestroyer
{

    class Player : IPos
    {

        public int lifes { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }

        public bool LeftMoving { get; set; }
        public bool RightMoving { get; set; }

        public PictureBox pictureBox;
        public Label labelLifes { get; set; }

        public Player(int lifes, int xPos, int yPos, PictureBox pictureBox, Label labelLifes)
        {
            this.lifes = lifes;
            this.xPos = xPos;
            this.yPos = yPos;

            this.pictureBox = pictureBox;
            this.labelLifes = labelLifes;

            LeftMoving = false;
            RightMoving = false;
        }

        public void MoveLeftOrRigth(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                LeftMoving = true;
                RightMoving = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                LeftMoving = false;
                RightMoving = true;
            }

        }

        public void Move()
        {

            if (LeftMoving)
            {
                if (xPos > 0)
                {
                    xPos = xPos - 10;
                    pictureBox.Location = new System.Drawing.Point(xPos, yPos);
                }
            }

            else if (RightMoving)
            {
                if (xPos < 555)
                {
                    xPos = xPos + 10;
                    pictureBox.Location = new System.Drawing.Point(xPos, yPos);
                }
            }
        }

        public void ResetAmountLife(int howMuch)
        {
            lifes = howMuch;
        }

        public void ResetPosition()
        {
            xPos = 275;
            yPos = 619;
        }

    }
}
