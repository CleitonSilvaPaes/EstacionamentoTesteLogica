using Estacionamento.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Interface
{
    public interface IEstacionamentoContextFactory
    {
        EstacionamentoContext Create();
    }

}
