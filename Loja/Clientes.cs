using Loja.BLL;
using Loja.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            txtNome.Focus();
        }

        private void AtualizaGrid()
        {
            // Comunicação com a Camada BLL
            ClientesBLL obj = new ClientesBLL();
            dtgClientes.DataSource = obj.Listagem(txtFiltro.Text);

            // Atualizando os objetos TextBox
            try
            {
                txtCod.Text = "";
                txtNome.Text = "";
                txtEmail.Text = "";
                mskTelefone.Text = "";
                if (dtgClientes.CurrentRow != null)
                {
                    txtCod.Text = (dtgClientes[0, dtgClientes.CurrentRow.Index].Value.ToString());
                    txtNome.Text = dtgClientes[1, dtgClientes.CurrentRow.Index].Value.ToString();
                    txtEmail.Text = dtgClientes[2, dtgClientes.CurrentRow.Index].Value.ToString();
                    mskTelefone.Text = dtgClientes[3, dtgClientes.CurrentRow.Index].Value.ToString();
                }
                
            }
            catch
            {
                txtCod.Text = "";
                txtNome.Text = "";
                txtEmail.Text = "";
                mskTelefone.Text = "";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            mskTelefone.Text = "";
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria um objeto do modulo de Informações de Clientes que criamos
                ClienteInformation cliente = new ClienteInformation();
                //Atribui valores para as propriedades do objeto
                cliente.Nome = txtNome.Text;
                cliente.Email = txtEmail.Text;
                cliente.Telefone = mskTelefone.Text;

                // cria um objeto da camada de Regra de Négocios, que já faz toda verificação para nós e chamda o Inserir da camada DAL
                ClientesBLL obj = new ClientesBLL();
                // Chama o inserir do BLL que chama o Inserir do DAL
                obj.Inserir(cliente);
                MessageBox.Show("O cliente foi incluido com sucesso!");
                txtCod.Text = Convert.ToString(cliente.Codigo);
                AtualizaGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text.Length == 0)
            {
                MessageBox.Show("Um cliente deve ser selecionado para alteração");
            }
            else
            {
                try
                {
                    ClienteInformation cliente = new ClienteInformation();
                    cliente.Codigo = int.Parse(txtCod.Text);
                    cliente.Nome = txtNome.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Telefone = mskTelefone.Text;

                    ClientesBLL obj = new ClientesBLL();
                    obj.Alterar(cliente);
                    MessageBox.Show("O cliente foi alterado com sucesso!");
                    AtualizaGrid();
                }
                catch (Exception ex )
                {
                    MessageBox.Show("Erro: " + ex.Message);                 
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCod.Text.Length == 0)
            {
                MessageBox.Show("Um cliente deve ser selecionado para exclusão");
            }
            else
            {
                try
                {
                    int codigo = Convert.ToInt32(txtCod.Text);
                    ClientesBLL obj = new ClientesBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("O cliente foi excluido com sucesso!");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ClientesBLL obj = new ClientesBLL();
            
            dtgClientes.DataSource = obj.Listagem(txtFiltro.Text);
            AtualizaGrid();
        }

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Atualiza os objetos Textbox
            txtCod.Text = dtgClientes[0, dtgClientes.CurrentRow.Index].Value.ToString();
            txtNome.Text = dtgClientes[1, dtgClientes.CurrentRow.Index].Value.ToString();
            txtEmail.Text = dtgClientes[2, dtgClientes.CurrentRow.Index].Value.ToString();
            mskTelefone.Text = dtgClientes[3, dtgClientes.CurrentRow.Index].Value.ToString();

            // Aqui voce poderia usar DataRowView com DataBoundItem tmb
        }
    }
}
