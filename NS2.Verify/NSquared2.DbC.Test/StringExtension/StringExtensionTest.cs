using System;
using Xunit;

namespace NS2.Verify.Test.StringExtension
{
    public class NotNullOrEmpty
    {
        [Fact]
        public void _On_A_Valid_String_Expect_Success()
        {
            ////Arrange
            var someString = "A1234";

            ////Act & Test
            Ensure.That(nameof(someString), someString).NotNullOrEmpty();
        }

        [Fact]
        public void _On_A_Null_String_Expect_ArgumentNullException()
        {
            ////Arrange
            string someString = null;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Ensure.That(nameof(someString), someString).NotNullOrEmpty());
        }

        [Fact]
        public void _On_A_String_Empty_Expect_ArgumentNullException()
        {
            ////Arrange
            string someString = string.Empty;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Ensure.That(nameof(someString), someString).NotNullOrEmpty());
        }
    }

    public class NotShorterThan
    {
        [Fact]
        public void _3_Expect_Sucess()
        {
            ////Arrange
            var someString = "A1234";

            ////Act & Test
            Ensure.That(nameof(someString), someString).NotShorterThan(3);
        }

        [Fact]
        public void _3_With_To_Short_String_Expect_ArgumentOutOfRangeException()
        {
            ////Arrange
            var someString = "A1";

            ////Act & Test
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            Ensure.That(nameof(someString), someString).NotShorterThan(3));
        }

        [Fact]
        public void _3_With_To_Null_String_Expect_ArgumentNullException()
        {
            ////Arrange
            string someString = null;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Ensure.That(nameof(someString), someString).NotShorterThan(3));
        }
    }

    public class NotLongerThan
    {
        [Fact]
        public void _3_Expect_Sucess()
        {
            ////Arrange
            var someString = "A12";

            ////Act & Test
            Ensure.That(nameof(someString), someString).NotLongerThan(3);
        }

        [Fact]
        public void _3_With_Short_String_Expect_Sucess()
        {
            ////Arrange
            var someString = "A1";

            ////Act & Test
            Ensure.That(nameof(someString), someString).NotLongerThan(3);
        }

        [Fact]
        public void _3_With_Big_String_Expect_ArgumentOutOfRangeException()
        {
            ////Arrange
            var someString = "A198796969696986986986986969869869869868969869869";

            ////Act & Test
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            Ensure.That(nameof(someString), someString).NotLongerThan(3));
        }

        [Fact]
        public void _3_With_To_Null_String_Expect_ArgumentNullException()
        {
            ////Arrange
            string someString = null;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Ensure.That(nameof(someString), someString).NotLongerThan(3));
        }
    }

    public class StartsWith
    {
        
    }

    public class EndsWith
    {

    }

    public class IsBasedOn
    {

    }

    public class IsUrl
    {

    }

    public class IsEmail
    {

    }

}
