using CursoOnline.DominioTest._Util;
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
                new Curso(nomeInvalido, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor)).ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                nome = "Informações básicas",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.nome, cargaHorariaInvalida, cursoEsperado.publicoAlvo, cursoEsperado.valor)).ComMensagem("Carga horaria inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                nome = "Informações básicas",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.nome, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, valorInvalido)).ComMensagem("Valor inválido");
        }
    }
}
