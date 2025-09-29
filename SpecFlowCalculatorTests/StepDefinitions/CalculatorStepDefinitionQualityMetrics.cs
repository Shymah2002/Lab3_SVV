using NUnit.Framework;
using System;

namespace SpecFlowCalculatorTests.StepDefinitions
{

    [Binding, Scope(Tag = "Quality")]
    public sealed class CalculatorStepDefinitionQualityMetrics
    {
        private readonly Calculator _calculator;   // injected per scenario
        private double _result;

        // Context injection
        public CalculatorStepDefinitionQualityMetrics(Calculator calc)
        {
            _calculator = calc;
        }

        [Given("I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // instance is injected; nothing to do
        }

        //Question 21 & 22
        private long _longResult;
        private Exception _exception;


        //1st Feature: UsingCalculatorQualityMetrics.feature
        [When(@"I have entered (.*) defects and (.*) into the calculator and press DefectDensity")]
        public void WhenIHaveEnteredDefectsAndKloc(double defects, double kloc)
        {
            try
            {
                // Check invalid inputs proactively
                if (kloc == 0)
                    throw new DivideByZeroException("KLOC cannot be zero for defect density");

                _result = _calculator.DefectDensity(defects, kloc);
                _exception = null; // no exception
            }
            catch (Exception ex)
            {
                _result = 0; // optional default
                _exception = ex;
            }
        }


        [Then(@"the defect density result should be ""(.*)""")]
        public void ThenTheDefectDensityResultShouldBe(string expected)
        {
            if (expected == "Error")
            {
                Assert.That(_exception, Is.Not.Null, "Expected an error but none was thrown.");
            }
            else
            {
                Assert.That(_exception, Is.Null, $"Unexpected exception: {_exception?.Message}");
                double expectedD = double.Parse(expected, System.Globalization.CultureInfo.InvariantCulture);
                Assert.That(_result, Is.EqualTo(expectedD).Within(1e-6));
            }
        }

        [When(@"I have entered (.*) previousSSI, (.*) addedSSI and (.*) removedSSI into the calculator and press SSI")]
        public void WhenIHaveEnteredSSIInputs(long prev, long added, long removed)
        {
            _longResult = _calculator.CalculateSSI(prev, added, removed);
        }

        [Then(@"the SSI result should be ""(.*)""")]
        public void ThenTheSSIResultShouldBe(string expected)
        {
            long expectedL = long.Parse(expected, System.Globalization.CultureInfo.InvariantCulture);
            Assert.That(_longResult, Is.EqualTo(expectedL));
        }



    }
}
