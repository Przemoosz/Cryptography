namespace Cryptography.DataEncryptionStandard.Tests.Extensions
{
	using DataEncryptionStandard.Extensions;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture, Parallelizable]
	internal sealed class ArrayExtensionsTests
	{
		[Test]
		public void GetFirstHalf_ReturnsFirstHalfOfArray()
		{
			// Arrange
			int[] array = [1, 2, 3, 4, 5, 6];
			int[] firstHalfOfArray = [1, 2, 3];
			
			// Act
			var actual = array.GetFirstHalf();

			// Assert
			actual.Should().NotBeNull();
			actual.Length.Should().Be(array.Length/2);
			actual.Should().BeEquivalentTo(firstHalfOfArray);
		}

		[Test]
		public void GetFirstHalf_IfArrayIsNull_ThrowsArgumentException()
		{
			// Arrange
			int[] array = null;
			Func<int[]> func = () => array.GetFirstHalf();
			
			// Act & Assert
			func.Should().Throw<ArgumentException>();
		}
		
		[Test]
		public void GetFirstHalf_IfArrayLengthIsOdd_ThrowsArgumentException()
		{
			// Arrange
			int[] array = [1, 2, 3];
			Func<int[]> func = () => array.GetFirstHalf();
			
			// Act & Assert
			func.Should().Throw<ArgumentException>();
		}
		
		
		[Test]
		public void GetSecondHalf_ReturnsFirstHalfOfArray()
		{
			// Arrange
			int[] array = [1, 2, 3, 4, 5, 6];
			int[] firstHalfOfArray = [4, 5, 6];
			
			// Act
			var actual = array.GetSecondHalf();

			// Assert
			actual.Should().NotBeNull();
			actual.Length.Should().Be(array.Length/2);
			actual.Should().BeEquivalentTo(firstHalfOfArray);
		}

		[Test]
		public void GetSecondHalf_IfArrayIsNull_ThrowsArgumentException()
		{
			// Arrange
			int[] array = null;
			Func<int[]> func = () => array.GetSecondHalf();
			
			// Act & Assert
			func.Should().Throw<ArgumentException>();
		}
		
		[Test]
		public void GetSecondHalf_IfArrayLengthIsOdd_ThrowsArgumentException()
		{
			// Arrange
			int[] array = [1, 2, 3];
			Func<int[]> func = () => array.GetSecondHalf();
			
			// Act & Assert
			func.Should().Throw<ArgumentException>();
		}
	}
}
