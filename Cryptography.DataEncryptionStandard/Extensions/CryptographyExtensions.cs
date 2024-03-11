namespace Cryptography.DataEncryptionStandard.Extensions
{
	using Blocks;

	public static class CryptographyExtensions
	{
		public static byte[] ConvertByteToBits(this byte singleByte)
		{
			byte[] bits = new byte[8];
			int index = 0;
			for (int i = 7; i >= 0; i--)
			{
				int singleBit = singleByte >> i & 1;
				bits[index] = (byte) singleBit;
				index++;
			}
			return bits;
		}

		public static byte ConvertBitsToByte(this int[] bits)
		{
			byte b = 0;
			for (int i = 0; i < 8; i++)
			{
				// set byte in b if byte is 0 do not shift byte
				if (bits[i] == 1)
				{
					b |= (byte)(1 << 7 - i);
				}
			}
			return b;
		}
		
		

		public static string DisplayBits(this int[] bitsArray)
		{
			return string.Join(string.Empty, bitsArray);
		}
	}
}