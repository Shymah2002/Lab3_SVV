using NUnit.Framework;
using System;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding, Scope(Tag = "Musa")]
    public sealed class CalculatorStepDefinitionMusaModel
    {
        private readonly Calculator _calculator;
        private double _result;

        public CalculatorStepDefinitionMusaModel(Calculator calc)
        {
            _calculator = calc;
        }

        [Given("I have a calculator")]
        public void GivenIHaveACalculator() { }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press MusaMu")]
        public void WhenIHaveEnteredAAndBAndTForMu(double a, double b, double t)
        {
            try { _result = _calculator.MusaMu(a, b, t); }
            catch { _result = double.NaN; } // mark invalid input
        }

        [Then(@"the Musa Mu result should be ""(.*)""")]
        public void ThenTheMusaMuResultShouldBe(string expected)
        {
            if (expected == "Error") Assert.IsTrue(double.IsNaN(_result));
            else Assert.That(_result, Is.EqualTo(Double.Parse(expected, System.Globalization.CultureInfo.InvariantCulture)).Within(1e-9));
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press MusaLambda")]
        public void WhenIHaveEnteredAAndBAndTForLambda(double a, double b, double t)
        {
            try { _result = _calculator.MusaLambda(a, b, t); }
            catch { _result = double.NaN; }
        }

        [Then(@"the Musa Lambda result should be ""(.*)""")]
        public void ThenTheMusaLambdaResultShouldBe(string expected)
        {
            if (expected == "Error") Assert.IsTrue(double.IsNaN(_result));
            else Assert.That(_result, Is.EqualTo(Double.Parse(expected, System.Globalization.CultureInfo.InvariantCulture)).Within(1e-9));
        }
    }
}
