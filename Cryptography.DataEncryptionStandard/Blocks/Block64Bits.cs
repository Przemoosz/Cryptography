namespace Cryptography.DataEncryptionStandard.Blocks
{
    using System;
    using System.Linq;
    using Cryptography.DataEncryptionStandard.Abstract.Blocks;
    using Extensions;
    using Permutation;

    public class Block64Bits: BitsBlockBase
	{
		private Block64Bits(byte[] bits): base(bits)
		{
		}
		
		public static Block64Bits Create(byte[] bits)
		{
			if (bits.Length != 64)
			{
				throw new ArgumentException($"Provided {bits.Length} bits instead of 64 bits required for creating 64 bit block");
			}
			bits.ValidateIfCorrectBits();
			return new Block64Bits(bits);
		}

		public void ExecuteInitialPermutation()
		{
			Bits = InitialPermutation.Permute(Bits);
		}

		public (Block32Bits, Block32Bits) DivideInto32BitsBlocks()
		{
			Block32Bits firstHalf = Block32Bits.Create(Bits.GetFirstHalf());
			Block32Bits secondHalf = Block32Bits.Create(Bits.GetSecondHalf());
			return (firstHalf, secondHalf);
		}

	}
}
