using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepositoryClientePF
    {
        int Inserir(ClientePF clientesPF);

        bool Apagar(int id);

        bool Atualizar(ClientePF clientesPF);

        ClientePF ObterPeloId(int id);

        List<ClientePF> ObterTodos(string busca);
    }
}
