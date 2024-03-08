namespace Cryptography.DataEncryptionStandard.Blocks
{
	using Cryptography.DataEncryptionStandard.Abstract.Blocks;

	internal class Block32Bits: BitsBlockBase
	{
		private Block32Bits(byte[] bits): base(bits)
		{
		}

		public override byte FirstBit => Bits[0];
		public override byte LastBit => Bits[31];

		public static Block32Bits Create(byte[] bits)
		{
			if (bits.Length != 32)
			{
				throw new ArgumentException($"Provided {bits.Length} bits instead of 64 bits required for creating 32 bit block");
			}
			if (bits.Any(s => s != 0 && s != 1))
			{
				throw new ArgumentException($"To create block you have to provide byte array with only 0 or 1 as values!");
			}

			return new Block32Bits(bits);
		}
	}
}