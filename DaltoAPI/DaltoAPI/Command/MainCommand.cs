using System.Collections.Generic;
using System.Threading.Tasks;
using DaltoAPI.Interface;
using DaltoAPI.Models;
using Npgsql;

namespace DaltoAPI.Command
{
    public class MainCommand: IMainCommand
    {
        public async Task<List<DataModel>> GetDadosDb()
        {
            List<DataModel> lista = new List<DataModel>();

            ConnectionCommand connection = new ConnectionCommand();

            var query = @"
                SELECT cor.cor, COUNT(idcor) as quantidade, cor.id
                from registro
                INNER JOIN cor
                ON registro.idcor = cor.id
                GROUP BY cor.cor, cor.id
                ORDER BY cor, quantidade, cor.id";

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.GetConnection());

            var dataReader = await cmd.ExecuteReaderAsync();

            while (dataReader.Read())
            {
                DataModel data = new DataModel
                {
                    Cor = dataReader.GetString(0),
                    Quantidade = dataReader.GetInt32(1),
                    IdCor = dataReader.GetInt16(2)
                };

                lista.Add(data);
            }

            return lista;
        }

        public async Task Insert(int idCor)
        {

            ConnectionCommand connection = new ConnectionCommand();

            var query = $@"
            INSERT INTO public.registro(idcor)
            VALUES(" + idCor + ")";

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.GetConnection());

            await cmd.ExecuteNonQueryAsync();
        }
    }
}