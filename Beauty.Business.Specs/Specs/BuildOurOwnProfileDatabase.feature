Feature: beauties will be kept locally
	In order to not to be fooled by changed profile
	As a man
	I want to see beauty change history

Scenario: update beauty previously found
	Given beauty already found and stored locally:
		| id | url                         | name  | age |
		| 1  | http://intimby.net/profile1 | Anita | 19  |
		And beauty on site:
		| url                         | name   | age |
		| http://intimby.net/profile1 | Marina | 28  |
	When search for a beauty between 18 and 28 years old
	Then beauty with id = 1 will have names: Anita, Marina
		And beauty with id = 1 will have two ages: 19, 28
