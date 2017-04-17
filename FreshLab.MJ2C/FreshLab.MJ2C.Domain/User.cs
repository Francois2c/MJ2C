using System;

namespace FreshLab.MJ2C.Domain
{
    public class User
    {
        private User()
        { }

        public static User Create() => new User
        {
            Id = Guid.NewGuid()
        };

        public static User Create(Guid id) => new User
        {
            Id = id
        };

        public Guid Id { get; private set; }
    }
}
