using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepositoryContaPagar
    {
        int Inserir(ContaPagar contasPagar);

        bool Apagar(int id);

        bool Atualizar(ContaPagar contasPagar);

        ContaPagar ObterPeloId(int id);

        List<ContaPagar> ObterTodos(string busca);


    }
}
