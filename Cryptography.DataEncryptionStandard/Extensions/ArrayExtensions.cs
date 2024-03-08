namespace Cryptography.DataEncryptionStandard.Extensions
{
	public static class ArrayExtensions
	{
		public static T[] GetFirstHalf<T>(this T[] array)
		{
			if (array == null || array.Length % 2 == 1)
			{
				throw new ArgumentException("Can not divide array in two equal parts");
			}
			T[] firstHalf = new T[array.Length / 2];
			for (int i = 0; i < (array.Length / 2); i++)
			{
				firstHalf[i] = array[i];
			}

			return firstHalf;
		}

		public static T[] GetSecondHalf<T>(this T[] array)
		{
			if (array == null || array.Length % 2 == 1)
			{
				throw new ArgumentException("Can not divide array in two equal parts");
			}

			int halfSize = array.Length / 2;
			T[] secondHalf = new T[halfSize];
			
			for (int i = 0; i < halfSize; i++)
			{
				secondHalf[i] = array[halfSize + i];
			}
			return secondHalf;
		}
	}
}
