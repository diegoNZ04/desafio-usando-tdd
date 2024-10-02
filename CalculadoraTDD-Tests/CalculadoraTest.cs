using CalculadoraTDD.Services;

namespace CalculadoraTDD_Tests;

public class CalculadoraTest
{
    public Calculadora construirClasse()
    {
        string data = "02/02/2020";
        Calculadora calc = new Calculadora("02/02/2020");

        return calc;
    }
    
    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TesteSoma(int num1, int num2, int resultado)
    {
        // Arrange
        Calculadora calc = construirClasse();

        // Action
        int resultadoEsperado = calc.Somar(num1, num2);

        // Assert
        Assert.Equal(resultado, resultadoEsperado);
    }

    [Theory]
    [InlineData (5, 5, 25)]
    [InlineData (9, 10, 90)]
    public void TesteMultiplicar(int num1, int num2, int resultado)
    {
        // Arrange
        Calculadora calc = construirClasse();

        // Action
        int resultadoEsperado = calc.Multiplicar(num1, num2);

        // Assert
        Assert.Equal(resultado, resultadoEsperado);
    }

    [Theory]
    [InlineData (80, 60, 20)]
    [InlineData (90, 40, 50)]
    public void TesteSubtrair(int num1, int num2, int resultado)
    {
        // Arrange
        Calculadora calc = construirClasse();

        // Action
        int resultadoEsperado = calc.Subtrair(num1, num2);

        // Assert
        Assert.Equal(resultado, resultadoEsperado);
    }

    [Theory]
    [InlineData (10, 2, 5)]
    [InlineData (60, 3, 20)]
    public void TesteDividir(int num1, int num2, int resultado)
    {
        // Arrange
        Calculadora calc = construirClasse();

        // Action
        int resultadoEsperado = calc.Dividir(num1, num2);

        // Assert
        Assert.Equal(resultado, resultadoEsperado);
    }

    [Fact]
    public void TesteDividirPorZero()
    {
        Calculadora calc = construirClasse();

        Assert.Throws<DivideByZeroException>(
            () => calc.Dividir(3,0)
        );
    }

    [Fact]
      public void TesteHistorico()
    {
        Calculadora calc = construirClasse();

        calc.Somar(1, 2);
        calc.Somar(2, 3);
        calc.Somar(4, 5);   

        var lista = calc.Historico();

        Assert.NotEmpty(calc.Historico());
        Assert.Equal(3, lista.Count());
    }
}