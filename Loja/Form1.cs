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
    public partial class Loja : Form
    {
        public Loja()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // ou this.Close()
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Localiza o formulário
            foreach (Form form in this.MdiChildren)
            {
                if (form is Clientes)
                {
                    //Ativa o formulário se ja estiver aberto e retorna 
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }
            }

            // Abre o formulário caso esteja fechao
            Form formulario = new Clientes();
            this.LayoutMdi(MdiLayout.Cascade);
            formulario.MdiParent = this;
            formulario.Show();
        }
    }
}
