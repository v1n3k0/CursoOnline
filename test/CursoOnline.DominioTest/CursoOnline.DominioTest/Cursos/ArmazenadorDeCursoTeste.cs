using Bogus;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTeste
    {
        private CursoDto _cursoDto;
        private ArmazenadorDeCurso _armazenadorDeCurso;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
        
        public ArmazenadorDeCursoTeste()
        {
            var fake = new Faker();

            _cursoDto = new CursoDto
            {
                nome = fake.Random.Words(),
                descricao = fake.Lorem.Paragraph(),
                cargaHoraria = fake.Random.Double(50, 1000),
                publicoAlvo = PublicoAlvo.Estudante.ToString(),
                valor = fake.Random.Double(1000, 2000)
            };
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);

            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c => c.nome == _cursoDto.nome &&
                    c.descricao == _cursoDto.descricao
                    )
                ), Times.AtLeast(1));
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Medico";
            _cursoDto.publicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem("Publico Alvo inválido");

        }
    }
}
