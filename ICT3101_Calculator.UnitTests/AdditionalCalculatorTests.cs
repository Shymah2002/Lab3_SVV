using NUnit.Framework;
using Moq;
using ICT3101_Calculator;
using System.IO;

[TestFixture]
public class AdditionalCalculatorTests
{
    private Calculator _calculator;
    private Mock<IFileReader> _mockFileReader;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
        _mockFileReader = new Mock<IFileReader>();

        // Default setup for MagicNumbers.txt
        _mockFileReader
            .Setup(fr => fr.Read("MagicNumbers.txt"))
            .Returns(new string[] { "42", "-3.5", "0" });
    }

    [Test]
    public void GenMagicNum_WithMockChoice0_Returns84()
    {
        double result = _calculator.GenMagicNum(0, _mockFileReader.Object);
        Assert.AreEqual(84.0, result);
        _mockFileReader.Verify(fr => fr.Read("MagicNumbers.txt"), Times.Once);
    }

    [Test]
    public void GenMagicNum_WithMockChoice1_Returns7()
    {
        double result = _calculator.GenMagicNum(1, _mockFileReader.Object);
        Assert.AreEqual(7.0, result);
    }

    [Test]
    public void GenMagicNum_WithMockChoiceOutOfRange_ReturnsZero()
    {
        double result = _calculator.GenMagicNum(999, _mockFileReader.Object);
        Assert.AreEqual(0.0, result);
    }

    [Test]
    public void GenMagicNum_WhenReaderThrows_FileNotFoundException()
    {
        _mockFileReader
            .Setup(fr => fr.Read(It.IsAny<string>()))
            .Throws(new FileNotFoundException());

        Assert.Throws<FileNotFoundException>(() =>
            _calculator.GenMagicNum(0, _mockFileReader.Object));
    }
}
