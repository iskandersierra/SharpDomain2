@Contacts
@Sample
@Commanding
Feature: CreateContactProcessor

Scenario: If a create contact command is processed then a contact created event must be emitted
	Given A create contact command processor
	When The following create contact command is processed
	| Title    |
	| Iskander |
	Then The following contact created event is emitted at position 0
	| Title    |
	| Iskander |
