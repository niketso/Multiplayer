using System.IO;


public enum UserPacketType
{
    message
}
public class UserPacketHeader : ISerializablePacket
{
    public uint senderId;
    public uint id;
    public uint objectId;
    public ushort packetType { get; set; }
    public void Deserialize(Stream stream)
    {
        BinaryReader br = new BinaryReader(stream);
        id = br.ReadUInt32();
        senderId = br.ReadUInt32();
        packetType = br.ReadUInt16();
        
    }

    public void Serialize(Stream stream)
    {
         BinaryWriter bw = new BinaryWriter(stream);
        bw.Write(id);
        bw.Write(senderId);
        bw.Write(packetType);
    }
}
