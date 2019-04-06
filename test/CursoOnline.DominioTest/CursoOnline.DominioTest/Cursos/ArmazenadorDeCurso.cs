using System;

namespace CursoOnline.DominioTest.Cursos
{
    internal class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso()
        {
        }

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        internal void Armazenar(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.publicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
                throw new ArgumentException("Publico Alvo inválido");

            var curso = new Curso(cursoDto.nome, cursoDto.descricao, cursoDto.cargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}