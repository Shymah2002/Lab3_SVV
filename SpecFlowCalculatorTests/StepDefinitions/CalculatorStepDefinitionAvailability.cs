using NUnit.Framework;
using System;

namespace SpecFlowCalculatorTests.StepDefinitions
{
// Question 17
    [Binding, Scope(Tag = "@Availability")]
    public sealed class CalculatorStepDefinitionAvailability
    {
        private readonly Calculator _calculator;   // injected per scenario
        private double _result;

        // Context injection
        public CalculatorStepDefinitionAvailability(Calculator calc)
        {
            _calculator = calc;
        }

        [Given("I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // instance is injected; nothing to do
        }

        //MTBF ------------------------------------------------------------------------------------------------------
        //For MTBF & Availability
        private double _availabilityResult;
        private Exception _availabilityException;

        [When("I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double mttf, double mttr)
        {
            try
            {
                _availabilityResult = _calculator.MTBF(mttf, mttr);
                _availabilityException = null;
            }
            catch (Exception ex)
            {
                _availabilityException = ex;
                _availabilityResult = double.NaN; // optional placeholder for error
            }
        }

        // AVAILABILITY -------------------------------------------------------------------------------------
        [When("I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double uptime, double downtime)
        {
            try
            {
                _availabilityResult = _calculator.Availability(uptime, downtime);
                _availabilityException = null;
            }
            catch (Exception ex)
            {
                _availabilityException = ex;
            }
        }


        [Then("the availability result should be \"(.*)\"")]
        public void ThenTheAvailabilityResultShouldBe(string expected)
        {
            if (expected == "Error")
            {
                Assert.That(_availabilityException, Is.Not.Null);
            }
            else
            {
                double expectedDouble = double.Parse(expected);
                Assert.That(_availabilityException, Is.Null);
                Assert.That(Math.Round(_availabilityResult, 3), Is.EqualTo(Math.Round(expectedDouble, 3)));
            }
        }

    }
}
