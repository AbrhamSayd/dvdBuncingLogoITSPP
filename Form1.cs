using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Balon
{
    public partial class Form1 : Form
    {
        // Parametors del dibujo
        private  int BolaWidth = 128;
        private  int BolaHeight = 58;
        private int BolaX, BolaY;   //pos
        private int BolaVX, BolaVY; // vel.
        public string[] files;
        private int currentIndex = 0;
        int img = 0;

        public Form1()
        {
            InitializeComponent();
            inizializarImagenes();
            
        }
        private void cambiarImages()
        {
            picImagen.ImageLocation = files[currentIndex];
        }
        private void inizializarImagenes()
        {
            string appRoot = System.IO.Path.GetDirectoryName(Application.StartupPath);
            files = System.IO.Directory.GetFiles(appRoot + @"\dvdLogos");
            Random rnd = new Random();
            files = files.OrderBy(x => rnd.Next()).ToArray();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            picImagen.Size = new System.Drawing.Size(BolaWidth, BolaHeight);
            Random rnd = new Random();
         
            BolaVX = 5;
            BolaVY = 5;
            BolaX = rnd.Next(0, ClientSize.Width - BolaWidth);
            BolaY = rnd.Next(0, ClientSize.Height - BolaHeight);
           
        }
        private void siguienteImagen() {
            if (img >= files.Length)
            {
                img = 0;
                currentIndex = 0;
            }
            currentIndex = img;
            img++;
            
            cambiarImages();
        }
        private void tmrDibujar_Tick(object sender, EventArgs e)
        {
            BolaX += BolaVX;
            if (BolaX < 0)
            {
                BolaVX = -BolaVX;
                siguienteImagen();
            }
            else if (BolaX + BolaWidth > ClientSize.Width)
            {
                BolaVX = -BolaVX;
                siguienteImagen();
            }

            BolaY += BolaVY;
            if (BolaY < 0)
            {
                BolaVY = -BolaVY;
                siguienteImagen();

            }
            else if (BolaY + BolaHeight > ClientSize.Height)
            {
                BolaVY = -BolaVY;
                siguienteImagen();
                
            }

            picImagen.Location = new Point(BolaX, BolaY);
            Refresh();
        }

        
    }
}
