using System;
using Xunit;

namespace NS2.Verify.Test.ObjectValidationTest
{
    public class NotDefault
    {
        [Fact]
        public void _With_Default_Object_Expect_ArgumentException()
        {
            ////Arrange
            FakeObject fakeObject = default(FakeObject);

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
                Ensure.That(nameof(fakeObject), fakeObject).NotDefault());
        }


        [Fact]
        public void _With_Valid_Guid_Expect_Success()
        {
            ////Arrange
            Guid guid = Guid.NewGuid();

            ////Act
            Ensure.That(nameof(guid), guid).NotDefault();
        }

        [Fact]
        public void _With_Empty_Guid_Expect_ArgumentException()
        {
            ////Arrange
            Guid guid = Guid.Empty;

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
                Ensure.That(nameof(guid), guid).NotDefault());
        }

        [Fact]
        public void _With_Null_Expect_ArgumentException()
        {
            ////Arrange
            FakeObject fakeObject = null;

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
                Ensure.That(nameof(fakeObject), fakeObject).NotDefault());
        }

        [Fact]
        public void _With_Valid_Object_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Ensure.That(nameof(fakeObject), fakeObject).NotDefault();
        }

    }

    public class IsOfType
    {

        [Fact]
        public void _With_Correct_Type_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Ensure.That(nameof(fakeObject), fakeObject).IsOfType(fakeObject.GetType());
        }

        [Fact]
        public void _With_Wrong__Type_Expect_ArgumentException()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
                Ensure.That(nameof(fakeObject), fakeObject).IsOfType(GetType()));
        }
    }

    public class Must
    {

        [Fact]
        public void _With_A_Predicate_That_Will_Validate_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Ensure.That(nameof(fakeObject), fakeObject).Must(x => x.Name == "john Doe");

        }

        [Fact]
        public void _With_One_Valid_Value_And_One_That_Are_Not_Valid_Expect_ArgumentException()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
                Ensure.That(nameof(fakeObject), fakeObject).Must(x => x.Name == "john Doe" && x.Name2 != null));

        }

        [Fact]
        public void _With_Two_Valid_Properties_Expect_Sucess()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe", Name2 = "john Doe2" };

            ////Act
            Ensure.That(nameof(fakeObject), fakeObject).Must(x => x.Name == "john Doe" && x.Name2 == "john Doe2");

        }


        [Fact]
        public void _With_A_Predicate_That_Will_Not_Be_Valid_Expect_Failur()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act & Test
            Assert.Throws<ArgumentException>(() =>
                Ensure.That(nameof(fakeObject), fakeObject).Must(x => x.Name == "Some other"));

        }
    }
    public class NotNull
    {

        [Fact]
        public void _With_An_Object_Expect_Success()
        {
            ////Arrange
            var fakeObject = new FakeObject { Name = "john Doe" };

            ////Act
            Ensure.That(nameof(fakeObject), fakeObject).NotNull();

        }


        [Fact]
        public void _With_An_Null_Object_Expect_ArgumentNullException()
        {
            ////Arrange
            FakeObject fakeObject = null;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Ensure.That(nameof(fakeObject), fakeObject).NotNull());

        }

        [Fact]
        public void _With_An_Null_Object_Expect_That_NotNull_Does_Not_Thorw_Any_Other_Excpetion_Than_ArgumentNullException()
        {
            ////Arrange
            FakeObject fakeObject = null;
            Exception someException = null;

            ////Act
            try
            {
                Ensure.That(nameof(fakeObject), fakeObject).NotNull();
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
