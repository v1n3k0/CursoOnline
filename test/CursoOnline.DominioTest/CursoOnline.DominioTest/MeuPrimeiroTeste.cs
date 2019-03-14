using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar")]
        public void VariaveisDeMesmoValor()
        {
            //Organização
            var var1 = 1;
            var var2 = 1;

            //Ação
            var2 = var1;

            //Assert
            Assert.Equal(var1, var2);

        }
    }
}
