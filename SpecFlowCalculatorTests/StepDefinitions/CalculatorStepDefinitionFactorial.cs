using NUnit.Framework;
using System;

namespace SpecFlowCalculatorTests.StepDefinitions
{

    [Binding, Scope(Tag = "Factorial")]
    public sealed class CalculatorStepDefinitionFactorial
    {
        private readonly Calculator _calculator;   // injected per scenario
        private double _result;

        // Context injection
        public CalculatorStepDefinitionFactorial(Calculator calc)
        {
            _calculator = calc;
        }

        [Given("I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // instance is injected; nothing to do
        }

        //FACTORIAL ---------------------------------------------------
        private long _factorialResult;
        private Exception _factorialException;

        [When("I have entered {int} into the calculator and press factorial")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressFactorial(int number)
        {
            try
            {
                _factorialResult = _calculator.Factorial(number);
                _factorialException = null;
            }
            catch (Exception ex)
            {
                _factorialException = ex;
            }
        }


        [Then("the factorial result should be {int}")]
        public void ThenTheFactorialResultShouldBe(int expected)
        {
            Assert.That(_factorialException, Is.Null, "Expected no exception but got one.");
            Assert.That(_factorialResult, Is.EqualTo(expected));
        }

        [Then("the factorial operation should throw an error")]
        public void ThenTheFactorialOperationShouldThrowAnError()
        {
            Assert.That(_factorialException, Is.Not.Null, "Expected an exception but none was thrown.");
            Assert.That(_factorialException, Is.TypeOf<ArgumentException>(),
                $"Expected ArgumentException but got {_factorialException?.GetType().Name}");
        }


    }
}
