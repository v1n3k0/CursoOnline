using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar")]
        public void VariaveisDeMesmoValor()
        {
            //Organiza��o
            var var1 = 1;
            var var2 = 1;

            //A��o
            var2 = var1;

            //Assert
            Assert.Equal(var1, var2);

        }
    }
}
