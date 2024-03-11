namespace Cryptography.DataEncryptionStandard.Tests.Factories
{
	using Blocks;
	using DataEncryptionStandard.Factories;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture, Parallelizable]
	public sealed class Block64BitsFactoryTests
	{
		private Block64BitsFactory _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new Block64BitsFactory();
		}

		[Test]
		public void FromBytes_CreatesBlockFromProvidedBytes()
		{
			// Arrange
			byte[] bytes =
			[
				byte.MaxValue, byte.MaxValue,
				byte.MaxValue, byte.MaxValue,
				byte.MaxValue, byte.MaxValue,
				byte.MaxValue, byte.MaxValue
			];
			
			// Act
			var actual = _sut.FromBytes(bytes);
			
			// Assert
			for (int i = 0; i < 64; i++)
			{
				actual[i].Should().Be(1);
			}
		}
		
		[Test]
		public void FromBytes_CreatesBlockOnlyFromEight()
		{
			// Arrange
			byte[] bytes =
			[
				byte.MaxValue, byte.MaxValue,
				byte.MaxValue, byte.MaxValue,
				byte.MaxValue, byte.MaxValue,
				byte.MaxValue, byte.MaxValue, 9, 15
			];
			
			// Act
			var actual = _sut.FromBytes(bytes);
			
			// Assert
			for (int i = 0; i < 64; i++)
			{
				actual[i].Should().Be(1);
			}
		}
		
		[Test]
		public void FromBytes_IfProvidedLessThanEightBytes_ThrowsArgumentException()
		{
			// Arrange
			byte[] bytes = [];
			Func<Block64Bits> func = () => _sut.FromBytes(bytes);
			
			// Act & Assert
			func.Should().Throw<ArgumentException>();
		}

		[Test]
		public void FromBytesWithExpansion_ReturnsBlockWithZeroesInMissingBits()
		{
			// Arrange
			byte[] bytes =
			[
				byte.MaxValue,
				131
			];
			
			// Act
			var actual = _sut.FromBytesWithExpansion(bytes);

			// Assert
			
			// First 8 bits for 255 - 11111111
			for (int i = 0; i < 8; i++)
			{
				actual[i].Should().Be(1);
			}
			
			// Second 8 bits for 131 - 10000011
			actual[8].Should().Be(1);
			actual[9].Should().Be(0);
			actual[10].Should().Be(0);
			actual[11].Should().Be(0);
			actual[12].Should().Be(0);
			actual[13].Should().Be(0);
			actual[14].Should().Be(1);
			actual[15].Should().Be(1);
			
			// Rest of bits are 0
			for (int i = 16; i < 64; i++)
			{
				actual[i].Should().Be(0);
			}
		}
	}
}