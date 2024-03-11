namespace Cryptography.DataEncryptionStandard.Factories
{
	using Blocks;
	using Extensions;

	public sealed class Block64BitsFactory: IBlock64BitsFactory
	{
		public Block64Bits FromBytes(byte[] bytes)
		{
			if (bytes.Length < 8)
			{
				throw new ArgumentException($"Can not create 64 bits block from {bytes.Length} bytes");
			}
			var bitsArray = new List<byte>(64);
			for (int i = 0; i < 8; i++)
			{
				bitsArray.AddRange(bytes[i].ConvertByteToBits());
			}
			
			return Block64Bits.Create(bitsArray.ToArray());
		}

		public Block64Bits FromBytesWithExpansion(byte[] bytes)
		{
			if(bytes.Length >= 8)
			{
				return FromBytes(bytes);
			} 
			
			var bitsArray = new List<byte>(64);
			for (int i = 0; i < bytes.Length; i++)
			{
				bitsArray.AddRange(bytes[i].ConvertByteToBits());
			}
			for (int i = 0; i < 8 - bytes.Length; i++)
			{
				bitsArray.AddRange(CryptoConstants.ZeroByteInBits);
			}
			return Block64Bits.Create(bitsArray.ToArray());

		}
	}
}