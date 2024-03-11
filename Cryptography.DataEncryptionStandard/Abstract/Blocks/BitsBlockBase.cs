namespace Cryptography.DataEncryptionStandard.Abstract.Blocks
{
    public abstract class BitsBlockBase
    {
        public override int BlockSize { get; } 
        public byte this[int i] => Bits[i];
        public byte[] Bits { get; protected set; }

        public byte FirstBit => Bits[0];
        public byte LastBit => Bits[^1];
        protected BitsBlockBase(byte[] bits)
        {
            Bits = bits;
        }
    }
}