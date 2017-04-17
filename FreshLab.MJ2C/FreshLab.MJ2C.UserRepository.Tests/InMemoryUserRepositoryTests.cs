using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using FreshLab.MJ2C.Domain;

namespace FreshLab.MJ2C.UserRepository.Tests
{
    [TestClass]
    public class InMemoryUserRepositoryTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void GivenUserDoesNotExist_WhenGetById_ThenNullIsReturned()
        {
            // Arrange
            var id = Guid.NewGuid();

            var sut = MakeSut();

            // Act
            var user = sut.GetById(id);

            // Assert
            user.Should().BeNull();
        }

        [TestMethod]
        public void GivenUserExists_WhenGetById_ThenUserIsReturned()
        {
            // Arrange
            var id = new Guid("07B8018B-8278-41DF-B998-2BAE46143CD0");

            var sut = MakeSut();

            // Act
            var user = sut.GetById(id);
            
            // Assert
            user.Should().NotBeNull();
            user.Id.Should().Be(id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenUserIsNull_WhenSave_ThenThrowsArgumentNullException()
        {
            // Arrange
            var sut = MakeSut();

            // Act
            sut.Save(null);
        }

        [TestMethod]
        public void GivenUserIsValid_WhenSave_ThenUserIsSaved()
        {
            // Arrange
            var user = User.Create();

            var sut = MakeSut();

            // Act
            sut.Save(user);

            // Assert
            sut.Should().NotBeNull();
            sut.Users.Count.Should().BeGreaterThan(0);
            sut.Users[user.Id].Id.Should().Be(user.Id);
        }

        private InMemoryUserRepository MakeSut() => new InMemoryUserRepository();
    }
}
