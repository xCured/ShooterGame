using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.NetworkSystem;

public class Joining : MonoBehaviour
{

    List<GameObject> RoomList = new List<GameObject>();

    private NetworkManager NetworkM;
    public Text status;

    [SerializeField]
    private GameObject RoomListPref;

    [SerializeField]
    private Transform ParentRoomList;

    // Start is called before the first frame update
    void Start()
    {
        NetworkM = NetworkManager.singleton;
        if (NetworkM.matchMaker == null)
        {
            NetworkM.StartMatchMaker();
        }

        Refresh();
    }
    public void Refresh()
    {
        ClearRoom();
        NetworkM.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        status.text = "load";


    }


    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        status.text = "";
        if (!success ||matchList == null)
        {
            status.text = "No match list found";
            return;
        }
        
        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject RoomListItem = Instantiate(RoomListPref);
            RoomListItem.transform.SetParent(ParentRoomList);

            RoomsList _RoomListItem = RoomListItem.GetComponent<RoomsList>();
            if (_RoomListItem != null)
            {
                _RoomListItem.Setup(match, JoinRoom);
            }



            RoomList.Add(RoomListItem);
        }
        if (RoomList.Count == 0)
        {
            status.text = "No rooms have been created at this moment.";
        }
    }

    public void JoinRoom(MatchInfoSnapshot _match)
    {
        NetworkM.matchMaker.JoinMatch(_match.networkId,"","","",0,0, NetworkM.OnMatchJoined );
    }

    void ClearRoom()
    {
        for (int i = 0; i < RoomList.Count; i++)
        {
            Destroy(RoomList[i]);
        }
        RoomList.Clear();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }


}