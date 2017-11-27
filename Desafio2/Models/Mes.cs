using System;
using SQLite;
namespace Desafio2.Models
{
    public class Mes
    {
        [PrimaryKey, AutoIncrement]
        public int Id{ get; set; }
        public string MesAno{ get; set; }
    }
}
