namespace Cryptography.DataEncryptionStandard.Factories
{
	using Blocks;

	public interface IBlock64BitsFactory
	{
		Block64Bits FromBytes(byte[] bytes);
		Block64Bits FromBytesWithExpansion(byte[] bytes);
	}
}