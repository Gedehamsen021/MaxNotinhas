using Documentos.Dialogs;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Documentos
{
    public partial class Inicio : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Inicio()
        {
            InitializeComponent();
            string con = Properties.Settings.Default.NotinhasDB;
            try
            {
                MySqlConnection connection = new MySqlConnection(con);
                connection.Open();
                connection.Close();
            }
            catch (Exception)
            {
                var msg = MessageBox.Show("Mysql não conectado", "Erro MYSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (msg == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
        }

        private bool CheckisOpen(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar pesquisar = new Pesquisar() {Dock = DockStyle.Fill,TopLevel = false, TopMost = true };
            if (!CheckisOpen("Pesquisar") && !CheckisOpen("CriarCliente"))
            {
                pnl_container.Controls.Add(pesquisar);
                pesquisar.Show();
            }
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            CriarCliente criar = new CriarCliente() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            if (!CheckisOpen("Pesquisar") && !CheckisOpen("CriarCliente"))
            {
                pnl_container.Controls.Add(criar);
                criar.Show();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
