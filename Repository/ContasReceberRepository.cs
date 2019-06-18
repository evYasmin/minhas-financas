using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ContasReceberRepository : IRepositoryContaReceber
    {
        private Conexao conexao;

        public ContasReceberRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "DELETE FROM contasReceber WHERE id = @ID";
            comando.Parameters.AddWithValue("ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;

        }

        public bool Atualizar(ContasReceber contaReceber)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = @"UPDATE contasReceber SET 
nome = @NOME,
valor = @VALOR , 
tipo = @TIPO ,
descricao = @DESCRICAO , 
status = @STATUS 
WHERE id = @ID";

            comando.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            comando.Parameters.AddWithValue("@ID", contaReceber.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;

        }

        public int Inserir(ContasReceber contaReceber)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = @"INSERT INTO contasReceber (nome,valor,tipo,descricao,status)
OUTPUT INSERTED.ID
VALUES (@NOME, @VALOR , @TIPO , @DESCRICAO , @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            int id = Convert.ToInt32(comando.ExecuteNonQuery());
            comando.Connection.Close();
            return id;

        }

        public ContasReceber ObterPeloId(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM contasReceber WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            ContasReceber contasReceber = new ContasReceber();
            contasReceber.Id = Convert.ToInt32(linha["id"]);
            contasReceber.Nome = linha["nome"].ToString();
            contasReceber.Valor = Convert.ToDecimal(linha["valor"]);
            contasReceber.Tipo = linha["tipo"].ToString();
            contasReceber.Descricao = linha["descricao"].ToString();
            contasReceber.Status = linha["status"].ToString();
            return contasReceber;
        }

        public List<ContasReceber> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM contasReceber WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ContasReceber> contasReceber = new List<ContasReceber>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {

            }
        }
    }
}
