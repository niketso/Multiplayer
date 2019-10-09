using System.IO;
using System.Net;

public class NetworkPacket<P> :ISerializablePacket
{
    public PacketType type;
    public int clientId;
    public IPEndPoint ipEndPoint;
    public float timeStamp;
    public byte[] payload;

    public NetworkPacket(PacketType type, byte[] data, float timeStamp, int clientId = -1, IPEndPoint ipEndPoint = null)
    {
        this.type = type;
        this.timeStamp = timeStamp;
        this.clientId = clientId;
        this.ipEndPoint = ipEndPoint;
        this.payload = data;
    }

    public void Deserialize(Stream stream)
    {
        throw new System.NotImplementedException();
    }

    public void Serialize(Stream stream)
    {
        throw new System.NotImplementedException();
    }
}