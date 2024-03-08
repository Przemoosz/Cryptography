namespace Cryptography.DataEncryptionStandard.Tests.Extensions
{
	using DataEncryptionStandard.Extensions;
	using FluentAssertions;
	using NUnit.Framework;
	
	[TestFixture, Parallelizable]
	public sealed class CryptographyExtensionsTests
	{
		[TestCase(10,"00001010")]
		[TestCase(139,"10001011")]
		public void ConvertByteToBits_ReturnsBitsOfNumber(byte number, string expectedNumberInBits)
		{
			// Act
			var actual = number.ConvertByteToBits();
			var actualString = string.Join(string.Empty, actual);
			
			// Assert
			actualString.Should().Be(expectedNumberInBits);
		}
	}
}