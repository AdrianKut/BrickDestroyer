using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrickDestroyer
{
    class GameManager
    {
        Ball ball;
        Player player;
        PictureBox[] bricks;

        Label labelWinner;
        Label labelbricksCounter;
        Panel panelBackground;

        bool isStarted = false;
        bool isGameOver = false;

        private int bricksCounter;
        private int lifesAtStartGame;

        List<int> XBricksPosition = new List<int>();
        List<int> YBricksPosition = new List<int>();

        public GameManager(Player player, Ball ball, PictureBox[] bricks,
            Label labelWinner, Label labelbricksCounter, Panel panelBackground)
        {
            this.ball = ball;
            this.player = player;
            this.bricks = bricks;
            this.panelBackground = panelBackground;
            this.labelWinner = labelWinner;
            this.labelbricksCounter = labelbricksCounter;

            lifesAtStartGame = player.lifes;


            foreach (var item in bricks)
            {
                XBricksPosition.Add(item.Location.X);
                YBricksPosition.Add(item.Location.Y);
            }

            this.bricksCounter = bricks.Count();
        }

        public void StartMovingPlayer(KeyEventArgs e)
        {
            player.MoveLeftOrRigth(e);
        }

        public void BallFollowPlayerPosition()
        {
            int playerWidth = player.pictureBox.Width;
            ball.xPos = player.xPos + playerWidth / 2;
            ball.yPos = player.yPos - 25 ;
            ball.pictureBox.Location = new System.Drawing.Point(ball.xPos , ball.yPos );
        }


        public void MoveBallAndPlayer()
        {
            if (isStarted)
            {
                ball.Move(panelBackground.Width, panelBackground.Height);
                player.Move();
            }

            else if (!isStarted)
            {
                ball.ChangeVelocity();
                BallFollowPlayerPosition();
                player.Move();
            }

        }

   
        public void HitBall()
        {
            if (ball.pictureBox.Bounds.IntersectsWith(player.pictureBox.Bounds))
            {
                ball.ChangeVelocity();
            }

            foreach (PictureBox item in bricks)
            {
                if (ball.pictureBox.Bounds.IntersectsWith(item.Bounds))
                {
                    ball.ChangeVelocityAfterHitWithBlocks();
                    item.Location = new System.Drawing.Point(700, 700);
                    bricksCounter--;
                }
            }
        }

        public void ManageLabels()
        {
            string lifesLeft = "";
            for (int i = 0; i < player.lifes; i++)
            {
                lifesLeft += "♥";
            }
            player.labelLifes.Text = lifesLeft;
            labelbricksCounter.Text = bricksCounter + "/" + bricks.Count();
        }


        public void LifeDecrease()
        {

            if (ball.yPos >= panelBackground.Height - 20)
            {
                player.lifes--;
                BallFollowPlayerPosition();
                player.ResetPosition();

                isStarted = false;
            }

        }

        private void GameOverPause(string textToShow)
        {
            isGameOver = true;
            isStarted = false;
            labelWinner.Visible = true;
            bricksCounter = bricks.Count();    
            labelWinner.Text = textToShow;

            ResetPositionBricks();
        }

        private void ResetPositionBricks()
        {
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].Location = new System.Drawing.Point(XBricksPosition[i], YBricksPosition[i]);
            }
        }

        public void GameOver()
        {
            if (player.lifes == 0)
            {
                string words = "GAME OVER!\n\n PRESS ENTER TO START";
                GameOverPause(words);
            }

            if (bricksCounter == 0)
            {
                string words = "YOU HAVE WON!\n\n PRESS ENTER TO START";
                GameOverPause(words);
            }
            
        }

        private void StartGame()
        {
            isStarted = true;
            player.ResetAmountLife(lifesAtStartGame);
        }

        public void GameManage(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && !isStarted)
            {
                isStarted = true;
                labelWinner.Visible = false;
            }

            if (e.KeyCode == Keys.Enter && isGameOver)
            {
                StartGame();
                labelWinner.Visible = false;
                isGameOver = false;
            }

        }

        public void MoveMouse()
        {
            player.xPos = Cursor.Position.X;
        }

    }
}
