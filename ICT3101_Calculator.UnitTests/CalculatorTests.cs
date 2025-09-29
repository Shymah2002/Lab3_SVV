namespace ICT3101_Calculator.UnitTests
{
    //This calculator test, is validating if the methods works
    //Does not affect your actual apps
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }
        // ------------------ Addition -----------------
        // 1 test case
        [Test]
        //Addition
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        // ------------------ Subtraction -----------------
        // 1 test case
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            // Act
            double result = _calculator.Subtract(20, 15);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        // ------------------ Multiplication -----------------
        // 1 test case
        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            // Act
            double result = _calculator.Multiply(6, 4);
            // Assert
            Assert.That(result, Is.EqualTo(24));
        }


        // ------------------ Division -----------------
        // 4 Test case (1 valid + 3 invalid with number 0)
        [Test]
        public void Division_WhenDividingTwoNumbers_ResultEqualToDivide()
        {
            // Act
            double result = _calculator.Divide(10, 2);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        //[Test]
        ////DivisionbyZero
        //public void Division_DivideByZero_ErrorException()
        //{
        //    Assert.That(() => _calculator.Divide(10, 0), Throws.ArgumentException);
        //}

        [Test]
        // Adding more test case to check properly if the method works correctly
        [TestCase(0, 0)]
        [TestCase(10, 0)]
        [TestCase(0, 10)]
        public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
        {
            Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
        }


        // ------------------ Factorial -----------------
        // 3 Test case
        [Test]
        public void Factorial_WithZero()
        {
            Assert.That(() => _calculator.Factorial(0), Is.EqualTo(1));
        }

        [Test]
        public void Factorial_WithPositive5()
        {
            Assert.That(() => _calculator.Factorial(5), Is.EqualTo(120));
        }

        [Test]
        public void Factorial_WithNegative_Error()
        {
            Assert.That(() => _calculator.Factorial(-1), Throws.ArgumentException);
        }

        // ------------------ Area of Triangle -----------------
        // 3 Test Case (2 Valid + 1 Invalid)
        [Test]
        // Valid 
        // Requires 3 number as there is 3 argument (b,h,expected)
        [TestCase(4,6,12)]
        [TestCase(2,7,7)]
        //Formula(1/2 x base x height)
        public void Area_ofTriangle(double b, double h, double expected)
        {
            Assert.That(() => _calculator.AreaofTriangle(b, h), Is.EqualTo(expected));
        }

        [Test]
        // Invalid 
        // Area of Triangle (1/2 x base x height)
        public void Area_ofTriangleInvalid()
        {
            Assert.That(() => _calculator.AreaofTriangle(-1, 5), Throws.ArgumentException);
        }

        // ------------------ Area of Circle -----------------
        [Test]
        // Valid
        [TestCase(0, 0)]
        [TestCase(1, Math.PI)]
        public void AreaOfCircle_ValidInputs_ReturnsPiR2(double r, double expected)
        {
            Assert.That(_calculator.AreaofCircle(r), Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void AreaOfCircle_NegativeRadius_ThrowsArgumentException()
        {
            Assert.That(() => _calculator.AreaofCircle(-2), Throws.ArgumentException);
        }

        // ------------------ Unknown Factorial -----------------
        [Test]
        // Permuatations (care about order)
        // Valid case: 5P2 = 20
        //5P2 = 5! / (5 - 2)! = 5 × 4 = 20
 
        public void UnknownFunctionA_ValidInputs_ReturnsCorrectResult()
        {
            Assert.That(_calculator.UnknownFunctionA(5, 2), Is.EqualTo(20));
        }

        [Test]
        // Combinations (ignore order)
        // Valid case: 5C2 = 10
        //5C2 = 5! / [2! × (5 - 2)!] = 10
        public void UnknownFunctionB_ValidInputs_ReturnsCorrectResult()
        {
            Assert.That(_calculator.UnknownFunctionB(5, 2), Is.EqualTo(10));
        }


        [Test]
        // Invalid inputs: negative n or r
        [TestCase(-5, 2)]
        [TestCase(5, -2)]
        [TestCase(2, 5)]  // r > n is invalid
        public void UnknownFunctions_InvalidInputs_ThrowsException(int n, int r)
        {
            Assert.That(() => _calculator.UnknownFunctionA(n, r), Throws.ArgumentException);
            Assert.That(() => _calculator.UnknownFunctionB(n, r), Throws.ArgumentException);
        }


    }
}
