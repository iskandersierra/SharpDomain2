using System;
using NUnit.Framework;
using SharpDomain.SpecsUtils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SharpDomain.EventSourcing
{
    [Binding]
    public class EventSourcedSteps : CommonSteps
    {

        #region [ Given / When ]

        [Given(@"A new entity is created")]
        public void GivenANewEntityIsCreated()
        {
            GivenEntity<SampleEntity>();
        }

        [When(@"The event is appended to the entity")]
        public void WhenTheEventIsAppendedToTheEntity()
        {
            var entity = Get<EventSourced>();
            var e = Get<IDomainEvent>();

            entity.AppendEvent(e);
        }

        [When(@"The event is applied to the entity")]
        public void WhenTheEventIsAppliedToTheEntity()
        {
            var entity = Get<EventSourced>();
            var e = Get<IDomainEvent>();
            ((IEventSourced) entity).ApplyCommittedEvent(e);
        }

        [When(@"The following entity created event is applied")]
        public void WhenTheFollowingEntityCreatedEventIsApplied(Table table)
        {
            ApplyEvent<EntityCreated>(table);
        }

        [When(@"The following entity created event is appended")]
        public void WhenTheFollowingEntityCreatedEventIsAppended(Table table)
        {
            WhenAppendEvent<EntityCreated>(table);
        }

        [When(@"The following entity first name updated event is appended")]
        public void WhenTheFollowingEntityFirstNameUpdatedEventIsAppended(Table table)
        {
            WhenAppendEvent<EntityFirstNameUpdated>(table);
        }

        [When(@"The following entity first name updated event is applied")]
        public void WhenTheFollowingEntityFirstNameUpdatedEventIsApplied(Table table)
        {
            ApplyEvent<EntityFirstNameUpdated>(table);
        }

        #endregion

        #region [ Then / Asserts ]

        [Then(@"The the following entity is obtained")]
        public void ThenTheTheFollowingEntityIsObtained(Table table)
        {
            AssertIsExpected<SampleEntity, SampleEntityData>(table,
                (entity, expected) =>
                {
                    Assert.That(entity.CommittedVersion, Is.EqualTo(expected.CommittedVersion));
                    Assert.That(entity.AppendedVersion, Is.EqualTo(expected.AppendedVersion));
                    Assert.That(entity.AppendedEvents.Count, Is.EqualTo(expected.AppendedEvents));
                    Assert.That(entity.EntityId, Is.EqualTo(expected.EntityId));
                    Assert.That(OrNull(entity.FirstName), Is.EqualTo(OrNull(expected.FirstName)));
                    Assert.That(OrNull(entity.LastName), Is.EqualTo(OrNull(expected.LastName)));
                });
        }

        #endregion

        #region [ Classes / Utils ]

        public class EntityCreated : EntityCreationEvent
        {
            public string FirstName { get; set; }
        }

        public class EntityFirstNameUpdated : EntityEvent
        {
            public string FirstName { get; set; }
        }

        public class EntityLastNameUpdated : EntityEvent
        {
            public string LastName { get; set; }
        }

        public class SampleEntity : EventSourced
        {
            public string FirstName { get; private set; }
            public string LastName { get; private set; }

            private void Apply(EntityCreated e)
            {
                FirstName = e.FirstName;
            }

            private bool Apply(EntityFirstNameUpdated e)
            {
                FirstName = e.FirstName;
                return true;
            }

            private bool Apply(EntityLastNameUpdated e)
            {
                LastName = e.LastName;
                return true;
            }
        }

        public class SampleEntityData
        {
            public Guid EntityId { get; private set; }
            public int CommittedVersion { get; private set; }
            public int AppendedVersion { get; private set; }
            public int AppendedEvents { get; private set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        #endregion
    }
}