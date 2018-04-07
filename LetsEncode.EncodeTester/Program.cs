using System;
using System.Collections.Generic;

namespace LetsEncode.EncodeTester
{
    class Program
    {
        public const int NUMBER_OF_INTS = 4;
        public const int NUMBER_OF_SETS = 100;

        private static Random rng = new Random();
        public static int RandInt => rng.Next(int.MinValue, int.MaxValue);

        public static IEncoder Encoder = new UrlSafeBase64Encoder();

        static void Main(string[] args)
        {
            var converters = new List<IConverter>
            {
                new BinaryConverter(),
                new ProtoBufConverter(),
            };

            bool quit = false;
            while (!quit)
            {
                List<DataSet> sets = GenerateDataSets();
                TestAllSetsWithAllConverters(converters, sets);
                var d = Console.ReadLine();

                if (d != string.Empty)
                    quit = true;
            }
        }

        private static void TestAllSetsWithAllConverters(List<IConverter> converters, List<DataSet> sets)
        {
            foreach (var converter in converters)
            {
                var max = 0;
                var min = int.MaxValue;

                foreach (var set in sets)
                {
                    var size = TestConverter(converter, set);

                    if (size > max)
                    {
                        max = size;
                    }
                    if (size < min)
                    {
                        min = size;
                    }
                }

                Console.WriteLine($"{converter}: {min}-{max}");
            }
        }

        private static int TestConverter(IConverter converter, DataSet set)
        {
            var setAsBytes = converter.ToByteArray(set);
            var bytesAsSet = converter.FromByteArray(setAsBytes);

            if (!set.Equals(bytesAsSet))
            {
                throw new Exception($"{converter} failed equality on {set}!");
            }

            return Encoder.ConvertToString(setAsBytes).Length;
        }

        private static List<DataSet> GenerateDataSets()
        {
            var sets = new List<DataSet>();

            for (int i = 0; i < NUMBER_OF_SETS; i++)
            {
                var ints = new List<int>(NUMBER_OF_INTS);

                for (int j = 0; j < NUMBER_OF_INTS; j++)
                {
                    ints.Add(RandInt);
                }

                sets.Add(new DataSet
                {
                    SignificantByte = rng.NextByte(),
                    ints = ints.ToArray()
                });
            }

            return sets;
        }
    }
}
