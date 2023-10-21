﻿namespace AppStore.Domain.Primers
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
            => Id = Guid.NewGuid();

        public Guid Id { get; protected init; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not BaseEntity entity)
                return false;

            return entity.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private DateTimeOffset _createdAt;

        public DateTimeOffset CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        private DateTimeOffset? _updatedAt;

        public DateTimeOffset? UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value;
        }

    }
}

