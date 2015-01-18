using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Contacts.Commands;
using Contacts.Events;
using NUnit.Framework;
using SharpDomain.EventSourcing;
using SharpDomain.SpecsUtils;
using SharpDomain.SpecsUtils.EventSourcing;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Contacts.CommandProcessing
{
    [Binding]
    public class ContactSteps : CommonSteps
    {
        #region [ Given / When ]

        [Given(@"A new contact with title is created")]
        public void GivenANewContactWithTitleIsCreated()
        {
            GivenEntity<UpdateContactTitleProcessor.ContactWithTitle>();
        }
        [Given(@"A new contact with code is created")]
        public void GivenANewContactWithCodeIsCreated()
        {
            GivenEntity<UpdateContactCodeProcessor.ContactWithCode>();
        }
        [Given(@"A create contact command processor")]
        public void GivenACreateContactCommandProcessor()
        {
            GivenCommandProcessor<CreateContactProcessor>();
        }
        [Given(@"A update contact title command processor")]
        public void GivenAUpdateContactTitleCommandProcessor()
        {
            GivenCommandProcessor<UpdateContactTitleProcessor>(processor =>
            {
                processor.Contact = new UpdateContactTitleProcessor.ContactWithTitle();
            });
        }
        [Given(@"A update contact code command processor")]
        public void GivenAUpdateContactCodeCommandProcessor()
        {
            GivenCommandProcessor<UpdateContactCodeProcessor>(processor =>
            {
                processor.Contact = new UpdateContactCodeProcessor.ContactWithCode();
            });
        }

        [When(@"A contact created event is appended")]
        public void GivenAContactCreatedEventIsAppended(Table table)
        {
            WhenAppendEvent<ContactCreated>(table);
        }
        [When(@"A contact title updated event is appended")]
        public void WhenAContactTitleUpdatedEventIsAppended(Table table)
        {
            WhenAppendEvent<ContactTitleUpdated>(table);
        }
        [When(@"A contact code updated event is appended")]
        public void WhenAContactCodeUpdatedEventIsAppended(Table table)
        {
            WhenAppendEvent<ContactCodeUpdated>(table);
        }
        [When(@"The following create contact command is processed")]
        public void WhenTheFollowingCreateContactCommandIsProcessed(Table table)
        {
            WhenCommandProcessed<CreateContactProcessor, CreateContact>(table);
        }
        [When(@"The following update contact title command is processed")]
        public void WhenTheFollowingUpdateContactTitleCommandIsProcessed(Table table)
        {
            WhenCommandProcessed<UpdateContactTitleProcessor, UpdateContactTitle>(table);
        }
        [When(@"The following update contact code command is processed")]
        public void WhenTheFollowingUpdateContactCodeCommandIsProcessed(Table table)
        {
            WhenCommandProcessed<UpdateContactCodeProcessor, UpdateContactCode>(table);
        }
        #endregion

        #region [ Then / Asserts ]

        [Then(@"The the following contact with title is obtained")]
        public void ThenTheTheFollowingContactWithTitleIsObtained(Table table)
        {
            AssertIsExpected<UpdateContactTitleProcessor.ContactWithTitle, ContactWithTitleData>(table,
                (contact, expected) =>
                {
                    Assert.That(OrNull(contact.Title), Is.EqualTo(OrNull(expected.Title)));
                    Assert.That(contact.EntityId, Is.EqualTo(expected.EntityId));
                    Assert.That(contact.AppendedVersion, Is.EqualTo(expected.Version));
                });
        }
        [Then(@"The the following contact with code is obtained")]
        public void ThenTheTheFollowingContactWithCodeIsObtained(Table table)
        {
            AssertIsExpected<UpdateContactCodeProcessor.ContactWithCode, ContactWithCodeData>(table,
                (contact, expected) =>
                {
                    Assert.That(OrNull(contact.Code), Is.EqualTo(OrNull(expected.Code)));
                    Assert.That(contact.EntityId, Is.EqualTo(expected.EntityId));
                    Assert.That(contact.AppendedVersion, Is.EqualTo(expected.Version));
                });
        }
        [Then(@"The following contact created event is emitted at position (.*)")]
        public void ThenTheFollowingContactCreatedEventIsEmittedAtPosition(int position, Table table)
        {
            AssertIsEmitted<ContactCreated>(position, table,
                (ev, expected) => Assert.That(ev.Title, Is.EqualTo(expected.Title)));
        }
        [Then(@"The following contact title updated event is emitted at position (.*)")]
        public void ThenTheFollowingContactTitleUpdatedEventIsEmittedAtPosition(int position, Table table)
        {
            AssertIsEmitted<ContactTitleUpdated>(position, table,
                (ev, expected) => Assert.That(ev.Title, Is.EqualTo(expected.Title)));
        }
        [Then(@"The following contact code updated event is emitted at position (.*)")]
        public void ThenTheFollowingContactCodeUpdatedEventIsEmittedAtPosition(int position, Table table)
        {
            AssertIsEmitted<ContactCodeUpdated>(position, table,
                (ev, expected) => Assert.That(ev.Code, Is.EqualTo(expected.Code)));
            
        }
        #endregion

        #region [ Classes & Utils ]

        public class ContactWithTitleData
        {
            public Guid EntityId { get; set; }
            public int Version { get; set; }
            public string Title { get; set; }
        }
        public class ContactWithCodeData
        {
            public Guid EntityId { get; set; }
            public int Version { get; set; }
            public string Code { get; set; }
        }
        #endregion [ Classes ]
    }
}
