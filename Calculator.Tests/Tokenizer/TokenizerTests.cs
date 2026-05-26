using Calculator.Logic;
using Shouldly;

namespace Calculator.Tests.TokenizerTests;

public class TokenizerTests
{
    [Fact]
    public void Tokenize_ValidExpression_ShouldPreserveAllCharacters()
    {
        string input = "4*(3/+124)--36";
        var tokens = Tokenizer.TokenizeInputExpression(input);                    

        string reconstructed = string.Concat(tokens);
        reconstructed.ShouldBe(input.Replace(" ", ""));
    }

    [Fact]
    public void TokenizeInputExpression_ValidExpression_ReturnsCorrectTokens()
    {
        // Arrange
        string input = "4* (3 / +124)--36*2.31";
        List<string> expectedTokens = new List<string> { "4", "*", "(", "3", "/", "+124", ")", "-", "-36", "*", "2.31" };
        // Act
        List<string> actualTokens = Tokenizer.TokenizeInputExpression(input);
        // Assert
        expectedTokens.ShouldBe(actualTokens);

    }
        
    [Fact]
    public void Tokenize_ValidExpression_ShouldHandleUnaryOperatorsCorrectly()
    {
        string input = "+124 - -36 * 5 (3.59/2.15)";
        var tokens = Tokenizer.TokenizeInputExpression(input);

        tokens.ShouldContain("+124");
        tokens.ShouldContain("-");
    }
}
