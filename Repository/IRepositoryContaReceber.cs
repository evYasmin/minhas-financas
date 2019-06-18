using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepositoryContaReceber
    {
        int Inserir(ContasReceber contasReceber);

        bool Apagar(int id);

        bool Atualizar(ContasReceber contasReceber);

        ContasReceber ObterPeloId(int id);

        List<ContasReceber> ObterTodos(string busca);
    }
}
