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
            var curso = new Curso(cursoDto.nome, cursoDto.descricao, cursoDto.cargaHoraria, PublicoAlvo.Estudante, cursoDto.valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}