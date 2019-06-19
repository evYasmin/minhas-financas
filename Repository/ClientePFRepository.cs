using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientePFRepository
    {
        private Conexao conexao;

        public ClientePFRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "DELETE FROM clientesPF WHERE id = @ID";
            comando.Parameters.AddWithValue("ID", id);
            int quantidadeAfeta = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfeta == 1;
        }

        public bool Atualizar(ClientePF clientePF)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = @"UPDATE cientes_pessoa_fisica SET
nome = @NOME , 
cpf = @CPF , 
data_nascimento = @DATA_NASCIMENTO , 
rg = @RG , 
sexo = @SEXO 
WHERE  id = @ID";

            comando.Parameters.AddWithValue("@NOME", clientePF.Nome);
            comando.Parameters.AddWithValue("@CPF", clientePF.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", clientePF.DataNascimento);
            comando.Parameters.AddWithValue("@RG", clientePF.Rg);
            comando.Parameters.AddWithValue("@SEXO", clientePF.Sexo);
            comando.Parameters.AddWithValue("@ID", clientePF.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ClientePF clientePF)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = @"INSERT INTO clientes_pessoa_fisica (nome, cpf, data_nascimento, rg,sexo)
OUTPUT INSERTED.ID
VALUES (@NOME , @CPF , @DATA_NASCIMENTO , @RG , @SEXO)";

            comando.Parameters.AddWithValue("@NOME", clientePF.Nome);
            comando.Parameters.AddWithValue("@CPF", clientePF.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", clientePF.DataNascimento);
            comando.Parameters.AddWithValue("@RG", clientePF.Rg);
            comando.Parameters.AddWithValue("SEXO", clientePF.Sexo);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public ClientePF ObterPeloId(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM clientes_pessoa_fisica WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            ClientePF clientePF = new ClientePF();
            clientePF.Id = Convert.ToInt32(linha["id"]);
            clientePF.Nome = linha["nome"].ToString();
            clientePF.Cpf = linha["cpf"].ToString();
            clientePF.Rg = linha["rg"].ToString();
            return clientePF;
        }

        public List<ClientePF> Obtertodos(string busca)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM clientes_pessoa_fisica WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ClientePF> clientesPF = new List<ClientePF>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                ClientePF clientePF = new ClientePF();
                clientePF.Id = Convert.ToInt32(linha["id"]);
                clientePF.Nome = linha["nome"].ToString();
                clientePF.Cpf = linha["cpf"].ToString();
                clientePF.Rg = linha["rg"].ToString();
                clientesPF.Add(clientePF);
            }
            return clientesPF;
        }
    }
}
