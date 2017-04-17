using System;
using System.Collections.Generic;
using FreshLab.MJ2C.Domain;
using FreshLab.MJ2C.Services.Contracts.Repositories;

namespace FreshLab.MJ2C.UserRepository
{
    public class InMemoryUserRepository : IRepository<User>
    {
        public InMemoryUserRepository()
        {
            // For test purposes
            var user = User.Create(new Guid("07B8018B-8278-41DF-B998-2BAE46143CD0"));

            Users = new Dictionary<Guid, User>()
            {
                { user.Id, user }
            };
        }

        public IDictionary<Guid, User> Users { get; }

        public User GetById(Guid id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return Users.ContainsKey(id) ? Users[id] : null;
        }

        public void Update(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            Users[user.Id] = user;
        }

        public void Save(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            Users.Add(user.Id, user);
        }
    }
}
