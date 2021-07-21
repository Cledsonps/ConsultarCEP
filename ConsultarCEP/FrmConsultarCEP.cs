using System;
using System.Windows.Forms;

namespace ConsultarCEP
{
    /// <summary>
    /// App super simples o qual faz parte do curso que realizei na Udemy.
    /// Fiz este curso apenas para sentir as mudanças entre o Delphi6 que foi a ultiama versão que trabalhei,
    /// e o Visual Studio 2019.
    /// </summary>
    public partial class FrmConsultarCEP : Form
    {
        public FrmConsultarCEP()
        {
            InitializeComponent();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtCEP.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txtCEP.Text.Trim());

                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
