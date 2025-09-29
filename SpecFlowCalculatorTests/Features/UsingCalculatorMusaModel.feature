Feature: UsingCalculatorMusaModel
  In order to estimate reliability using Musa model
  As a Software Quality Metric enthusiast
  I want to compute the Musa expected failures (mu) and failure intensity (lambda)

  @Musa @Mu
  Scenario: Calculating Musa expected failures mu(t)
    Given I have a calculator
    When I have entered 50 and 0.01 and 100 into the calculator and press MusaMu
    Then the Musa Mu result should be "34.65735902799727"

  @Musa @Mu
  Scenario: Calculating Musa expected failures with time = 0
    Given I have a calculator
    When I have entered 50 and 0.01 and 0 into the calculator and press MusaMu
    Then the Musa Mu result should be "0.0"

  @Musa @Mu
  Scenario: Calculating Musa expected failures with negative total failures (invalid input)
    Given I have a calculator
    When I have entered 50 and -10 and 100 into the calculator and press MusaMu
    Then the Musa Mu result should be "Error"

  @Musa @Lambda
  Scenario: Calculating Musa failure intensity lambda(t)
    Given I have a calculator
    When I have entered 50 and 0.01 and 100 into the calculator and press MusaLambda
    Then the Musa Lambda result should be "0.25"

  @Musa @Lambda
  Scenario: Calculating Musa failure intensity with negative initial intensity
    Given I have a calculator
    When I have entered -5 and 0.01 and 100 into the calculator and press MusaLambda
    Then the Musa Lambda result should be "Error"

  @Musa @Lambda
  Scenario: Calculating Musa failure intensity with very small time
    Given I have a calculator
    When I have entered 50 and 0.01 and 0.001 into the calculator and press MusaLambda
    Then the Musa Lambda result should be "0.499995"
