using System.Media;

namespace Tarea4
{
    partial class MainForm : Form
    {
        private PictureBox sprite;
        private int spriteX = 100, spriteY = 100;
        private SoundPlayer soundPlayer;
        private bool isSoundPlaying = false;

        private System.ComponentModel.IContainer components = null;

        private void PlayMoveSound()
        {
            if (!isSoundPlaying)
            {
                isSoundPlaying = true;
                soundPlayer.Play();
                Task.Delay(300).ContinueWith(_ => isSoundPlaying = false);
            }
        }


        public MainForm()
        {
  
            this.Text = "Movimiento de Sprite con Sonido";
            this.Size = new Size(800, 600);

            sprite = new PictureBox();
            sprite.Image = Image.FromFile("sprite.png"); 
            sprite.Size = new Size(300, 500);
            sprite.Location = new Point(spriteX, spriteY);
            this.Controls.Add(sprite);

            soundPlayer = new SoundPlayer("move.wav"); 

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up) spriteY -= 10;
            if (e.KeyCode == Keys.Down) spriteY += 10;
            if (e.KeyCode == Keys.Left) spriteX -= 10;
            if (e.KeyCode == Keys.Right) spriteX += 10;

            PlayMoveSound();

            sprite.Location = new Point(spriteX, spriteY);


            this.Invalidate();
        }
    }
}

