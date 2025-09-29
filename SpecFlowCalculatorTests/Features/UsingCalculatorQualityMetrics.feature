Feature: UsingCalculatorQualityMetrics
  In order to evaluate software quality
  As a system quality engineer
  I want to calculate defect density and the new SSI for successive releases
  #Qns 19^^^


  #Qns 21
  @Quality @DefectDensity
  Scenario: Calculating defect density
  Given I have a calculator
  When I have entered 30 defects and 10 into the calculator and press DefectDensity
  Then the defect density result should be "3.0"

  #Added for edge case (more acceptance)
  @Quality @DefectDensity
  Scenario: Calculating defect density with zero defects
  Given I have a calculator
  When I have entered 0 defects and 10 into the calculator and press DefectDensity
  Then the defect density result should be "0.0"

  @Quality @DefectDensity
  Scenario: Calculating defect density with zero KLOC (invalid input)
  Given I have a calculator
  When I have entered 10 defects and 0 into the calculator and press DefectDensity
  Then the defect density result should be "Error"






  @Quality @SSI
  Scenario: Calculating new SSI for release 2
    Given I have a calculator
    When I have entered 100000 previousSSI, 5000 addedSSI and 1000 removedSSI into the calculator and press SSI
    Then the SSI result should be "104000"

 #Added for edge case (more acceptance)
 @Quality @SSI
 Scenario: Calculating new SSI with removed SSI greater than added SSI
 Given I have a calculator
 When I have entered 50000 previousSSI, 1000 addedSSI and 2000 removedSSI into the calculator and press SSI
 Then the SSI result should be "49000"

  @Quality @SSI
  Scenario: Calculating new SSI with zero previous SSI
  Given I have a calculator
  When I have entered 0 previousSSI, 2000 addedSSI and 500 removedSSI into the calculator and press SSI
  Then the SSI result should be "1500"