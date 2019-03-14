namespace CursoOnline.DominioTest.Cursos
{
    internal class Curso
    {
        public string nome { get; private set; }
        public double cargaHoraria { get; private set; }
        public PublicoAlvo publicoAlvo { get; private set; }
        public double valor {get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            this.nome = nome;
            this.cargaHoraria = cargaHoraria;
            this.publicoAlvo = publicoAlvo;
            this.valor = valor;
        }
    }
}