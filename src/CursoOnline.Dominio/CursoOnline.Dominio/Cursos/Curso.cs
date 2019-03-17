using System;

namespace CursoOnline.DominioTest.Cursos
{
    public class Curso
    {
        public string nome { get; private set; }
        public double cargaHoraria { get; private set; }
        public PublicoAlvo publicoAlvo { get; private set; }
        public double valor {get; private set; }
        public string descricao { get; private set; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horaria inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            this.nome = nome;
            this.cargaHoraria = cargaHoraria;
            this.publicoAlvo = publicoAlvo;
            this.valor = valor;
            this.descricao = descricao;
        }
    }
}