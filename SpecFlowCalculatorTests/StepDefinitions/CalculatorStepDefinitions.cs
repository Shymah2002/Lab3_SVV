using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private Calculator _calculator;
        private double _result;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _result = _calculator.Add(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}


//using NUnit.Framework;
//namespace SpecFlowCalculatorTests.StepDefinitions
//{
//    [Binding]
//    public sealed class UsingCalculatorStepDefinitions
//    {
//        // private Calculator _calculator;
//        private readonly Calculator _calculator; // injected instance
//        private double _result;

//        // SpecFlow will inject Calculator per scenario
//        public UsingCalculatorStepDefinitions(Calculator calculator)
//        {
//            _calculator = calculator;
//        }
//        [Given(@"I have a calculator")]
//        public void GivenIHaveACalculator()
//        {
//            //_calculator = new Calculator();
//        }


//        // ADDITION ---------------------------------------------------
//        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
//        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
//        {
//            _result = _calculator.Add(p0, p1);
//        }

//        [Then(@"the result should be (.*)")]
//        public void ThenTheResultShouldBeOnTheScreen(int p0)
//        {
//            Assert.That(_result, Is.EqualTo(p0));
//        }

//        // DIVISION ---------------------------------------------------
//        // WHEN — division (handles all numeric inputs)
//        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
//        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double num1, double num2)
//        {
//            _result = _calculator.Divide(num1, num2);
//        }

//        // THEN — normal results
//        [Then(@"the division result should be (.*)")]
//        public void ThenTheDivisionResultShouldBe(double expected)
//        {
//            Assert.That(_result, Is.EqualTo(expected));
//        }

//        // THEN — positive infinity
//        [Then("the division result equals positive_infinity")]
//        public void ThenTheDivisionResultShouldBePositiveInfinity()
//        {
//            Assert.That(_result, Is.EqualTo(double.PositiveInfinity));
//        }



//        // FACTORIAL ---------------------------------------------------
//        private long _factorialResult;
//        private Exception _factorialException;

//        [When("I have entered {int} into the calculator and press factorial")]
//        public void WhenIHaveEnteredIntoTheCalculatorAndPressFactorial(int number)
//        {
//            try
//            {
//                _factorialResult = _calculator.Factorial(number);
//                _factorialException = null;
//            }
//            catch (Exception ex)
//            {
//                _factorialException = ex;
//            }
//        }


//        [Then("the factorial result should be {int}")]
//        public void ThenTheFactorialResultShouldBe(int expected)
//        {
//            Assert.That(_factorialException, Is.Null, "Expected no exception but got one.");
//            Assert.That(_factorialResult, Is.EqualTo(expected));
//        }

//        [Then("the factorial operation should throw an error")]
//        public void ThenTheFactorialOperationShouldThrowAnError()
//        {
//            Assert.That(_factorialException, Is.Not.Null, "Expected an exception but none was thrown.");
//            Assert.That(_factorialException, Is.TypeOf<ArgumentException>(),
//                $"Expected ArgumentException but got {_factorialException?.GetType().Name}");
//        }



//        //MTBF ------------------------------------------------------------------------------------------------------
//        //For MTBF & Availability
//        private double _availabilityResult;
//        private Exception _availabilityException;

//        [When("I have entered (.*) and (.*) into the calculator and press MTBF")]
//        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double totalUptime, double failures)
//        {
//            try
//            {
//                _availabilityResult = _calculator.MTBF(totalUptime, failures);
//                _availabilityException = null;
//            }
//            catch (Exception ex)
//            {
//                _availabilityException = ex;
//            }
//        }

//        // AVAILABILITY -------------------------------------------------------------------------------------
//        [When("I have entered (.*) and (.*) into the calculator and press Availability")]
//        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double uptime, double downtime)
//        {
//            try
//            {
//                _availabilityResult = _calculator.Availability(uptime, downtime);
//                _availabilityException = null;
//            }
//            catch (Exception ex)
//            {
//                _availabilityException = ex;
//            }
//        }

//        // Then for result
//        [Then("the availability result should be \"(.*)\"")]
//        public void ThenTheAvailabilityResultShouldBe(string expected)
//        {
//            // Compare as double
//            double expectedDouble = double.Parse(expected);
//            Assert.That(_availabilityException, Is.Null);
//            Assert.That(Math.Round(_availabilityResult, 3), Is.EqualTo(Math.Round(expectedDouble, 3)));
//        }



//        //BASIC MUSA -------------------------------------------------------------------------------------------------------------------------
//        private double _basicMusaResult;
//        private Exception _basicMusaException;

