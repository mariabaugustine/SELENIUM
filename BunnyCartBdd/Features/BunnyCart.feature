Feature: Search and Add to cart

A short summary of the feature

@E2E-Search_And_AddtoCart
Scenario Outline:Search and add product to cart
	Given User will be on the home page
	When  User will type the '<searchtext>' in the input box
	Then  Search results are loaded in the same page with '<searchtext>'
Examples: 
    | searchtext |
    | water      |
