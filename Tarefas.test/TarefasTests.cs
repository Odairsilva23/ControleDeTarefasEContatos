using ControleDeTarefasEContatos.ConsoleApp.Controlador;
using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tarefas.test
{
    [TestClass]
    public class TarefasTests
    {
        public ControladorTarefa controlador;
        public Tarefa tarefaTeste;
        public TarefasTests()
        {
            controlador = new ControladorTarefa();
            tarefaTeste = new Tarefa("Alta","Fazer Cerca", new DateTime(2021, 06, 21), new DateTime(2021, 06, 25), 10);
        }
        [TestMethod]
        public void DeveInserirNovaTarefa()
        {
            Assert.IsTrue(controlador.InserirRegistro(tarefaTeste));
        }

        [TestMethod]
        public void DeveAtualizarTarefa()
        {
            tarefaTeste.Percentual = 100;
            Assert.IsTrue(controlador.EditarRegistro(tarefaTeste,1));
        }

        [TestMethod]
        public void DeveExcluirTarefa()
        {
            Assert.IsTrue(controlador.ExcluirRegistro(1));
        }

        [TestMethod]
        public void DeveSelecionarTarefaPorId()
        {
            List<Tarefa> tarefas = controlador.VisualizarTodosRegistros();

            Assert.IsTrue(tarefas.Count > 0);
        }

        [TestMethod]
        public void DeveSelecionarTodasEmAberto()
        {
            List<Tarefa> tarefas = controlador.VisualizarTarefasPendentes();

            Assert.IsTrue(tarefas.Count > 0);
        }

        [TestMethod]
        public void DeveSelecionarTodasTarefasConcluidas()
        {
            List<Tarefa> tarefas = controlador.VisualizarTarefasFinalizadas();

            Assert.IsTrue(tarefas.Count > 0);
        }

        [TestMethod]
        public void DeveValidarInformacoesnoCadastrodeTarefas()
        {
            Assert.IsNotNull(controlador.ValidarRegistros(tarefaTeste));
        }
        [TestMethod]
        public void DeveValidarInformacoesnoCadastrodeTa()
        {
            bool result = controlador.ValidarRegistros(tarefaTeste);

            Assert.IsFalse(result);
        }
    }
}

