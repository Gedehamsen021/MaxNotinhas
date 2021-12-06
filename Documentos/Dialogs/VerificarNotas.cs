using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Documentos.Dialogs
{
    public partial class VerificarNotas : Form
    {
        public VerificarNotas()
        {
            InitializeComponent();
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if(!CheckisOpen("Pesquisar")) { 
            Pesquisar pesq = new Pesquisar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Inicio.pnl_container.Controls.Add(pesq);
            pesq.Show();
            }
        }

        private void VerificarNotas_Load(object sender, EventArgs e)
        {
            this.notasTableAdapter.Fill(this.notinhasDataSet1.notas);
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string con = Properties.Settings.Default.NotinhasDB;
                MySqlConnection connection = new MySqlConnection(con);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Update notas SET pago=@pago WHERE id = {dataGridView1.CurrentRow.Cells[0].Value}";
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "N")
                {
                    var msg = MessageBox.Show("Deseja alterar status para pago?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        cmd.Parameters.AddWithValue("@pago", "S");
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Nota alterada");
                        this.notasTableAdapter.Fill(this.notinhasDataSet1.notas);
                        return;
                    }
                    if (msg == DialogResult.No)
                    {
                        return;
                    }

                }
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "S")
                {
                    var msg = MessageBox.Show("Deseja alterar status para não pago?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        cmd.Parameters.AddWithValue("@pago", "N");
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Nota alterada");
                        this.notasTableAdapter.Fill(this.notinhasDataSet1.notas);
                        return;
                    }
                    if (msg == DialogResult.No)
                    {
                        return;
                    }

                }
            } else
            {
                MessageBox.Show("Nenhuma nota foi selecionada");
            }
        }
    }
}
