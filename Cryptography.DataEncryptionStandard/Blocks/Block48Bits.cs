namespace Cryptography.DataEncryptionStandard.Blocks
{
	using Abstract.Blocks;
	using Extensions;

	public sealed class Block48Bits: BitsBlockBase
	{
		public Block48Bits(byte[] bits) : base(bits)
		{
		}
		
		public static Block48Bits Create(byte[] bits)
		{
			if (bits.Length != 48)
			{
				throw new ArgumentException($"Provided {bits.Length} bits instead of 64 bits required for creating 48 bit block");
			}
			bits.ValidateIfCorrectBits();

			return new Block48Bits(bits);
		}
	}
}