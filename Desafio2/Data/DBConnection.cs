using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio2.Models;
using SQLite;
namespace Desafio2.Data
{
    public class DBConnection
    {
        readonly SQLiteAsyncConnection database;

        public DBConnection(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Mes>().Wait();
            database.CreateTableAsync<Movimentacao>().Wait();
        }

        public Task<Mes> BuscarMes(string mesAno)
        {
            return database.Table<Mes>().Where(x => x.MesAno.Equals(mesAno)).FirstOrDefaultAsync();
        }

        public Task<int> SalvarMesAsync(Mes mes)
        {
            if(mes.Id != 0)
            {
                return database.UpdateAsync(mes);
            }
            else
            {
                return database.InsertAsync(mes);
            }
        }

        public Task<List<Mes>> ListarMeses()
        {
            return database.Table<Mes>().ToListAsync();
        }

        public Task<List<Movimentacao>> ListarMovimentacoes(int movId)
        {
            return database.QueryAsync<Movimentacao>("SELECT * FROM [Movimentacao] WHERE MesId=" + movId);
        }

        public Task<int> SalvarMovimentacaoAsync(Movimentacao mov)
        {
            if (mov.Id != 0)
            {
                return database.UpdateAsync(mov);
            }
            else
            {
                return database.InsertAsync(mov);
            }
        }
    }
}
