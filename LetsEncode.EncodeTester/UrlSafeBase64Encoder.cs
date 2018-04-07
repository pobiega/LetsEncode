using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsEncode.EncodeTester
{
    public class UrlSafeBase64Encoder : IEncoder
    {
        public byte[] ConvertFromString(string str)
        {
            return Base64UrlEncoder.DecodeBytes(str);
        }

        public string ConvertToString(byte[] data)
        {
            return Base64UrlEncoder.Encode(data);
        }
    }
}
