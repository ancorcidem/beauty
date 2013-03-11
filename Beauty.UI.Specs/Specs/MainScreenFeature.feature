Feature: Main Screen
	In order find have a sex for a night
	As a hungry man
	I want to find beauties by different parameters

Scenario: find by age
	Given beauties aging 21, 25, 54, 18
	When search for a beauty between 18 and 24 years old
	Then found girls should be age of 18, 21

Scenario: show new results arrived from feed
	Given beauties aging 21, 25, 54, 18
		And search for a beauty between 18 and 24 years old
	When a new beauty aging 22 added on site
	Then the new beauty aging 22 should be found

Scenario: find by age returns many results
	Given 500 beauties aging from 18 to 40
	When search for a beauty between 18 and 40 years old
	Then all 500 beauties should be found
