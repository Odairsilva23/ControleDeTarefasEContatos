using ControleDeTarefasEContatos.ConsoleApp.Controlador;
using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tarefas.test
{
    [TestClass]
    public class ContatoTests
    {
        private ControladorContato controlador1;
        private Contato contatoTeste;
        private ControladorContato Controlador1 { get => controlador1; set => controlador1 = value; }
        private Contato ContatoTeste { get => contatoTeste; set => contatoTeste = value; }

        public ContatoTests()
        {
            Controlador1 = new ControladorContato();
            contatoTeste = new Contato("Djanho veio", "dj@gmail.com", "821215125", "Djanho SA", "Vendas");
        }

        [TestMethod]
        public void DeveInserirContato()
        {
            Assert.IsTrue(controlador1.InserirRegistro(contatoTeste));
        }
    
        [TestMethod]
        public void DeveAtualizarContato()
        {
            Assert.IsTrue(controlador1.EditarRegistro(contatoTeste,1));
        }

        [TestMethod]
        public void DeveExcluirContato()
        {
            Assert.IsTrue(controlador1.ExcluirRegistro(1));
        }

        [TestMethod]
        public void DeveValidarinformacoesdoContato()
        {
            Assert.IsNotNull(controlador1.ValidarRegistros(contatoTeste));
        }

        [TestMethod]
        public void DeveSelecionarTodasEmAberto()
        {
            List<Contato> contatos = controlador1.VisualizarContatosSalvos();

            Assert.IsTrue(contatos.Count > 0);
        }

    }
}
