using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio2.Models;
using SQLite;
namespace Desafio2.Data
{
    /// <summary>
    /// Classe de Acesso a Dados
    /// </summary>
    public class DBConnection
    {
        readonly SQLiteAsyncConnection database;

        public DBConnection(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Mes>().Wait();
            database.CreateTableAsync<Movimentacao>().Wait();
        }

        /// <summary>
        /// Busca o mês pelo nome na base de dados
        /// </summary>
        /// <returns>The mes.</returns>
        /// <param name="mesAno">Mes ano.</param>
        public Task<Mes> BuscarMes(string mesAno)
        {
            return database.Table<Mes>().Where(x => x.MesAno.Equals(mesAno)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Salva o mes na base de dados
        /// </summary>
        /// <returns>The mes async.</returns>
        /// <param name="mes">Mes.</param>
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

        /// <summary>
        /// Lista todos os meses cadastrados na base de dados
        /// </summary>
        /// <returns>The meses.</returns>
        public Task<List<Mes>> ListarMeses()
        {
            return database.Table<Mes>().ToListAsync();
        }

        /// <summary>
        /// Lista movimentacoes filtrando pelo mes
        /// </summary>
        /// <returns>The movimentacoes.</returns>
        /// <param name="mesId">Mes identifier.</param>
        public Task<List<Movimentacao>> ListarMovimentacoes(int mesId)
        {
            return database.QueryAsync<Movimentacao>("SELECT * FROM [Movimentacao] WHERE MesId=" + mesId);
        }

        /// <summary>
        /// Salva movimentação na base de dados
        /// </summary>
        /// <returns>The movimentacao async.</returns>
        /// <param name="mov">Mov.</param>
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
