using System;
using Xunit;

namespace NS2.DbC.Test
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ObjectValidationTest
    {
        public class FakeObject
        {
            public string Name { get; set; }
        }

        public struct  FakeStruct
        {
            public string Name { get; set; }

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
