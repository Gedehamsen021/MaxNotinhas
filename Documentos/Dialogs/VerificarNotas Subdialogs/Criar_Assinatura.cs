using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Documentos.Dialogs.VerificarNotas_Subdialogs
{
    public partial class Criar_Assinatura : Form
    {
        public Criar_Assinatura()
        {
            InitializeComponent();
        }

        private void Criar_Assinatura_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
