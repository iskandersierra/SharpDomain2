using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SharpDomain.Properties;
using SharpDomain.Utils;

namespace SharpDomain.EventSourcing
{
    public abstract class EventSourced : 
        IEventSourced, 
        IEntityEventSourced, 
        IVersionedEventSourced
    {
        private static readonly IAutoInvoker DefaultInvoker;
        private List<IDomainEvent> _appendedEvents;
        private IReadOnlyCollection<IDomainEvent> _appendedEventsRO;

        static EventSourced()
        {
            DefaultInvoker = new AutoInvoker("Apply", new ConstantAutoInvoker());
        }

        protected EventSourced()
        {
            _appendedEvents = new List<IDomainEvent>();
            _appendedEventsRO = new ReadOnlyCollection<IDomainEvent>(_appendedEvents);
        }

        public IAutoInvoker EventApplier { get; set; }

        public void AppendEvent(IDomainEvent e)
        {
            if (e == null) throw new ArgumentNullException("e");
            AppendEventInternal(e);
        }

        public IReadOnlyCollection<IDomainEvent> AppendedEvents
        {
            get
            {
                return _appendedEventsRO;
            }
        }

        public Guid EntityId { get; private set; }

        public int CommittedVersion { get; private set; }

        public int AppendedVersion { get; private set; }

        void IEventSourced.ApplyCommittedEvent(IDomainEvent e)
        {
            if (e == null) throw new ArgumentNullException("e");
            ApplyCommittedEventInternal(e);
        }

        /// <summary>
        /// This event is comming from an event stream, so it affects the committed version of the entity 
        /// and do not put the event on the appended event collection, however it must invoke the 
        /// corresponding ApplyEvent method to affect entity state
        /// </summary>
        /// <param name="e"></param>
        private void ApplyCommittedEventInternal(IDomainEvent e)
        {
            // committed events must be applied before all appended events
            if (_appendedEvents.Any()) 
                throw new InvalidOperationException(string.Format(Resources.EntityAlreadyHasAppendedEvents, this.GetType().Name));

            var entityRelated = e as IEntityEvent;
            if (entityRelated != null)
            {
                // An entity related event must correspond with current entity Id
                if (CommittedVersion != 0 && entityRelated.EntityId != EntityId)
                    throw new InvalidOperationException(string.Format(Resources.EntityDoNotCorrespondWithEvent,
                        this.GetType().Name, EntityId, e.GetType().Name, entityRelated.EntityId));

                var entityCreation = e as IEntityCreationEvent;
                if (entityCreation != null)
                {
                    // An entity creation event must be applied only at version 0 of the entity
                    if (CommittedVersion != 0)
                        throw new InvalidOperationException(
                            string.Format(Resources.CannotApplyCreationEventToExistingEntity, e.GetType().Name,
                                this.GetType().Name));
                    this.EntityId = entityCreation.EntityId;
                }
                else
                {
                    // An entity modification event must be applied only after the entity has been created
                    if (CommittedVersion == 0)
                        throw new InvalidOperationException(
                            string.Format(Resources.CannotApplyNonCreationEventToNewEntity,
                                this.GetType().Name, e.GetType().Name));
                }
            }

            var versioned = e as IVersionedEvent;
            if (versioned != null)
            {
                if (versioned.EventVersion != CommittedVersion + 1)
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.CannotApplyNonSequentialVersionedEvent,
                            e.GetType().Name, versioned.EventVersion, this.GetType().Name, this.CommittedVersion));
                AppendedVersion = CommittedVersion = CommittedVersion + 1;
            }

            InvokeApplyEvent(e);
        }

        /// <summary>
        /// This event is comming from a command, so it affects the appended version of the entity 
        /// and put the event on the appended event collection. It also must invoke the 
        /// corresponding ApplyEvent method to affect entity state
        /// </summary>
        /// <param name="e"></param>
        private void AppendEventInternal(IDomainEvent e)
        {
            var entityRelated = e as IEntityEvent;
            if (entityRelated != null)
            {
                // An entity related event must correspond with current entity Id
                if (CommittedVersion > 0 && entityRelated.EntityId != EntityId)
                    throw new InvalidOperationException(string.Format(Resources.EntityDoNotCorrespondWithEvent, this.GetType().Name, EntityId, e.GetType().Name, entityRelated.EntityId));

                var entityCreation = e as IEntityCreationEvent;
                if (entityCreation != null)
                {
                    // An entity creation event must be applied only at version 0 of the entity
                    if (AppendedVersion != 0)
                        throw new InvalidOperationException(
                            string.Format(Resources.CannotApplyCreationEventToExistingEntity, e.GetType().Name,
                                this.GetType().Name));
                    EntityId = entityCreation.EntityId;
                }
                else
                {
                    if (AppendedVersion == 0)
                        throw new InvalidOperationException(
                            string.Format(Resources.CannotApplyNonCreationEventToNewEntity,
                                this.GetType().Name, e.GetType().Name));
                    entityRelated.EntityId = EntityId;
                }
            }

            AppendedVersion++;

            var versioned = e as IVersionedEvent;
            if (versioned != null)
            {
                versioned.EventVersion = AppendedVersion;
            }

            InvokeApplyEvent(e);
            _appendedEvents.Add(e);
        }

        private void InvokeApplyEvent(IDomainEvent e)
        {
            (EventApplier ?? DefaultInvoker).Invoke(this, e);
        }
    }
}
