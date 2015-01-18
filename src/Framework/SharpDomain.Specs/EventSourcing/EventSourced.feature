@framework
@eventsourcing
Feature: EventSourced
	Base class for event sourced entities

Scenario: Create a new entity without applying or appending any event
	Given A new entity is created
	Then  The the following entity is obtained
	| FirstName | LastName | EntityId                             | CommittedVersion | AppendedVersion | AppendedEvents |
	| <null>    | <null>   | 00000000-0000-0000-0000-000000000000 | 0                | 0               | 0              |

Scenario: Create an entity by applying an entity created event
	Given A new entity is created
	When The following entity created event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	Then  The the following entity is obtained
	| FirstName | LastName | EntityId                             | CommittedVersion | AppendedVersion | AppendedEvents |
	| Name      | <null>   | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1                | 1               | 0              |

Scenario: Create an entity by appending an entity created event
	Given A new entity is created
	When The following entity created event is appended
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	Then  The the following entity is obtained
	| FirstName | LastName | EntityId                             | CommittedVersion | AppendedVersion | AppendedEvents |
	| Name      | <null>   | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 0                | 1               | 1              |

Scenario: Appending a creation event to an already existing entity is considered an error
	Given A new entity is created
	When The following entity created event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	And The following entity created event is appended
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2            |
	Then an invalid operation exception is raised

Scenario: Appending a non-creation event to a new entity is considered an error
	Given A new entity is created
	When The following entity first name updated event is appended
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	Then an invalid operation exception is raised

Scenario: Appending an event to an already existing entity with non-corresponding entity ids is considered an error
	Given A new entity is created
	When The following entity created event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	And The following entity first name updated event is appended
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 6D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2            |
	Then an invalid operation exception is raised

Scenario: Applying an event to an already modified entity is considered an error
	Given A new entity is created
	When The following entity created event is appended
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	And The following entity first name updated event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2            |
	Then an invalid operation exception is raised

Scenario: Applying an event to an already existing entity with non-corresponding entity ids is considered an error
	Given A new entity is created
	When The following entity created event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	And The following entity first name updated event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 6D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2            |
	Then an invalid operation exception is raised

Scenario: Applying a created event to an already existing entity is considered an error
	Given A new entity is created
	When The following entity created event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name      | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	And The following entity created event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 2            |
	Then an invalid operation exception is raised

Scenario: Applying a non-creation event to a new entity is considered an error
	Given A new entity is created
	When The following entity first name updated event is applied
	| FirstName | EntityId                             | EventVersion |
	| Name2     | 5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F | 1            |
	Then an invalid operation exception is raised
