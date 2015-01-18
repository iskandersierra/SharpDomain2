@Contacts
@Sample
@Commanding
Feature: UpdateContactCodeProcessor

Scenario: If a update contact code command is processed then a contact code updated event must be emitted
	Given A update contact code command processor
	When The following update contact code command is processed
	| Code     |
	| Iskander |
	Then The following contact code updated event is emitted at position 0
	| Code     |
	| Iskander |
