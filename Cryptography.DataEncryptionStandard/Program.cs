namespace Cryptography.DataEncryptionStandard
{
	using System.Text;
	using Blocks;
	using Factories;
	using Permutation;

	internal class Program
	{
		static void Main(string[] args)
		{
			Block64BitsFactory factory = new Block64BitsFactory();
			string textToCipher = "Cryptography.DataEncryptionStandard";
			byte[] bytes = Encoding.UTF8.GetBytes(textToCipher);
			Block64Bits block = factory.FromBytesWithExpansion(bytes);
			block.ExecuteInitialPermutation();
		}
	}
}
