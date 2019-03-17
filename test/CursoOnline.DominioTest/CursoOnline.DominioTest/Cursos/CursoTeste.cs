using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste: IDisposable
    {
        public ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTeste(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor sendo executado");

            _nome = "Informações básicas";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 950;
            _descricao = "Uma descrição";
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                nome = _nome,
                descricao = _descricao,
                cargaHoraria = _cargaHoraria,
                publicoAlvo = _publicoAlvo,
                valor = _valor
            };

            var curso = new Curso(cursoEsperado.nome, cursoEsperado.descricao, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NaoDeveTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => 
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horaria inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor inválido");
        }

    }
}
