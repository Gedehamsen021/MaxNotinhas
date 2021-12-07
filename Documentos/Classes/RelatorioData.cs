using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentos.Classes
{
    class RelatorioData
    {
        private int numeracao;
        private string data;
        private string tipo;

        public int Numeracao { get => numeracao; set => numeracao = value; }
        public string Data { get => data; set => data = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
