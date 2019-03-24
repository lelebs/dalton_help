using DaltoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaltoAPI.Interface
{
    public interface IMainCommand
    {
        Task<List<DataModel>> GetDadosDb();

        Task Insert(int idCor);
    }
}
