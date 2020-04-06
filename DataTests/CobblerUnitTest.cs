using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        // 1. Check that it implements the INotifyPropertyChanged interface
        [Fact]
        public void CobblerImplementsINotifyPropertyChanged()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobbler);
        }

        // 2. Any time a property changes, the PropertyChanged event handler is invoked
        // Changing fruit should invoke change for fruit property
        [Fact]
        public void ChangingFruitPropertyShouldInvokePropertyChangedForFruit()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Fruit", () => {
                cobbler.Fruit = FruitFilling.Blueberry;
            });
        }

        // Changing fruit should invoke change for the price property
        [Fact]
        public void ChangingFruitPropertyShouldInvokePropertyChangedForPrice()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Price", () => {
                cobbler.Fruit = FruitFilling.Blueberry;
            });
        }

        // Changing fruit should invoke change for the special instructions property
        [Fact]
        public void ChangingFruitPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => {
                cobbler.Fruit = FruitFilling.Blueberry;
            });
        }

        // Changing WithIceCream should invoke change for the WithIceCream property
        [Fact]
        public void ChangingWithIceCreamPropertyShouldInvokePropertyChangedForWithIceCream()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "WithIceCream", () => {
                cobbler.WithIceCream = false;
            });
        }

        // Changing WithIceCream should invoke change for the Price property
        [Fact]
        public void ChangingWithIceCreamPropertyShouldInvokePropertyChangedForPrice()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Price", () => {
                cobbler.WithIceCream = false;
            });
        }

        // Changing WithIceCream should invoke change for the special instructions property
        [Fact]
        public void ChangingWithIceCreamPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => {
                cobbler.WithIceCream = false;
            });
        }
    }
}
