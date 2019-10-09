using System.IO;


public enum UserPacketType
{
    message
}
public class UserPacketHeader : ISerializablePacket
{
    public void Deserialize(Stream stream)
    {
        throw new System.NotImplementedException();
        
    }

    public void Serialize(Stream stream)
    {
        throw new System.NotImplementedException();
    }
}
