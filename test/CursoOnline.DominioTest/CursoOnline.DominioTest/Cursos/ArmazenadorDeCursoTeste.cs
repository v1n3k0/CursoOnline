using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTeste
    {
        

        [Fact]
        public void DeveAdicionarCurso()
        {
            var CursoDto = new CursoDto
            {
                nome = "Curso A",
                descricao = "Descrição",
                cargaHoraria = 80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = 850.00
            };

            var armazenadorDeCurso = new ArmazenadorDeCurso();

            armazenadorDeCurso.Armazenar(CursoDto);
        }
    }
}
