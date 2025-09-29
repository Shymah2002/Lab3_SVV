Feature: UsingCalculatorFactorial
  In order to compute factorials
  As a calculator user
  I want to compute n! for integers

  @Factorial
  Scenario: Factorial of a positive number
    Given I have a calculator
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

  @Factorial
  Scenario: Factorial of zero
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1

 @Factorial
  Scenario: Factorial of a negative number
    Given I have a calculator
    When I have entered -3 into the calculator and press factorial
    Then the factorial operation should throw an error
