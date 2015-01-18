@Contacts
@Sample
@Commanding
Feature: ContactWithCode
	Contact event sourced entity to manage contact state during command to event translation

Scenario: Create a new contact without applying or appending any event
	Given A new contact with title is created
	Then  The the following contact with title is obtained
	| Code   | EntityId                             | Version |
	| <null> | 00000000-0000-0000-0000-000000000000 | 0       |

Scenario: Create a contact by appending a contact created event
	Given A new contact with title is created
	When  A contact created event is appended
	| Code   | EntityId                             |
	| <null> | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	Then  The the following contact with title is obtained
	| Code   | EntityId                             | Version |
	| <null> | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1       |

Scenario: Modify a contact code 
	Given A new contact with code is created
	When  A contact created event is appended
	| Title    | EntityId                             |
	| Iskander | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	And  A contact code updated event is appended
	| Code    | EntityId                             |
	| ISK0123 | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	Then  The the following contact with code is obtained
	| Code    | EntityId                             | Version |
	| ISK0123 | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2       |
