using System;
using NS2.DbC;
using Xunit;

namespace NSquared2.DbC.Test
{
    public class NotNullOrEmpty
    {
        [Fact]
        public void _On_A_Valid_String_Expect_Success()
        {
            ////Arrange
            var someString = "A1234";

            ////Act & Test
            Contract.Require(nameof(someString), someString).NotNullOrEmpty();
        }

        [Fact]
        public void _On_A_Null_String_Expect_ArgumentNullException()
        {
            ////Arrange
            string someString = null;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Contract.Require(nameof(someString), someString).NotNullOrEmpty());
        }

        [Fact]
        public void _On_A_String_Empty_Expect_ArgumentNullException()
        {
            ////Arrange
            string someString = string.Empty;

            ////Act & Test
            Assert.Throws<ArgumentNullException>(() =>
            Contract.Require(nameof(someString), someString).NotNullOrEmpty());
        }
    }

    public class NotShorterThan
    {

    }

    public class NotLongerThan
    {

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
