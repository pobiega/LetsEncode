using ProtoBuf;
using System.IO;

namespace LetsEncode.EncodeTester
{
    public class ProtoBufConverter : IConverter
    {
        public DataSet FromByteArray(byte[] data)
        {
            using (var mem = new MemoryStream())
            {
                mem.Write(data, 0, data.Length);
                mem.Position = 0;

                var root = Serializer.Deserialize<Root>(mem);

                return new DataSet
                {
                    SignificantByte = root.sigByte,
                    ints = root.ints
                };
            }
        }

        public byte[] ToByteArray(DataSet data)
        {
            var root = new Root { sigByte = data.SignificantByte, ints = data.ints };

            using (var mem = new MemoryStream())
            {
                Serializer.Serialize(mem, root);
                mem.Position = 0;
                var reader = new BinaryReader(mem);
                return reader.ReadBytes((int)mem.Length);
            }
        }

        [ProtoContract]
        private class Root
        {
            [ProtoMember(1)]
            public byte sigByte;

            [ProtoMember(2)]
            public int[] ints;
        }
    }
}