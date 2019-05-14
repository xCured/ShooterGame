using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomsList : MonoBehaviour
{

    //I followed Brackeys tutorials on how to create the lobby screen.
    //This script was created by following a tutorial.
    public delegate void JoinGames(MatchInfoSnapshot _match);
    private JoinGames joinCallbackc;
    [SerializeField]
    private Text RoomNameText;

    private MatchInfoSnapshot Match;
    public void Setup(MatchInfoSnapshot _Match, JoinGames _joinCallbackc)
    {
        Match = _Match;
        joinCallbackc = _joinCallbackc;
        RoomNameText.text = Match.name + "(" + Match.currentSize + "/" + Match.maxSize + ")";
        
    }
    // Start is called before the first frame update
    public void JoinRoom()
    {
        joinCallbackc.Invoke(Match);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
