using System;
using NS2.DbC;
using Xunit;

namespace NSquared2.DbC.Test
{
    public class PropertiesValidationExtensionTest
    {
        public class FakeObject
        {
            public string Name { get; set; }
            public string Name3 { get; set; }
            public string Name4 { get; set; }
            public int Number { get; set; }
            public int? Number3 { get; set; }
        }

        [Fact]
        public void When_Validate_All_Properties_Must_Have_Value_Expect_Sucess()
        {
            ////Arrange
            var fake = new FakeObject
            {
                Name = "test",
                Name3 = "test3",
                Name4 = "test4",
                Number = 1,
                Number3 = 3
            };

            ////Act & test
            Contract.Require(nameof(fake), fake).AllPropertiesMusthaveValue();
        }

        [Fact]
        public void When_Validate_All_Properties_With_Some_Null_Expect_ArgumentNullException()
        {
            ////Arrange
            var fake = new FakeObject
            {
                Name = "test",
                Name3 = "test3",
                Name4 = null,
                Number = 1,
                Number3 = 3
            };

            ////Act & test
            Assert.Throws<ArgumentNullException>(() =>
            Contract.Require(nameof(fake), fake).AllPropertiesMusthaveValue());
        }

        [Fact]
        public void When_Validate_Some_Properties_On_Object_Expect_Success()
        {
            ////Arrange
            var fake = new FakeObject
            {
                Name = "test",
                Name3 = null,
                Name4 = null,
                Number = 1,
                Number3 = 3
            };

            ////Act & test
            Contract.Require(nameof(fake), fake).IncludePropertiesThatMusthaveValue(nameof(fake.Name), nameof(fake.Number), nameof(fake.Number3));
        }

        [Fact]
        public void When_Validate_Some_Properties_With_One_Defines_As_Null_Expect_ArgumentNullException()
        {
            ////Arrange
            var fake = new FakeObject
            {
                Name = "test",
                Name3 = null,
                Name4 = null,
                Number = 1,
                Number3 = null
            };

            ////Act & test
            ////Act & test
            Assert.Throws<ArgumentNullException>(() =>
            Contract.Require(nameof(fake), fake).IncludePropertiesThatMusthaveValue(nameof(fake.Name), nameof(fake.Number), nameof(fake.Number3)));
        }
    }
}
