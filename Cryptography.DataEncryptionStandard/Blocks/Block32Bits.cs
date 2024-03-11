namespace Cryptography.DataEncryptionStandard.Blocks
{
	using Cryptography.DataEncryptionStandard.Abstract.Blocks;
	using Extensions;

	public class Block32Bits: BitsBlockBase
	{
		public override int BlockSize => 32;
		private Block32Bits(byte[] bits): base(bits)
		{
		}
		
		public static Block32Bits Create(byte[] bits)
		{
			if (bits.Length != 32)
			{
				throw new ArgumentException($"Provided {bits.Length} bits instead of 64 bits required for creating 32 bit block");
			}
			ValidateBits(bits);


			return new Block32Bits(bits);
		}

	}
}