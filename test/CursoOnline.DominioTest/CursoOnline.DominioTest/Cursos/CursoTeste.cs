using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                nome = "Informações básicas",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            var curso = new Curso(cursoEsperado.nome, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NaoDeveTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                nome = "Informações básicas",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            Assert.Throws<ArgumentException>(() => 
                new Curso(nomeInvalido, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor));
        }

        [Fact]
        public void NaoDeveTerUmaCargaHorariaMenorQue1()
        {
            var cursoEsperado = new
            {
                nome = "Informações básicas",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.nome, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor));
        }
    }
}
