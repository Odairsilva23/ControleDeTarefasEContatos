using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ControleDeTarefasEContatos.ConsoleApp.Controlador
{
     public class ControladorContato : Controlador<Contato>
    {
      
        public bool ValidarRegistros(Contato contato)
        {

            if (string.IsNullOrEmpty(contato.Nome))
                return false;
            if (string.IsNullOrEmpty(contato.Cargo))
                return false;
            if (string.IsNullOrEmpty(contato.Email))
                return false;
            if (string.IsNullOrWhiteSpace(contato.Email))
                return false;
            if (!contato.Email.Contains("@") && !contato.Email.Contains(".com"))
                return false;
            if (string.IsNullOrEmpty(contato.Empresa))
                return false;
            if (string.IsNullOrEmpty(contato.Telefone))
                return false;
            if(!contato.Telefone.Contains("0123456789"))
                return false;
            if (contato.Telefone.Length > 11)
                return false;

            return true;
        }
        public List<Contato> VisualizarContatosSalvos()
        {
            return VisualizarTodosRegistros().OrderBy(x => x.Cargo).ToList();
        }

        #region Metodos Override
        public override string Tabela => "TBCONTATOS";
        public override string Valores => "[NOME],[EMAIL],[TELEFONE],[EMPRESA],[CARGO]";
        public override string Atualizar => "[NOME] = @NOME,[EMAIL] = @EMAIL,[TELEFONE] = @TELEFONE,[EMPRESA] = @EMPRESA,[CARGO] = @CARGO";
        public override void Inserir(SqlCommand comandoInsercao, Contato contato)
        {
            comandoInsercao.Parameters.AddWithValue("NOME", contato.Nome);
            comandoInsercao.Parameters.AddWithValue("EMAIL", contato.Email);
            comandoInsercao.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comandoInsercao.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comandoInsercao.Parameters.AddWithValue("CARGO", contato.Cargo);
        }
        public override void Editar(SqlCommand comandoEdicao, int id, Contato contato)
        {
            comandoEdicao.Parameters.AddWithValue("ID", id);
            comandoEdicao.Parameters.AddWithValue("NOME", contato.Nome);
            comandoEdicao.Parameters.AddWithValue("EMAIL", contato.Email);
            comandoEdicao.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comandoEdicao.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comandoEdicao.Parameters.AddWithValue("CARGO", contato.Cargo);
        }
        #endregion
    }
}
