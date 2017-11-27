using System;
namespace Desafio2
{
    /// <summary>
    /// Interface para controle de local do Arquivo de dados
    /// </summary>
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
