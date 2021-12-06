using Documentos.Dialogs;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Documentos
{
    public partial class Pesquisar : Form
    {

        public DataGridView Dgv { get; set; }
        public static bool Verificarbtn = false;

        public Pesquisar()
        {
            InitializeComponent();
            
        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            
            this.clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                AdicionarNota addNota = new AdicionarNota();
                addNota.Cliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                addNota.ShowDialog();
                if (addNota.DialogResult == DialogResult.OK)
                {
                    if (addNota.comboBox1.Text != "")
                    {
                        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) != 0)
                        {
                            string con = Properties.Settings.Default.NotinhasDB;
                            int diminuirNota = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) - 1;
                            int id = Convert.ToInt32((int)dataGridView1.CurrentRow.Cells[0].Value);
                            MySqlConnection connection = new MySqlConnection(con);
                            connection.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = connection;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = $"INSERT into notas(cliente_id,tipo,pago,numeracao,data) VALUES (@id,@tipo,@pago,@numeracao,@data)";
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@tipo", addNota.comboBox1.Text);
                            if (addNota.chk_pago.Checked)
                            {
                                cmd.Parameters.AddWithValue("@pago", "S");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@pago", "N");
                            }
                            cmd.Parameters.AddWithValue("@numeracao", addNota.field_numeracao.Value);
                            cmd.Parameters.AddWithValue("@data", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = $"UPDATE clientes set notas_restantes = {diminuirNota} where id = {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}";
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Nota criada com sucesso");
                            this.clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
                            dataGridView1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Cliente não tem mais nenhuma nota disponivel, contate o cliente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tipo de nota invalida");
                    }
                }
            } else
            {
                MessageBox.Show("Nenhum cliente foi selecionado");
            }
        }

        private void btn_pesq_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32((int)dataGridView1.CurrentRow.Cells[0].Value);
                Dispose();
                VerificarNotas ver = new VerificarNotas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                Inicio.pnl_container.Controls.Add(ver);
                ver.notasBindingSource.Filter = $"cliente_id = {id}";
                ver.Show();
            } else
            {
                MessageBox.Show("Nenhum cliente foi selecionado");
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                AlterarPacote alt = new AlterarPacote();
                alt.Cliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                int valorR = (int)dataGridView1.CurrentRow.Cells[2].Value;
                alt.field_restante.Value = valorR;
                alt.lbl_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                alt.ShowDialog();
                if (alt.DialogResult == DialogResult.Yes)
                {
                    string con = Properties.Settings.Default.NotinhasDB;
                    MySqlConnection connection = new MySqlConnection(con);
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"UPDATE clientes SET notas_restantes=@nrestante WHERE id = {alt.lbl_ID.Text}";
                    cmd.Parameters.AddWithValue("@nrestante", alt.field_restante.Value);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    var msg = MessageBox.Show("Pacote Atualizado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
                    dataGridView1.Refresh();

                }
                if(alt.DialogResult == DialogResult.Cancel)
                {
                    alt.Dispose();
                }
            } else
            {
                MessageBox.Show("Nenhum cliente foi selecionado");
            }
        }
    }
}
