using NUnit.Framework;
using System;

namespace SpecFlowCalculatorTests.StepDefinitions
{

    [Binding, Scope(Tag = "BasicReliability")]
    public sealed class CalculatorStepDefinitionBasicReliability
    {
        private readonly Calculator _calculator;   // injected per scenario
        private double _result;

        // Context injection
        public CalculatorStepDefinitionBasicReliability(Calculator calc)
        {
            _calculator = calc;
        }

        [Given("I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // instance is injected; nothing to do
        }

        //Basic Availability
        //BASIC MUSA -------------------------------------------------------------------------------------------------------------------------
        //Qns 18a
        private double _basicMusaResult;
        private Exception _basicMusaException;

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press current failure intensity")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressCurrentFailureIntensity(double lambda0, double N0, double tau)
        {
            try
            {
                // Handle negative or invalid inputs
                if (lambda0 < 0 || N0 <= 0 || tau < 0)
                    throw new ArgumentException("Invalid input");

                _basicMusaResult = _calculator.CurrentFailureIntensity(lambda0, N0, tau);
                _basicMusaException = null;
            }
            catch (Exception ex)
            {
                _basicMusaResult = 0; // optional default
                _basicMusaException = ex;
            }
        }


        //Qns 18b
        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press average failures")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressAverageFailures(double lambda0, double N0, double tau)
        {
            try
            {
                // Handle negative or invalid inputs
                if (lambda0 < 0 || N0 <= 0 || tau < 0)
                    throw new ArgumentException("Invalid input");

                _basicMusaResult = _calculator.AverageFailures(lambda0, N0, tau);
                _basicMusaException = null;
            }
            catch (Exception ex)
            {
                _basicMusaResult = 0; // optional default
                _basicMusaException = ex;
            }
        }

        [Then(@"the Basic Musa result should be ""(.*)""")]
        public void ThenTheBasicMusaResultShouldBe(string expected)
        {
            if (expected == "Error")
            {
                Assert.That(_basicMusaException, Is.Not.Null, "Expected an error but none was thrown.");
            }
            else
            {
                Assert.That(_basicMusaException, Is.Null, $"Unexpected exception: {_basicMusaException?.Message}");
                double expectedDouble = double.Parse(expected);
                Assert.That(Math.Round(_basicMusaResult, 3), Is.EqualTo(Math.Round(expectedDouble, 3)));
            }
        }


    }
}
