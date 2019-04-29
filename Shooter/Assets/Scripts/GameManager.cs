using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour


{


    private const string PLAYERID = "Player";


     public static Dictionary<string, PlayerManager> Players = new Dictionary<string, PlayerManager>();
    //Dictionary is like a list

    void Update()
    {
       
    }
    public static void PlayerRegistration(string netID, PlayerManager player)
    {
        string playerID = PLAYERID + netID;

        Players.Add(playerID, player);

        //16 adding it to the dictionary which is a KEY:ID
        //player.transfrorm.name = playerid
        //the line under this allows you to check/rename the players in the hierarchy to check what players are in the game. 
       player.transform.name = playerID;

    }
    public static void Unregister(string playerID)
    {
        Players.Remove(playerID);
    }

    public static PlayerManager GetPlayer (string playerID)
    {

        return Players[playerID];

    }
}