//        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press current failure intensity")]
//        public void WhenIHaveEnteredIntoTheCalculatorAndPressCurrentFailureIntensity(double lambda0, double N0, double tau)
//        {
//            try
//            {
//                // Handle negative or invalid inputs
//                if (lambda0 < 0 || N0 <= 0 || tau < 0)
//                    throw new ArgumentException("Invalid input");

//                _basicMusaResult = _calculator.CurrentFailureIntensity(lambda0, N0, tau);
//                _basicMusaException = null;
//            }
//            catch (Exception ex)
//            {
//                _basicMusaResult = 0; // optional default
//                _basicMusaException = ex;
//            }
//        }

//        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press average failures")]
//        public void WhenIHaveEnteredIntoTheCalculatorAndPressAverageFailures(double lambda0, double N0, double tau)
//        {
//            try
//            {
//                // Handle negative or invalid inputs
//                if (lambda0 < 0 || N0 <= 0 || tau < 0)
//                    throw new ArgumentException("Invalid input");

//                _basicMusaResult = _calculator.AverageFailures(lambda0, N0, tau);
//                _basicMusaException = null;
//            }
//            catch (Exception ex)
//            {
//                _basicMusaResult = 0; // optional default
//                _basicMusaException = ex;
//            }
//        }

//        [Then(@"the Basic Musa result should be ""(.*)""")]
//        public void ThenTheBasicMusaResultShouldBe(string expected)
//        {
//            if (expected == "Error")
//            {
//                Assert.That(_basicMusaException, Is.Not.Null, "Expected an error but none was thrown.");
//            }
//            else
//            {
//                Assert.That(_basicMusaException, Is.Null, $"Unexpected exception: {_basicMusaException?.Message}");
//                double expectedDouble = double.Parse(expected);
//                Assert.That(Math.Round(_basicMusaResult, 3), Is.EqualTo(Math.Round(expectedDouble, 3)));
//            }
//        }


//        //Question 21 & 22
//        private long _longResult;

//        //1st Feature: UsingCalculatorQualityMetrics.feature
//        [When(@"I have entered (.*) defects and (.*) into the calculator and press DefectDensity")]
//        public void WhenIHaveEnteredDefectsAndKloc(double defects, double kloc)
//        {
//            _result = _calculator.DefectDensity(defects, kloc);
//        }

//        [Then(@"the defect density result should be ""(.*)""")]
//        public void ThenTheDefectDensityResultShouldBe(string expected)
//        {
//            double expectedD = Double.Parse(expected, System.Globalization.CultureInfo.InvariantCulture);
//            Assert.That(_result, Is.EqualTo(expectedD).Within(1e-6));
//        }

//                [When(@"I have entered (.*) previousSSI, (.*) addedSSI and (.*) removedSSI into the calculator and press SSI")]
//                public void WhenIHaveEnteredSSIInputs(long prev, long added, long removed)
//                {
//                    _longResult = _calculator.CalculateSSI(prev, added, removed);
//                }

//                [Then(@"the SSI result should be ""(.*)""")]
//                public void ThenTheSSIResultShouldBe(string expected)
//                {
//                    long expectedL = long.Parse(expected, System.Globalization.CultureInfo.InvariantCulture);
//                    Assert.That(_longResult, Is.EqualTo(expectedL));
//                }



//        //2nd Feature: UsingCalculatorMusaModel
//        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press MusaMu")]
//        public void WhenIHaveEnteredAAndBAndTForMu(double a, double b, double t)
//        {
//            _result = _calculator.MusaMu(a, b, t);
//        }

//        [Then(@"the Musa Mu result should be ""(.*)""")]
//        public void ThenTheMusaMuResultShouldBe(string expected)
//        {
//            double expectedD = Double.Parse(expected, System.Globalization.CultureInfo.InvariantCulture);
//            Assert.That(_result, Is.EqualTo(expectedD).Within(1e-9));
//        }

//        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press MusaLambda")]
//        public void WhenIHaveEnteredAAndBAndTForLambda(double a, double b, double t)
//        {
//            _result = _calculator.MusaLambda(a, b, t);
//        }

//        [Then(@"the Musa Lambda result should be ""(.*)""")]
//        public void ThenTheMusaLambdaResultShouldBe(string expected)
//        {
//            double expectedD = Double.Parse(expected, System.Globalization.CultureInfo.InvariantCulture);
//            Assert.That(_result, Is.EqualTo(expectedD).Within(1e-9));
//        }
//    }
//}
