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
    public class ContaPagarRepository : IRepositoryContaPagar
    {

        private Conexao conexao;

        public ContaPagarRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "DELETE FROM contasPagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Atualizar(ContaPagar contasPagar)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = @"UPDATE contasPagar SET 
nome = @NOME , 
valor = @VALOR , 
tipo = @TIPO , 
descricao = @DESCRICAO ,
 status = @STATUS
WHERE id = @ID";

            comando.Parameters.AddWithValue("@NOME", contasPagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contasPagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contasPagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contasPagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contasPagar.Status);
            comando.Parameters.AddWithValue("@ID", contasPagar.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ContaPagar contasPagar)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = @"INSERT INTO contasPagar (nome,valor,tipo,descricao,status)
OUTPUT INSERTED.ID
VALUES (@NOME , @VALOR , @TIPO , @DESCRICAO , @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contasPagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contasPagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contasPagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contasPagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contasPagar.Status);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public ContaPagar ObterPeloId(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM contasPagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            ContaPagar contasPagar = new ContaPagar();
            contasPagar.Id = Convert.ToInt32(linha["id"]);
            contasPagar.Nome = linha["nome"].ToString();
            contasPagar.Valor = Convert.ToDecimal(linha["valor"]);
            contasPagar.Tipo = linha["tipo"].ToString();
            contasPagar.Descricao = linha["descricao"].ToString();
            contasPagar.Status = linha["status"].ToString();
            return contasPagar;

        }

        public List<ContaPagar> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM contasPagar WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ContaPagar> contasPagar = new List<ContaPagar>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                ContaPagar contaPagar = new ContaPagar();
                contaPagar.Id = Convert.ToInt32(linha["id"]);
                contaPagar.Nome = linha["nome"].ToString();
                contaPagar.Valor = Convert.ToDecimal(linha["valor"]);
                contaPagar.Tipo = linha["tipo"].ToString();
                contaPagar.Descricao = linha["descricao"].ToString();
                contaPagar.Status = linha["status"].ToString();
                contasPagar.Add(contaPagar);
            }
            return contasPagar;


        }


    }
}
