using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    [SerializeField] private TMP_Text roomPlayerCount;
    
    public RoomInfo info;
    
    public void SetUp(RoomInfo roomInfo)
    {
        info = roomInfo;
        roomName.text = info.Name;
        roomPlayerCount.text = "     " + info.PlayerCount + "/" + info.MaxPlayers;
    }

    public void OnClick()
    {
        Launcher.instance.JoinRoom(info);
    }
}
