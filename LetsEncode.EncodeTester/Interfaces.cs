using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsEncode.EncodeTester
{
    interface IEncoder
    {
        string ConvertToString(byte[] data);

        byte[] ConvertFromString(string str);
    }

    interface IConverter
    {
        byte[] ToByteArray(DataSet data);

        DataSet FromByteArray(byte[] data);
    }
}
