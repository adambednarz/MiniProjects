using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTests.SampleData;
using XUnitTests.Tests.HelperClasses;

namespace XUnitTests.Tests
{
    public class CarTests
    {
        [Fact]
        public void Should_Increment_Millage()
        {
            // Arrange 
            var engineMock = new Mock<IEngine>();
            var car = new Car("Ford", "Focus", 10000, engineMock.Object);
            var expectedMillage = 10001;

            // Act 
            car.IncremenrMillage();

            // Assert
            Assert.Equal(expectedMillage, car.Millage);
        }

        [Fact]
        public void Car_Should_Activate_Oil_Diode_When_Engine_Has_Low_Oil()
        {
            var engineMock = new Mock<IEngine>();
            var car = new Car("Ford", "Focus", 10000, engineMock.Object);
            engineMock.Setup(x => x.IsOilOk()).Returns(false);

            Assert.True(car.IsOilDiodaActive);
        }

        [Fact]
        public void Car_Should_Have_Information_About_Oil_Status()
        {
            double oilStatus = 1.75;
            var engineMock = new Mock<IEngine>();
            var car = new Car("Ford", "Focus", 10000, engineMock.Object);
            engineMock.Setup(x => x.OilStatus).Returns(oilStatus);

            Assert.Equal(oilStatus, car.GetOilStatus());
        }

        //Buy a car can only person who:
        // - does not have empty name
        // - has a license
        // - has budget greater than 100000

        private static Person[] personCanBuy = new Person[]
        {
            new Person { Name = "Adam", License = true, Budget = 110000},
            new Person { Name = "Karol", License = true, Budget = 200000}
        };
        public static PersonTheoryData<Person> PersonCanBuyData { get; } = new PersonTheoryData<Person>(personCanBuy);

        [Theory]
        [MemberData(nameof(PersonCanBuyData))]
        public void Should_sell_car(Person person)
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var car = new Car("Ford", "Focus", 100000, engineMock.Object);
            // Act
            car.SellTo(person);
            //Assert
            Assert.Equal(person, car.Owner);
        }


        private static Person[] personCanNotBuy = new Person[]
        {
            new Person { Name = "", License = true, Budget = 110000},
            new Person { Name = "Adam", License = false, Budget = 110000},
            new Person { Name = "Karol", License = true, Budget = 20000}
        };

        public static PersonTheoryData<Person> PersonCanNotBuyData { get; } = new PersonTheoryData<Person>(personCanNotBuy);

        [Theory]
        [MemberData(nameof(PersonCanNotBuyData))]
        public void Should_not_sell_car(Person person)
        {
            var engineMock = new Mock<IEngine>();
            var car = new Car("Ford", "Focus", 100000, engineMock.Object);

            Assert.ThrowsAny<Exception>(() =>
                car.SellTo(person)
            );

        }
    }
}
