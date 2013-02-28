Feature: Find New Beauties Online
	In order to find more beauties than we already have
	As a man
	I want to be told query the site for new beauties

@online
Scenario: find new beauties by age
	Given some beauties who present on site only with age 18, 19, 23, 45
	When search for a beauty between 18 and 24 years old
	Then found girls should be age of 18, 19, 23

@online
Scenario: find new beauties by weight
	Given some beauties who present on site only with weight 47, 105
	When search for beauty who weight between 45 and 60 kg
	Then girls found on site should have weight 47