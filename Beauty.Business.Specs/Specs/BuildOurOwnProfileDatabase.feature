Feature: beauties will be kept locally
	In order to not to be fooled by changed profile
	As a man
	I want to see beauty change history

@ignore
Scenario: update beauty previously found when matched by profile url
	Given beauty already found:
		| id | url                         | name  | age | create date |
		| 1  | http://intimby.net/profile1 | Anita | 19  | 10.09.2012  |
		And beauty on site:
		| url                         | name   | age |
		| http://intimby.net/profile1 | Marina | 28  |
	When search for a beauty between 18 and 28 years old on 11.09.2012
	Then beauty with id = 1 will have name change history: 
		| name   | date       |
		| Anita  | 10.09.2012 |
		| Marina | 11.09.2012 |
		And beauty with id = 1 will have age change history:
		| age | date       |
		| 19  | 10.09.2012 |
		| 28  | 11.09.2012 |
