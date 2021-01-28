using System;
using System.Windows.Forms;

namespace BrickDestroyer
{
    public partial class Form1 : Form
    {

        GameManager gameManager;
        public Form1()
        {
            InitializeComponent();
            timerGame.Start();

            Ball ball = new Ball(327, 593, pictureBoxBall);
            Player player = new Player(3, 275, 619, pictureBoxPlayer, labelLifes);

            PictureBox[] bricks = new PictureBox[]
            {
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox9,
                pictureBox10,
                pictureBox11,
                pictureBox14,
                pictureBox15,
                pictureBox16,
                pictureBox18,
                pictureBox19,
                pictureBox20,
                pictureBox21,
                pictureBox22,
                pictureBox23,
                pictureBox24,
                pictureBox26,
                pictureBox27,
                pictureBox28,
                pictureBox29,
            };

            gameManager = new GameManager(player, ball, bricks, labelWinner,labelBricksCounter, panelBackground);
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            gameManager.ManageLabels();
            gameManager.MoveBallAndPlayer();
            gameManager.LifeDecrease();
            gameManager.HitBall();
            gameManager.GameOver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gameManager.GameManage(e);
            gameManager.StartMovingPlayer(e);
        }


    }
}
