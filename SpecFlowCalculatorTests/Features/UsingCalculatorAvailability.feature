Feature: UsingCalculatorAvailability
In order to calculate MTBF and Availability 
As someone who struggles with math 
I want to be able to use my calculator to do this 

@Availability
Scenario: Calculating MTBF
Given I have a calculator
When I have entered 200 and 10 into the calculator and press MTBF
Then the availability result should be "210"


#Add-on
@Availability
Scenario: Calculating MTBF with single repair
Given I have a calculator
When I have entered 400 and 0 into the calculator and press MTBF
Then the availability result should be "400"


# Availability scenarios remain unchanged
@Availability
Scenario: Calculating Availability
Given I have a calculator
When I have entered 500 and 50 into the calculator and press Availability
Then the availability result should be "0.909"


#Add-on
@Availability
Scenario: Calculating Availability with larger downtime
Given I have a calculator
When I have entered 120 and 30 into the calculator and press Availability
Then the availability result should be "0.800"
