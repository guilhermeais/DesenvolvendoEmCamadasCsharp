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
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }

        private void Produtos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            txtNomeProduto.Focus();
        }

        private void AtualizaGrid()
        {
            // Comunicação com a camada BLL
            ProdutosBLL obj = new ProdutosBLL();
            dtgProdutos.DataSource = obj.Listagem(txtFiltro.Text);
            try
            {
                txtCod.Text = "";
                txtNomeProduto.Text = "";
                txtPreco.Text = "";
                txtxEstoque.Text = "";
                if (dtgProdutos.CurrentRow != null)
                {
                    DataRowView r = dtgProdutos.CurrentRow.DataBoundItem as DataRowView;

                    txtCod.Text = r["codigo"].ToString();
                    txtNomeProduto.Text = r["nome"].ToString();
                    txtPreco.Text = r["preco"].ToString();
                    txtxEstoque.Text = r["estoque"].ToString();
                }

            }
            catch
            {
                txtCod.Text = "";
                txtNomeProduto.Text = "";
                txtPreco.Text = "";
                txtxEstoque.Text = "";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtNomeProduto.Text = "";
            txtPreco.Text = "";
            txtxEstoque.Text = "";
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Produtoinformation produto = new Produtoinformation();
                produto.Nome = txtNomeProduto.Text;
                produto.Preco = decimal.Parse(txtPreco.Text);
                produto.Estoque = Convert.ToInt32(txtxEstoque.Text);

                ProdutosBLL obj = new ProdutosBLL();
                obj.Inserir(produto);
                MessageBox.Show("O produto foi inserido com sucesso!");
                txtCod.Text = Convert.ToString(produto.Codigo);
                AtualizaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text.Trim().Length == 0)
            {
                MessageBox.Show("Um produto deve ser selecionado para alteração");
            }
            else
            {
                try
                {
                    Produtoinformation produto = new Produtoinformation();
                    produto.Codigo = int.Parse(txtCod.Text);
                    produto.Nome = txtNomeProduto.Text;
                    produto.Preco = decimal.Parse(txtPreco.Text);
                    produto.Estoque = Convert.ToInt32(txtxEstoque.Text);

                    ProdutosBLL obj = new ProdutosBLL();
                    obj.Alterar(produto);
                    MessageBox.Show("O produto foi alterado com sucesso!");
                    
                    AtualizaGrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCod.Text.Trim().Length == 0)
            {
                MessageBox.Show("Um produto deve ser selecionado para exclusão");
            }
            else
            {
                try
                {
                    int codigo = Convert.ToInt32(txtCod.Text);
                    ProdutosBLL obj = new ProdutosBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("O produto foi excluido com sucesso!");
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
            ProdutosBLL obj = new ProdutosBLL();
            obj.Listagem(txtFiltro.Text);
            AtualizaGrid();
        }

        private void dtgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView r = dtgProdutos.CurrentRow.DataBoundItem as DataRowView;

            txtCod.Text = r["codigo"].ToString();
            txtNomeProduto.Text = r["nome"].ToString();
            txtPreco.Text = r["preco"].ToString();
            txtxEstoque.Text = r["estoque"].ToString();
        }
    }
}
