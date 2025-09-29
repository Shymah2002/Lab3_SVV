using NUnit.Framework;
using System;

namespace SpecFlowCalculatorTests.StepDefinitions
{

    [Binding, Scope(Tag = "Divisions")]
    public sealed class CalculatorStepDefinitionDivision
    {
        private readonly Calculator _calculator;   // injected per scenario
        private double _result;

        // Context injection
        public CalculatorStepDefinitionDivision(Calculator calc)
        {
            _calculator = calc;
        }

        [Given("I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // instance is injected; nothing to do
        }

        //WHEN — division(handles all numeric inputs)
        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double num1, double num2)
        {
            _result = _calculator.Divide(num1, num2);
        }

        // THEN — normal results
        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }

        // THEN — positive infinity
        [Then("the division result equals positive_infinity")]
        public void ThenTheDivisionResultShouldBePositiveInfinity()
        {
            Assert.That(_result, Is.EqualTo(double.PositiveInfinity));
        }

    }
}
