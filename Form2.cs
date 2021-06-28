﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_banco_Crude_
{
    public partial class Form2 : Form
    {
        //Dados da conexao
        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public Form2()
        {
            InitializeComponent();
        }

        //Criando um metodo/função .....
        public void listarFuncionarios2()
        {
            try
            {
                //1 passo - conexao com o comando de dados
                MySqlConnection con = new MySqlConnection(conexao);

                //2 passo - montar e executar o comando Sql
                string sql_select_funcionarios = "select * from tb_funcionarios";

                //3 passo - montar e organizar comando sql
                MySqlCommand executacmdMySql_select = new MySqlCommand(sql_select_funcionarios, con);

                con.Open();
                executacmdMySql_select.ExecuteNonQuery();

                // 4 passo - criar um data table
                DataTable tabela_funcionarios = new DataTable();

                //5 passo - criar o MySqlDataAdapter
                MySqlDataAdapter da_funcionarios = new MySqlDataAdapter(executacmdMySql_select);

                da_funcionarios.Fill(tabela_funcionarios);

                //6 passo - exibir o data table no datagridview
               DgvListarFuncionarios.DataSource = tabela_funcionarios;

          
                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu um erro" + erro);

            }


   

        }

        private void listarFuncionarios()
        {
            //chama o metodo que lista clientes
            listarFuncionarios2();
        
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            //botao cadastrar
            {
                //Botão Cadastrar 
                try
                {
                    // Conexão com o banco de dados
                    MySqlConnection con = new MySqlConnection(conexao);



                    // 2 passo - Pegar os dados da tela
                    int codigo;
                    string nome;
                    string rg;
                    string cpf;
                    string email;
                    string senha;
                    string cargo;
                    string niveldeacesso;
                    int numero;
                    string telefone;
                    string celular;
                    string cep;
                    string endereco;
                    string complemento;
                    string bairro;
                    string cidade;
                    string estado;
           

                    codigo = int.Parse(txtcodigo.Text);
                    nome = txtnome.Text;
                    rg = txtrg.Text;
                    cpf = txtcpf.Text;
                    email = txtemail.Text;
                    senha = txtsenha.Text;
                    cargo = txtcargo.Text;
                    niveldeacesso = txtniveldeacesso.Text;
                    numero = int.Parse(txtnumero.Text);
                    telefone = txtele.Text;
                    celular = txtcelular.Text;
                    cep = txtcep.Text;
                    endereco= txtendereco.Text;
                    complemento = txtcomplemento.Text;
                    bairro = txtbairro.Text;
                    cidade = txtcidade.Text;
                    estado = txtestado.Text;


                    // 3 passo- Montar e executar o comando SQL 

                    string sql_insert = @"insert into tb_funcionarios
(tb_funcionarios_nome, 
tb_funcionarios_rg,
tb_funcionarios_cpf,
tb_funcionarios_email ,
tb_funcionarios_senha,
tb_funcionarios_cargo,
tb_funcionarios_nivel_acesso,
tb_funcionarios_telefone,
tb_funcionarios_celular,
tb_funcionarios_cep,
tb_funcionarios_endereco, 
tb_funcionarios_numero,
tb_funcionarios_complemento,
tb_funcionarios_bairro,
tb_funcionarios_cidade,
tb_funcionarios_estado)
values (@funcionarios_nome, @funcionarios_rg,@funcionarios_cpf, @funcionarios_email, @funcionarios_senha, 
@funcionarios_cargo, @funcionarios_nivel_acesso, @funcionarios_telefone, @funcionarios_celular, @funcionarios_cep,
@funcionarios_endereco, @funcionarios_numero,@funcionarios_complemento,@funcionarios_bairro,@funcionarios_cidade,@funcionarios_estado)";

                    //Montar e organizar o comando

                    MySqlCommand executacmdMsql_insert = new MySqlCommand(sql_insert, con);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_nome", nome);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_rg", rg);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_cpf", cpf);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_email", email);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_senha", senha);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_cargo", cargo);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_nivel_acesso", niveldeacesso);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_telefone", telefone);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_celular", celular);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_cep", cep);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_endereco", endereco);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_numero", numero);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_complemento", complemento);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_bairro", bairro);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_cidade", cidade);
                    executacmdMsql_insert.Parameters.AddWithValue("@funcionarios_estado", estado);

                    //abrir conexão

                    con.Open();


                    //Executa o comando SQL
                    executacmdMsql_insert.ExecuteNonQuery();

                    //fechar conexão
                    con.Close();
                    MessageBox.Show("Funcionario cadastrado com Sucesso!");

                    //liste os clientes
                    listarFuncionarios2();

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Deu um erro:" + erro);
                }
          
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listarFuncionarios();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            //botao alterar
            try
            {
                // Conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(conexao);


                //2 receber os dados que irao ser alterados
                // 2 passo - Pegar os dados da tela
                // 2 passo - Pegar os dados da tela
               
                int id;
                string nome;
                string rg;
                string cpf;
                string email;
                string senha;
                string cargo;
                string niveldeacesso;
                int numero;
                string telefone;
                string celular;
                string cep;
                string endereco;
                string complemento;
                string bairro;
                string cidade;
                string estado;

                id = int.Parse(txtcodigo.Text);
                
                nome = txtnome.Text;
                rg = txtrg.Text;
                cpf = txtcpf.Text;
                email = txtemail.Text;
                senha = txtsenha.Text;
                cargo = txtcargo.Text;
                niveldeacesso = txtniveldeacesso.Text;
                numero = int.Parse(txtnumero.Text);
                telefone = txtele.Text;
                celular = txtcelular.Text;
                cep = txtcep.Text;
                endereco = txtendereco.Text;
                complemento = txtcomplemento.Text;
                bairro = txtbairro.Text;
                cidade = txtcidade.Text;
                estado = txtestado.Text;


                // 3 passo- Montar e executar o comando SQL (update)

                string sql_update_funcionarios = @"update tb_funcionarios 
set  tb_funcionarios_nome = @funcionarios_nome , 
tb_funcionarios_rg= @funcionarios_rg ,
 tb_funcionarios_cpf = @funcionarios_cpf,
tb_funcionarios_email = @funcionarios_email ,
tb_funcionarios_senha = @funcionarios_senha,
tb_funcionarios_cargo = @funcionarios_cargo ,
 tb_funcionarios_nivel_acesso = @funcionarios_nivel_acesso ,
tb_funcionarios_telefone = @funcionarios_telefone ,
tb_funcionarios_celular = @funcionarios_celular ,
tb_funcionarios_cep = @funcionarios_cep ,
tb_funcionarios_endereco = @funcionarios_endereco ,  
tb_funcionarios_numero = @funcionarios_numero ,
tb_funcionarios_complemento= @funcionarios_complemento ,  
tb_funcionarios_bairro = @funcionarios_bairro, 
tb_funcionarios_cidade = @funcionarios_cidade ,  
tb_funcionarios_estado = @funcionarios_estado 
where tb_funcionarios_id = @funcionarios_id";



                //Montar e organizar o comando

          
                MySqlCommand executacmdMsql_update = new MySqlCommand(sql_update_funcionarios, con);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_nome", nome);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_rg", rg);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_cpf", cpf);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_email", email);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_senha", senha);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_cargo", cargo);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_nivel_acesso", niveldeacesso);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_telefone", telefone);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_celular", celular);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_cep", cep);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_endereco", endereco);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_numero", numero);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_complemento", complemento);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_bairro", bairro);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_cidade", cidade);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_estado", estado);
                executacmdMsql_update.Parameters.AddWithValue("@funcionarios_id", id);


                //abrir conexão

                con.Open();


                //Executa o comando SQL
                executacmdMsql_update.ExecuteNonQuery();

                //fechar conexão
                con.Close();
                MessageBox.Show("Funcionarios alterado com Sucesso!");

                //liste os clientes
                listarFuncionarios2();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Deu um erro:" + erro);
            }



        }

        private void DgvListarFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }


        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //botao excluir
            try
            {
                // Conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(conexao);

                //2 receber dados do cliente que será excluido
                int id = int.Parse(txtcodigo.Text);

                // 3 passo- Montar e executar o comando SQL (delete)

                string sql_delete_fornecedores = @"delete from tb_funcionarios where tb_funcionarios_id = @funcionarios_id";

                //Montar e organizar o comando sql

                MySqlCommand executacmdMySql_delete = new MySqlCommand(sql_delete_fornecedores, con);
                executacmdMySql_delete.Parameters.AddWithValue("@funcionarios_id", id);


                //abrir conexão

                con.Open();


                //Executa o comando SQL
                executacmdMySql_delete.ExecuteNonQuery();


                //fechar conexão
                con.Close();
                MessageBox.Show("Funcionarios excluido com Sucesso!");

                //liste os clientes
                listarFuncionarios2();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu um erro:" + erro);

            }
        }
        private void DgvListarFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = DgvListarFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = DgvListarFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = DgvListarFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = DgvListarFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = DgvListarFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = DgvListarFuncionarios.CurrentRow.Cells[5].Value.ToString();
            txtcargo.Text = DgvListarFuncionarios.CurrentRow.Cells[6].Value.ToString();
            txtniveldeacesso.Text = DgvListarFuncionarios.CurrentRow.Cells[7].Value.ToString();
            txtele.Text = DgvListarFuncionarios.CurrentRow.Cells[8].Value.ToString();
            txtcelular.Text = DgvListarFuncionarios.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = DgvListarFuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = DgvListarFuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtnumero.Text = DgvListarFuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtcomplemento.Text = DgvListarFuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtbairro.Text = DgvListarFuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtcidade.Text = DgvListarFuncionarios.CurrentRow.Cells[15].Value.ToString();
            txtestado.Text = DgvListarFuncionarios.CurrentRow.Cells[16].Value.ToString();



        }

    }
}

