using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepository
    {
        int Inserir(ContasPagar contasPagar);

        bool Apagar(int id);

        bool Atualizar(ContasPagar contasPagar);

        ContasPagar ObterPeloId(int id);

        List<ContasPagar> ObterTodos(string busca);


    }
}
