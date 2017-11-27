using System;
using System.Drawing;
using SQLite;
namespace Desafio2.Models
{
    public class Movimentacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id{ get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string MovimentacaoTipo { get; set; }
        public string MovimentacaoCor { get; set; }
        [Indexed]
        public int MesId { get; set; }
    }
}
