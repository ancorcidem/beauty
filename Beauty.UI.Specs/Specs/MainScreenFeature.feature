Feature: Main Screen
	In order find have a sex for a night
	As a hungry man
	I want to find beauties by different parameters

Scenario: find by age
	Given beauties aging 21, 25, 54, 18
	When search for a beauty between 18 and 24 years old
	Then found girls should be age of 18, 21