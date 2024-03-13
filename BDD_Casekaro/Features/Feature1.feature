Feature:Selecting and adding mobile cover to addto cart

A short summary of the feature
Background: User will be on the homepage
@E2E_AddToCart
Scenario Outline:Add mobile cover to addto cart
	When User click on search button
	And  User Type'<searchText>' and press enter
	Then SearcList page is loaded with url contains '<searchText>'
Examples: 
	| searchText |
	| apple      |

