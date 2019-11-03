using System.IO;
enum PacketType
{
    ConnectionRequest,
    ChallengeRequest,
    ChallengeResponse,
    ConnectionAccepted,
    
}
public class PacketHeader : ISerializablePacket
{
    public uint senderId;
    public uint id;
    public uint objectId;
    public ushort packetTypeIndex{get;set;}
    
    public void Deserialize(Stream stream)
    {
        BinaryReader br = new BinaryReader(stream);
        id = br.ReadUInt32();
        senderId = br.ReadUInt32();
        packetTypeIndex = br.ReadUInt16();
        
    }
    public void Serialize(Stream stream)
    {
        BinaryWriter bw = new BinaryWriter(stream);
        bw.Write(id);
        bw.Write(senderId);
        bw.Write(packetTypeIndex);
    }
}



