using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketManager :MonoBehaviourSingleton<PacketManager> ,IReceiveData
{
    private Dictionary<uint, System.Action<ushort, Stream>> onPacketReceived = new Dictionary<uint, System.Action<ushort, Stream>>();
    public void Start()
    {
        NetworkManager.Instance.OnReceiveEvent += OnReceiveData;
    }

    public void OnReceiveData(byte[] data, IPEndPoint ipEndpoint)
    {
        Debug.Log($"Receiving: " + data);

        PacketHeader header = new PacketHeader();
        MemoryStream stream = new MemoryStream(data);

        header.Deserialize(stream);

       // InvokeCallback(header.objectId, header.packetType, stream);

        stream.Close();
    }
}
