using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Lab4
{
    public partial class MainForm : Form
    {
        private PictureBox spriteBox;
        private SoundPlayer moveSound;
        private System.Timers.Timer gameTimer;
        private const int MOVEMENT_SPEED = 5;
        private bool isPlaying = false;


        public MainForm()
        {
            InitializeComponents();
            SetupGame();
        }

        private void InitializeComponents()
        {
            this.ClientSize = new Size(800, 600);
            this.Text = "Sprite Movement";
            this.KeyPreview = true;

            // Configurar el PictureBox para el sprite
            spriteBox = new PictureBox();
            spriteBox.Size = new Size(200, 100);
            spriteBox.Location = new Point(305, 275);
            spriteBox.Image = Image.FromFile("sprite.png");
            spriteBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(spriteBox);

            
            gameTimer = new System.Timers.Timer();
            gameTimer.Interval = 16;
            gameTimer.Elapsed += (sender, e) => GameTimer_Tick(sender, e);
        }

        private void SetupGame()
        {
            // Inicializar el reproductor de sonido
            try
            {
                moveSound = new SoundPlayer("move.wav");
                moveSound.Load();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el sonido: " + ex.Message);
            }
            
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += MainForm_KeyUp;

            
            gameTimer.Start();
        }

        private bool isUpPressed = false;
        private bool isDownPressed = false;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKey(e.KeyCode, true);
            PlayMoveSound();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            HandleKey(e.KeyCode, false);
            PlayMoveSound();
        }

        private void HandleKey(Keys key, bool isPressed)
        {
            if (key == Keys.Up)
                isUpPressed = isPressed;
            else if (key == Keys.Down)
                isDownPressed = isPressed;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isUpPressed)
            {
                MoveSprite(-MOVEMENT_SPEED); // Mover hacia arriba
            }
            if (isDownPressed)
            {
                MoveSprite(MOVEMENT_SPEED); // Mover hacia abajo
            }
        }

        private void MoveSprite(int deltaY)
        {
            int newY = spriteBox.Location.Y + deltaY;

            // Verificar límites de la ventana
            if (newY >= 0 && newY <= this.ClientSize.Height - spriteBox.Height)
            {
                if (spriteBox.InvokeRequired)
                {
                    spriteBox.Invoke(new Action(() =>
                    {
                        spriteBox.Location = new Point(spriteBox.Location.X, newY);
                    }));
                }
                else
                {
                    spriteBox.Location = new Point(spriteBox.Location.X, newY);
                }

            }
        }

        private void PlayMoveSound()
        {
            if (!isPlaying)
            {
                isPlaying = true;
                moveSound.Play();
                Task.Delay(300).ContinueWith(_ => isPlaying = false); // Ajusta el tiempo según la duración del sonido
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Limpieza de recursos
            moveSound.Dispose();
            gameTimer.Dispose();
        }
    }
    
}
