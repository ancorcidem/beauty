Feature: Search By Parameters
	In order find have a sex for a night
	As a hungry man
	I want to find beauties by different parameters

Scenario: find by age
	Given beauties aging 21, 25, 54, 18
	When search for a beauty between 18 and 24 years old
	Then found girls should be 18, 21

Scenario: find by weight
	Given beauties who weight 45, 50, 55, 60, 65, 70
	When search for beauty who weight between 45 and 60 kg
	Then found girls should weight 45, 50, 55, 60