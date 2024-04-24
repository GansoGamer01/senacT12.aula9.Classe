namespace WinFormsAppClasse
{
    public partial class FormConta : Form
    {
        // criado um objeto chamado conta do tipo Conta //
        Conta conta = new Conta();

        public FormConta()
        {
            InitializeComponent();
            btnSacar.Enabled = false;
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            conta = new Conta();
            // determinei os atributos do objeto conta //
            // obtendo o texto do txtNumeroConta e atribuindo ao NumeroConta //
            conta.NumeroConta = int.Parse(txtNumeroConta.Text);
            conta.Nome = txtTitularConta.Text;
            conta.Depositar(100);


            // carregar o listbox com os dados da conta. //
            string dadosConta = "Numero: " + conta.NumeroConta +
                                " Titular: " + conta.Nome +
                                " Saldo:   " + conta.Saldo;

            listBox1.Items.Add(dadosConta);
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            // se a string txtValor.text está nula ou vazia //
            if (string.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Focus();
                MessageBox.Show("preencha o valor de deposito");

                // encerra o metodo de clique //
                return;
            }
            // criar uma variavel para obter o valor a ser depositado //
            decimal valorADepositar = decimal.Parse(txtValor.Text);

            // chama o metodo depositar da classe conta //
            conta.Depositar(valorADepositar);

            // monta uma string chamada dadosconta com o saldo atualizado //
            string dadosConta = "Numero: " + conta.NumeroConta +
                                " Titular: " + conta.Nome +
                                " Saldo:   " + conta.Saldo;

            // adiciona um item novo no listbox com o saldo atualizado //
            listBox1.Items.Add(dadosConta);
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            conta.Sacar(100);
            string dadosConta = "Numero: " + conta.NumeroConta +
                    " Titular: " + conta.Nome +
                    " Saldo:   " + conta.Saldo;

            listBox1.Items.Add(dadosConta);
        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            if(txtValor.Text.Length > 0)
                btnSacar.Enabled = true;              
        }
    }
}
