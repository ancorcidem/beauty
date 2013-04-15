Feature: beauties will be kept locally
	In order to not to be fooled by changed profile
	As a man
	I want to see beauty change history


Scenario: add beauty only once
	Given beauty already found:
		| url                         | name  | age |
		| http://intimby.net/profile1 | Anita | 19  |
		And beauty on site:
		| url                         | name   | age |
		| http://intimby.net/profile1 | Anita | 19  |
	When search for a beauty between 19 and 19 years old
	Then found girls should be:
		| url                         | name  | age |
		| http://intimby.net/profile1 | Anita | 19  |

@ignore
Scenario: update beauty previously found when matched by profile url
	Given beauty already found:
		| id | url                         | name  | age |
		| 1  | http://intimby.net/profile1 | Anita | 19  |
		And beauty on site:
		| url                         | name   | age |
		| http://intimby.net/profile1 | Marina | 28  |
	When search for a beauty between 18 and 28 years old
	Then beauty with id = 1 will have name change history: 
		| name   |
		| Anita  |
		| Marina |
		And beauty with id = 1 will have age change history:
		| age | name   |
		| 19  | Anita  | 
		| 28  | Marina |
