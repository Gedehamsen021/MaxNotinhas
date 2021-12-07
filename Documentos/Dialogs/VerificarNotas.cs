using Documentos.Classes;
using Documentos.Dialogs.VerificarNotas_Subdialogs;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        List<RelatorioData> d = new List<RelatorioData>();

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
            if (!CheckisOpen("Pesquisar"))
            {
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
                var msg = MessageBox.Show("Deseja alterar estas notas?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            if (dataGridView1.Rows[row.Index].Cells[4].Value.ToString() == "N")
                            {
                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = connection;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = $"Update notas SET pago=@pago WHERE id = @id";
                                cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[row.Index].Cells[1].Value);
                                cmd.Parameters.AddWithValue("@pago", "S");
                                cmd.ExecuteNonQuery();
                            }
                            if (dataGridView1.Rows[row.Index].Cells[4].Value.ToString() == "S")
                            {
                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = connection;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = $"Update notas SET pago=@pago WHERE id = @id";
                                cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[row.Index].Cells[1].Value);
                                cmd.Parameters.AddWithValue("@pago", "N");
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    this.notasTableAdapter.Fill(this.notinhasDataSet1.notas);
                    MessageBox.Show("Notas alteredas com sucesso");
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Nenhuma nota foi selecionada");
            }
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            if (chk_pagos.Checked)
            {
                bs.Filter = string.Format($"data >= '{dt_inicio.Value.ToString("dd-MMM-yyyy")}' AND data <= '{dt_final.Value.ToString("dd-MMM-yyyy")}' AND pago = 'S'");
                dataGridView1.DataSource = bs;
                dataGridView1.Refresh();
            }
            else
            {
                bs.Filter = string.Format($"data >= '{dt_inicio.Value.ToString("dd-MMM-yyyy")}' AND data <= '{dt_final.Value.ToString("dd-MMM-yyyy")}' AND pago = 'N'");
                dataGridView1.DataSource = bs;
                dataGridView1.Refresh();
            }
        }

        private void btn_gerar_Click(object sender, EventArgs e)
        {
            string con = Properties.Settings.Default.NotinhasDB;
            var msg = MessageBox.Show("Ao gerar assinatura todos as notas selecionadas serão alteradas, deseja prosseguir?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                MySqlConnection connection = new MySqlConnection(con);
                connection.Open();
                Criar_Assinatura assinatura = new Criar_Assinatura();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    RelatorioData data = new RelatorioData();
                    data.Numeracao = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    data.Tipo = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    data.Data = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value).ToString("dd-MMM-yyyy");
                    d.Add(data);
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"Update notas SET pago='S' WHERE id=@idpagos AND pago='N'";
                    cmd.Parameters.AddWithValue("@idpagos", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cmd.ExecuteNonQuery();
                }

                assinatura.reportViewer1.LocalReport.DataSources.Clear();
                assinatura.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Data",d));
                assinatura.reportViewer1.LocalReport.ReportEmbeddedResource = "Documentos.Dialogs.Report1.rdlc";
                assinatura.ShowDialog();
                d.Clear();
                connection.Close();
                this.notasTableAdapter.Fill(this.notinhasDataSet1.notas);
            }
        }
    }
}
