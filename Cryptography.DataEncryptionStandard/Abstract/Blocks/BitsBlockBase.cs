namespace Cryptography.DataEncryptionStandard.Abstract.Blocks
{
    internal abstract class BitsBlockBase
    {
        public byte[] Bits { get; set; }
        public abstract byte FirstBit { get; }
        public abstract byte LastBit { get; }
        protected BitsBlockBase(byte[] bits)
        {
            Bits = bits;
        }
    }
}