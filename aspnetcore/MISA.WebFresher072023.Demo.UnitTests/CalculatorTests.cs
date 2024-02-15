using MISA.WebFresher072023.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.UnitTests
{

    [TestFixture]
    public class CalculatorTests
    {
        /// <summary>
        /// Unit test cho phương thức Add với input hợp lệ
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <param name="expected">int</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase(10000, 5000, 15000)]
        [TestCase(1, 39, 40)]
        [TestCase(100, 54, 154)]
        public void Add_ValidInput_SumTwoNumber(int x, int y, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        /// <summary>
        /// Unit test cho phương thức Add với input hợp lệ
        /// </summary>
        /// <param name="input">string</param>
        /// <param name="expected">int</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase("", 0)]
        [TestCase("2", 2)]
        [TestCase("9, , 11", 20)]
        [TestCase("9, 11, 13", 33)]
        public void Add_ValidInput_SumOfNumbers(string input, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Unit test cho phương thức Add với input không hợp lệ
        /// </summary>
        /// <param name="input">string</param>
        /// <param name="expected">string</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase("2, -abc, 5", "Input không đúng định dạng")]
        [TestCase("2, -abc, -def", "Input không đúng định dạng")]
        public void Add_InvalidInput_FormatException(string input, string expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act và Assert
            try
            {
                var actual = calculator.Add(input);
            }
            catch (FormatException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expected));
            }
        }

        /// <summary>
        /// Unit test cho phương thức Add với input không hợp lệ
        /// </summary>
        /// <param name="input">string</param>
        /// <param name="expected">string</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase("9, -11, -13", "Không chấp nhận toán hạng âm: -11, -13")]
        [TestCase("99, -111, -133", "Không chấp nhận toán hạng âm: -111, -133")]
        [TestCase("999, -1111, -1333, -4444", "Không chấp nhận toán hạng âm: -1111, -1333, -4444")]
        public void Add_NegativeNumbers_FormatException(string input, string expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act và Assert
            try
            {
                var actual = calculator.Add(input);
            }
            catch (FormatException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expected));
            }
        }

        /// <summary>
        /// Unit test cho phương thức Sub với input không hợp lệ
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <param name="expected">int</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase(9, 11, -2)]
        [TestCase(11, 13, -2)]
        [TestCase(2, 3, -1)]
        public void Sub_ValidInput_SubTwoNumber(int x, int y, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Sub(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Unit test cho phương thức Mul với input hợp lệ
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <param name="expected">int</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 3, 6)]
        [TestCase(3, 4, 12)]
        public void Mul_ValidInput_MulTwoNumber(int x, int y, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Mul(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Div_ZeroInput_DivByZeroException()
        {
            // Arrange
            var calculator = new Calculator();

            // Act và Assert
            try
            {
                var actual = calculator.Div(9, 0);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Không thể chia cho 0"));
            }
        }

        /// <summary>
        /// Unit test cho phương thức Div với input hợp lệ
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <param name="expected">int</param>
        /// CreatedBy: youngbachhh (12/09/2023)
        [Test]
        [TestCase(4, 2, 2)]
        [TestCase(9, 11, 0)]
        [TestCase(13, 15, 0)]
        public void Div_ValidInput_DivTwoNumber(int x, int y, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Div(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
