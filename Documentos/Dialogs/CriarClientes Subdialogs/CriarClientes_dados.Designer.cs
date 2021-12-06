namespace Documentos.Dialogs.CriarClientes_Subdialogs
{
    partial class CriarClientes_dados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.fld_textbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lab_qtd = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.fld_notas = new System.Windows.Forms.NumericUpDown();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.clt_id = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_notas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clt_id);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 28);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOME / EMPRESA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fld_textbox
            // 
            this.fld_textbox.Location = new System.Drawing.Point(123, 6);
            this.fld_textbox.Name = "fld_textbox";
            this.fld_textbox.Size = new System.Drawing.Size(292, 20);
            this.fld_textbox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fld_textbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 38);
            this.panel2.TabIndex = 2;
            // 
            // lab_qtd
            // 
            this.lab_qtd.Dock = System.Windows.Forms.DockStyle.Top;
            this.lab_qtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_qtd.Location = new System.Drawing.Point(0, 66);
            this.lab_qtd.Name = "lab_qtd";
            this.lab_qtd.Size = new System.Drawing.Size(559, 25);
            this.lab_qtd.TabIndex = 3;
            this.lab_qtd.Text = "QUANTIDADES DE NOTAS";
            this.lab_qtd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fld_notas);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 38);
            this.panel3.TabIndex = 4;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.Location = new System.Drawing.Point(460, 135);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(87, 29);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btn_Salvar.Location = new System.Drawing.Point(12, 135);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(83, 29);
            this.btn_Salvar.TabIndex = 6;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            // 
            // fld_notas
            // 
            this.fld_notas.Location = new System.Drawing.Point(205, 3);
            this.fld_notas.Name = "fld_notas";
            this.fld_notas.Size = new System.Drawing.Size(119, 20);
            this.fld_notas.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btn_delete.Location = new System.Drawing.Point(205, 135);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(119, 26);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Deletar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID";
            this.label3.Visible = false;
            // 
            // clt_id
            // 
            this.clt_id.AutoSize = true;
            this.clt_id.Location = new System.Drawing.Point(28, 8);
            this.clt_id.Name = "clt_id";
            this.clt_id.Size = new System.Drawing.Size(35, 13);
            this.clt_id.TabIndex = 2;
            this.clt_id.Text = "label4";
            this.clt_id.Visible = false;
            // 
            // CriarClientes_dados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 176);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lab_qtd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CriarClientes_dados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CriarClientes_dados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_notas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_Salvar;
        public System.Windows.Forms.TextBox fld_textbox;
        public System.Windows.Forms.NumericUpDown fld_notas;
        public System.Windows.Forms.Label clt_id;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lab_qtd;
        public System.Windows.Forms.Button btn_delete;
    }
}