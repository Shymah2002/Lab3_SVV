Feature: UsingCalculatorBasicReliability 
  In order to calculate the Basic Musa model's failures/intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  #Question 18a
  #Current Failure Intensity (mcf)
  @BasicReliability
  Scenario: Calculating current failure intensity
    Given I have a calculator
    When I have entered 10, 100, and 0.5 into the calculator and press current failure intensity
    Then the Basic Musa result should be "9.512" 

  @BasicReliability
  Scenario: Negative initial intensity
    Given I have a calculator
    When I have entered -5, 100, and 10 into the calculator and press current failure intensity
    Then the Basic Musa result should be "Error"

  @BasicReliability
  Scenario: Small time value
    Given I have a calculator
    When I have entered 10, 100, and 0.001 into the calculator and press current failure intensity
    Then the Basic Musa result should be "9.999"


#Qns 18b
 #Average Failure
  @BasicReliability
  Scenario: Calculating average number of expected failures
    Given I have a calculator
    When I have entered 10, 100, and 5 into the calculator and press average failures
    Then the Basic Musa result should be "39.347"


 #Lab2.1 --------------------------------------------