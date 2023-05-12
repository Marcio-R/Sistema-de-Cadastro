using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> listPessoas;
        public Form1()
        {
            InitializeComponent();
            listPessoas = new List<Pessoa>();
            comboEc.Items.Add("Casado");
            comboEc.Items.Add("Solteiro");
            comboEc.Items.Add("Viuvo");
            comboEc.Items.Add("Separado");
            comboEc.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void Listar()
        {
            lista.Items.Clear();
            foreach (Pessoa pessoas in listPessoas)
            {
                lista.Items.Add(pessoas.Nome);
            }
        }
    }
}
