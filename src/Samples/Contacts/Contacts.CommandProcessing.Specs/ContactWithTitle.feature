@Contacts
@Sample
@Commanding
Feature: ContactWithTitle
	Contact event sourced entity to manage contact state during command to event translation

Scenario: Create a new contact without applying or appending any event
	Given A new contact with title is created
	Then  The the following contact with title is obtained
	| Title  | EntityId                             | Version |
	| <null> | 00000000-0000-0000-0000-000000000000 | 0       |

Scenario: Create a contact by appending a contact created event
	Given A new contact with title is created
	When  A contact created event is appended
	| Title    | EntityId                             |
	| Iskander | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	Then  The the following contact with title is obtained
	| Title    | EntityId                             | Version |
	| Iskander | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1       |

Scenario: Modify a contact title 
	Given A new contact with title is created
	When  A contact created event is appended
	| Title    | EntityId                             |
	| Iskander | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	And  A contact title updated event is appended
	| Title           | EntityId                             |
	| Iskander Sierra | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	Then  The the following contact with title is obtained
	| Title           | EntityId                             | Version |
	| Iskander Sierra | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2       |

Scenario: Modify a contact title twice
	Given A new contact with title is created
	When  A contact created event is appended
	| Title    | EntityId                             |
	| Iskander | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	And  A contact title updated event is appended
	| Title           | EntityId                             |
	| Iskander Sierra | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	And  A contact title updated event is appended
	| Title                    | EntityId                             |
	| Iskander Sierra Zaldivar | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F |
	Then  The the following contact with title is obtained
	| Title                    | EntityId                             | Version |
	| Iskander Sierra Zaldivar | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 3       |
