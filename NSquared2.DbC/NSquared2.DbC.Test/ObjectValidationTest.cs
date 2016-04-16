using System;
using Xunit;

namespace NS2.DbC.Test
{
    public class ObjectValidationTest
    {
        public class FakeObject
        {
            public string Name { get; set; }
        }

        [Fact]
        public void When_Call_NotDefault_With_Default_Object_Expect_ArgumentException()
        {
            ////Arrange
            FakeObject fakeObject = default(FakeObject);

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
            Contract.Require(nameof(fakeObject), fakeObject).NotDefault());
        }


        [Fact]
        public void When_Call_NotDefault_With_Valid_Guid_Expect_Success()
        {
            ////Arrange
            Guid guid = Guid.NewGuid();

            ////Act
            Contract.Require(nameof(guid), guid).NotDefault();
        }

        [Fact]
        public void When_Call_NotDefault_With_Empty_Guid_Expect_ArgumentException()
        {
            ////Arrange
            Guid guid = Guid.Empty;

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
            Contract.Require(nameof(guid), guid).NotDefault());
        }

        [Fact]
        public void When_Call_NotDefault_With_Null_Expect_ArgumentException()
        {
            ////Arrange
            FakeObject fakeObject = null;

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
            Contract.Require(nameof(fakeObject), fakeObject).NotDefault());
        }

        [Fact]
        public void When_Call_NotDefault_With_Valid_Object_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Contract.Require(nameof(fakeObject), fakeObject).NotDefault();
        }


        [Fact]
        public void When_Call_IsOfType_With_Correct_Type_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Contract.Require(nameof(fakeObject), fakeObject).IsOfType(fakeObject.GetType());
        }

        [Fact]
        public void When_Call_IsOfType_With_Wrong__Type_Expect_ArgumentException()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act & Test
            Assert.Throws<ArgumentException>( () =>
            Contract.Require(nameof(fakeObject), fakeObject).IsOfType(GetType()));
        }

        [Fact]
        public void When_Call_Must_With_A_Predicate_That_Will_Validate_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject {Name = "john Doe"};

            ////Act
            Contract.Require(nameof(fakeObject), fakeObject).Must(x => x.Name == "john Doe");

        }

        [Fact]
        public void When_Call_Must_With_A_Predicate_That_Will_Not_Be_Valid_Expect_Failur()
        {
            ////Arrange
            var fakeObject = new FakeObject {Name = "john Doe"};

            ////Act & Test
            Assert.Throws<ArgumentException>( () => 
            Contract.Require(nameof(fakeObject), fakeObject).Must(x => x.Name == "Some other"));

        }

        [Fact]
        public void When_Call_NotNull_With_An_Object_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Contract.Require(nameof(fakeObject), fakeObject).NotNull();

        }

        
        [Fact]
        public void When_Call_NotNull_With_An_Null_Object_Expect_ArgumentNullException()
        {
            ////Arrange
            FakeObject fakeObject = null;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() => 
            Contract.Require(nameof(fakeObject), fakeObject).NotNull());

        }

        [Fact]
        public void When_Call_NotNull_With_An_Null_Object_Expect_That_NotNull_Does_Not_Thorw_Any_Other_Excpetion_Than_ArgumentNullException()
        {
            ////Arrange
            FakeObject fakeObject = null;
            Exception someException = null;

            ////Act
            try
            {
                Contract.Require(nameof(fakeObject), fakeObject).NotNull();
            }
            catch (Exception ex)
            {
                someException = ex;
            }
            
            ////Test
            Assert.IsNotType<ArgumentException>(someException);
        }
    }
}
