using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HostingGame : MonoBehaviour
{
    [SerializeField]
    private uint RoomSize = 10;

    private string RoomName;

    public NetworkManager NetworkM;

    public void SetRoomName(string Name)
    {
        RoomName = name;
    }


    public void CreateRoom()
    {
        if (RoomName != "" && RoomName != null)
        {
            NetworkM.matchMaker.CreateMatch(RoomName, RoomSize, true, "", "", "", 0, 0, NetworkM.OnMatchCreate);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NetworkM = NetworkManager.singleton;
        if(NetworkM.matchMaker == null)
        {
            NetworkM.StartMatchMaker();
        }
    }
}

    // Update is called once per frame
    
