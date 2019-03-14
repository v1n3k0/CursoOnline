using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste
    {
        [Fact]
        public void DeveCriarCurso()
        {
            const string nome = "Informações básicas";
            const int cargaHoraria = 80;
            const string publicoAlvo = "Estudante";
            const int valor = 950;

            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            Assert.Equal(nome, curso.nome);
            Assert.Equal(cargaHoraria, curso.cargaHoraria);
            Assert.Equal(publicoAlvo, curso.publicoAlvo);
            Assert.Equal(valor, curso.valor);
        }
    }
}
