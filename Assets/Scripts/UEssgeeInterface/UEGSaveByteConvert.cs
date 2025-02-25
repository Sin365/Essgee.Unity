using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UEGSaveByteConvert : IAxiEssgssStatusBytesCover
{
    public AxiEssgssStatusData ToAxiEssgssStatusData(byte[] byteArray)
    {
        using (MemoryStream ms = new MemoryStream(byteArray))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (AxiEssgssStatusData)formatter.Deserialize(ms);
        }
    }

    public byte[] ToByteArray(AxiEssgssStatusData data)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, data);
            return ms.ToArray();
        }
    }
}
