Feature: GeneratorFeature
	Generator for NHS numbers


Scenario: Generate a Single NHS Number
    Given A single NHS Number
    Then NHS Number should be valid
 
 Scenario: Generate 100 NHS Numbers
    Given 100 NHS Number(s)
    Then NHS Numbers should be valid
    
Scenario: Generate two different NHS Numbers
    Given Two different NHS Numbers are generated
    Then NHS Numbers should be valid
    And NHS Numbers should be different