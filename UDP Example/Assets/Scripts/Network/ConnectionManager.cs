using UnityEngine;

public enum PacketType
{
    connectionRequest,
    challengeRequest,
    challengeResponse,
    connected,
    user
}
public struct Client
{
    public float timeStamp;
    public int id;
    public IPEndPoint ipEndPoint;

    public Client(IPEndPoint ipEndPoint, int id, float timeStamp)
    {
        this.timeStamp = timeStamp;
        this.id = id;
        this.ipEndPoint = ipEndPoint;
    }
}
public class ConnectionManager : MonoBehaviour
{ 
    public void CreateServer()
    {

    }
    public void ConnectToServer(NetworkManager networkManager)
    {
      
    }

   


}
