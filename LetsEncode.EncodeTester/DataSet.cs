namespace LetsEncode.EncodeTester
{
    public class DataSet
    {
        public byte SignificantByte;

        public int[] ints;

        public override bool Equals(object obj)
        {
            var other = (obj as DataSet);

            if (other == null)
                return false;
            else
            {
                if (SignificantByte != other.SignificantByte)
                    return false;
                for (var i = 0; i < ints.Length; i++)
                {
                    if (ints[i] != other.ints[i])
                        return false;
                }
            }

            return true;
        }
    }
}