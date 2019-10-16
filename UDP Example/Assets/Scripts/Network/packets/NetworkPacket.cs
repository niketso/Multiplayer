using System.IO;
using System.Net;

public abstract class NetworkPacket<P> :ISerializablePacket
{
    public P Payload {get;set;}
    public ushort PacketType {get; private set;}
    public ushort packetType { get; set; }

    public NetworkPacket(ushort PacketType)
    {
        this.PacketType = PacketType;

    }
    protected abstract void OnSerialize(Stream stream);
    protected abstract void OnDeserialize(Stream stream);
    public void Deserialize(Stream stream)
    {
        OnDeserialize(stream);
    }

    public void Serialize(Stream stream)
    {
        OnSerialize(stream);
    }
}