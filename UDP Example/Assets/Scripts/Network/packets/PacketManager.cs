
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using UnityEngine;

public class PacketManager :MonoBehaviourSingleton<PacketManager> ,IReceiveData
{
    private Dictionary<uint, System.Action<ushort, Stream>> onPacketReceived = new Dictionary<uint, System.Action<ushort, Stream>>();
    private uint currentPacketId = 0;
    public void Start()
    {
        NetworkManager.Instance.OnReceiveEvent += OnReceiveData;
    }
    public void AddListener(uint ownerId,Action<ushort,Stream> callback)
    {
        if (!onPacketReceived.ContainsKey(ownerId))
            onPacketReceived.Add(ownerId, callback);
    }
    public void RemoveListener(uint id)
    {
        if (onPacketReceived.ContainsKey(id))
            onPacketReceived.Remove(id);
    }
    public void SendPacket(ISerializablePacket packet,uint objectId)
    {
         byte[] bytes = Serialize(packet, objectId);

        if (NetworkManager.Instance.isServer)
            NetworkManager.Instance.Broadcast(bytes);
        else
            NetworkManager.Instance.SendToServer(bytes);
    }

    public byte[] Serialize(ISerializablePacket packet,uint objectId)
    {
        PacketHeader header = new PacketHeader();
        MemoryStream stream = new MemoryStream();

        header.id = currentPacketId;
        //header.senderId = NetworkManager/*connection manager */.Instance.clientId;
        header.objectId = objectId;
        header.packetType = packet.packetType;

        header.Serialize(stream);
        packet.Serialize(stream);
        
        return stream.ToArray();
    }
    public void OnReceiveData(byte[] data, IPEndPoint ip)
    {
        Debug.Log($"Receiving: " + data);

        PacketHeader header = new PacketHeader();
        MemoryStream stream = new MemoryStream(data);

        header.Deserialize(stream);

       if (onPacketReceived.ContainsKey(header.objectId))
            onPacketReceived[header.objectId].Invoke(header.packetType, stream);

        stream.Close();
    }
     
}
