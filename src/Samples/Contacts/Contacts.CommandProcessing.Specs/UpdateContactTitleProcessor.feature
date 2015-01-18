@Contacts
@Sample
@Commanding
Feature: UpdateContactTitleProcessor

Scenario: If a update contact title command is processed then a contact title updated event must be emitted
	Given A update contact title command processor
	When The following update contact title command is processed
	| Title    |
	| Iskander |
	Then The following contact title updated event is emitted at position 0
	| Title    |
	| Iskander |
