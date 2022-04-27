namespace PacMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            Jogo.Dock = DockStyle.Fill;


            Bitmap bitmap = new Bitmap(Jogo.Width, Jogo.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Black);

            Image image = new Bitmap(Properties.Resources.Pacman_Openmouth_right);
            g.DrawImage(image, 0,0,100,100);

            Jogo.Image = bitmap;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());

            var KeyPress = e.KeyCode;
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void PacMan_Click(object sender, EventArgs e)
        {

        }
    }
}