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
            int index = -1;
            foreach (Pessoa pessoa in listPessoas)
            {
                if (pessoa.Nome == txtNome.Text)
                {
                    index = listPessoas.IndexOf(pessoa);
                }
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show("Preenche o campo nome.");
                txtNome.Focus();
                return;
            }
            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preenche o campo telefone.");
                txtTelefone.Focus();
                return;
            }
            char sexo;
            if (radioF.Checked)
            {
                sexo = 'F';
            }
            else if (radioM.Checked)
            {
                sexo = 'M';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEc.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = ChkCasa.Checked;
            p.Veiculo = ChkVeiculo.Checked;
            p.Sexo = sexo;

            if(index < 0)
            {
                listPessoas.Add(p);
            }
            else
            {
                listPessoas[index] = p;
            }
            btnLimpar_Click(btnLimpar, EventArgs.Empty);
            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            listPessoas.RemoveAt(indice);
            Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            comboEc.SelectedIndex = 0;
            txtTelefone.Text = "";
            ChkCasa.Checked = false;
            ChkVeiculo.Checked = false;
            radioF.Checked = false;
            radioM.Checked = true;
            radioO.Checked = false;
            txtNome.Focus();
        }

        private void Listar()
        {
            lista.Items.Clear();
            foreach (Pessoa pessoas in listPessoas)
            {
                lista.Items.Add(pessoas.Nome);
            }
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa pe = listPessoas[indice];
            txtNome.Text = pe.Nome;
            txtData.Text = pe.DataNascimento;
            comboEc.SelectedItem = pe.EstadoCivil;
            txtTelefone.Text = pe.Telefone;
            ChkCasa.Checked = pe.CasaPropria;
            ChkVeiculo.Checked = pe.Veiculo;

            switch (pe.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                case 'O':
                    radioO.Checked = true;
                    break;
            }
        }
    }
}
