using System;
using SQLite;
namespace Desafio2.Models
{
    /// <summary>
    /// DataBase Model de Mes
    /// </summary>
    public class Mes
    {
        [PrimaryKey, AutoIncrement]
        public int Id{ get; set; }
        public string MesAno{ get; set; }
    }
}
