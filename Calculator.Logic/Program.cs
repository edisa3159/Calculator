using Calculator.Logic;
using Calculator.Logic.Shared;

List<string> t = Tokenizer.TokenizeInputExpression("4* (3 / +124)--36++2.531*34.21");
List<Token> m = TokenListCreator.createListOfTokenObjects(t);
InfixToPostfixConvertor.ConvertInfixToPostfix(m);