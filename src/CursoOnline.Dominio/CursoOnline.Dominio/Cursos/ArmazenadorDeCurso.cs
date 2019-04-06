using System;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso()
        {
        }

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var cursoSalvo = _cursoRepositorio.ObterPeloNome(cursoDto.nome);

            if(cursoSalvo != null)
                throw new ArgumentException("Nome do curso já existe");

            if (!Enum.TryParse<PublicoAlvo>(cursoDto.publicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Publico Alvo inválido");

            var curso = new Curso(cursoDto.nome, cursoDto.descricao, cursoDto.cargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}