using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefasEContatos.ConsoleApp.Dominios
{
    public class Contato : EntidadeBase
    {

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Empresa { get; private set; }
        public string Cargo { get; private set; }
        public override string ToString()
        {
            return $"ID: {Id} \nNome: {Nome} \nEmail: {Email} \nTelefone: {Telefone}" +
                $" \nEmpresa: {Empresa} \nCargo: {Cargo}" +
                $"\n------------------------------------------------------------------------------------------------------------------------";
        }
    }
}
