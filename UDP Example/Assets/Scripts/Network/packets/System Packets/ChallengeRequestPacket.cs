
using System.IO;

public struct ChallengeRequestInfo
{
    public long serverSalt;
}
public class ChallengeRequestPacket : NetworkPacket<ChallengeRequestInfo>
{
    public ChallengeRequestPacket(ushort PacketType) : base(PacketType)
    {

    }
    protected override void OnSerialize(Stream stream)
    {
        BinaryWriter binaryWriter = new BinaryWriter(stream);
        binaryWriter.Write(Payload.serverSalt);
    }
    protected override void OnDeserialize(Stream stream)
    {
        BinaryReader binaryReader = new BinaryReader(stream);
        ChallengeRequestInfo challengeRequestInfo;

        challengeRequestInfo.serverSalt = binaryReader.ReadInt64();
        Payload = challengeRequestInfo;
    }
}
