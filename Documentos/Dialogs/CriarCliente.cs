using Documentos.Dialogs.CriarClientes_Subdialogs;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Documentos.Dialogs
{
    public partial class CriarCliente : Form
    {
        public CriarCliente()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CriarCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'notinhasDataSet.clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            CriarClientes_dados CC = new CriarClientes_dados();
            CC.ShowDialog();

            if(CC.DialogResult == DialogResult.Cancel)
            {
                CC.Dispose();
            }

            if(CC.DialogResult == DialogResult.Yes)
            {
                if (CC.fld_textbox.Text != "")
                {
                    string con = Properties.Settings.Default.NotinhasDB;
                    MySqlConnection connection = new MySqlConnection(con);
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT into clientes(nome,notas_restantes) VALUES (@nome,@notasR)";
                    cmd.Parameters.AddWithValue("@nome", CC.fld_textbox.Text);
                    cmd.Parameters.AddWithValue("@notasR", CC.fld_notas.Value);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Cliente cadastrado com sucesso");
                    clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
                    CC.fld_textbox.Text = "";
                    CC.fld_notas.Value = 0;
                    CC.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Nome ou empresa não informado");
                    CC.ShowDialog();
                }
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                CriarClientes_dados CC = new CriarClientes_dados();
                CC.fld_textbox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                CC.lab_qtd.Visible = false;
                CC.fld_notas.Visible = false;
                CC.label3.Visible = true;
                CC.clt_id.Visible = true;
                CC.btn_delete.Visible = true;
                CC.clt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                CC.ShowDialog();
                string con = Properties.Settings.Default.NotinhasDB;
                if (CC.DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection connection = new MySqlConnection(con);
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = $"Update clientes SET nome = @nome WHERE id = {CC.clt_id.Text}";
                        cmd.Parameters.AddWithValue("@nome", CC.fld_textbox.Text);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Cliente alterado com sucesso");
                        clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                if (CC.DialogResult == DialogResult.Ignore)
                {
                    var box = MessageBox.Show("Deseja realmente excluir este cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (box == DialogResult.Yes)
                    {
                        try
                        {
                            MySqlConnection connection = new MySqlConnection(con);
                            connection.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = connection;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = $"DELETE FROM clientes WHERE id = {CC.clt_id.Text}";
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Cliente deletado com sucesso");
                            clientesTableAdapter.Fill(this.notinhasDataSet.clientes);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Este cliente não pode ser deletado pois possui notas registradas", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Nenhum cliente selecionado");
            }
        }
    }
}
