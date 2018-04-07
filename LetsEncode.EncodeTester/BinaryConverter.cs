using System.Collections.Generic;
using System.IO;

namespace LetsEncode.EncodeTester
{
    internal class BinaryConverter : IConverter
    {
        public DataSet FromByteArray(byte[] data)
        {
            using (var mem = new MemoryStream())
            {
                var binWriter = new BinaryWriter(mem);
                binWriter.Write(data);
                binWriter.Seek(0, SeekOrigin.Begin);
                var reader = new BinaryReader(mem);
                var testByte = reader.ReadByte();

                var intz = new List<int>();

                for (var i = 0; i < Program.NUMBER_OF_INTS; i++)
                {
                    intz.Add(reader.ReadInt32());
                }
                return new DataSet
                {
                    SignificantByte = testByte,
                    ints = intz.ToArray()
                };
            }
        }

        public byte[] ToByteArray(DataSet data)
        {
            using (var mem = new MemoryStream())
            {
                var binWriter = new BinaryWriter(mem);
                binWriter.Write(data.SignificantByte);
                foreach (var i in data.ints)
                    binWriter.Write(i);
                binWriter.Seek(0, SeekOrigin.Begin);

                var reader = new BinaryReader(mem);
                return reader.ReadBytes((int)mem.Length);
            }
        }
    }
}