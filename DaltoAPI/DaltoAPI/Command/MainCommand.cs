using System.Collections.Generic;
using System.Threading.Tasks;
using DaltoAPI.Interface;
using DaltoAPI.Models;
using Npgsql;

namespace DaltoAPI.Command
{
    public class MainCommand: IMainCommand
    {
        public async Task<List<ColorModel>> GetDadosDb()
        {
            List<ColorModel> lista = new List<ColorModel>();

            ConnectionCommand connection = new ConnectionCommand();

            var query = @"
                SELECT cor.id,
                       cor.cor, 
                       COUNT(idcor) as quantidade,
                       cor.hexa
                FROM registro
                INNER JOIN cor ON registro.idcor = cor.id
                GROUP BY cor.cor, cor.id
                ORDER BY cor, quantidade, cor.id";

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.GetConnection());

            var dataReader = await cmd.ExecuteReaderAsync();

            while (dataReader.Read())
            {
                ColorModel data = new ColorModel
                {
                    IdCor = dataReader.GetInt16(0),
                    Cor = dataReader.GetString(1),
                    Quantidade = dataReader.GetInt32(2),
                    Hexadecimal = dataReader.GetString(3)
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

            var cmd = new NpgsqlCommand(query, connection.GetConnection());

            await cmd.ExecuteNonQueryAsync();
        }
    }
}