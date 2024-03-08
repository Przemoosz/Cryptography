namespace Cryptography.DataEncryptionStandard.Blocks
{
    using System;
    using System.Linq;
    using Cryptography.DataEncryptionStandard.Abstract.Blocks;
    using Extensions;

    internal class Block64Bits: BitsBlockBase
	{
		private Block64Bits(byte[] bits): base(bits)
		{
		}

		public override byte FirstBit => Bits[0];
		public override byte LastBit => Bits[63];

		public static Block64Bits Create(byte[] bits)
		{
			if (bits.Length != 64)
			{
				throw new ArgumentException($"Provided {bits.Length} bits instead of 64 bits required for creating 64 bit block");
			}
			if (bits.Any(s => s != 0 && s != 1))
			{
				throw new ArgumentException($"To create block you have to provide byte array with only 0 or 1 as values!");
			}

			return new Block64Bits(bits);
		}

		public (Block32Bits, Block32Bits) DivideInHalf()
		{
			Block32Bits firstHalf = Block32Bits.Create(Bits.GetFirstHalf());
			Block32Bits secondHalf = Block32Bits.Create(Bits.GetSecondHalf());
			return (firstHalf, secondHalf);
		}
	}
}
