using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class UpdateLocalPlayer : MonoBehaviour
{
    private string localName;
    private Realtime realtime;
    private RealtimeAvatarManager manager;
    private RealtimeAvatar localAvatar;

    private void Awake()
    {
        realtime = GetComponent<Realtime>();
        manager = GetComponent<RealtimeAvatarManager>();
    }


    public void SavePlayerName(TextMeshProUGUI name)
    {
        localName = name.text;
        if (realtime.connected)
        {
            localAvatar = manager.localAvatar;
            TransferNameToModel();
        }
    }

    public void TransferNameToModel()
    {
        print(localAvatar);
        localAvatar.gameObject.GetComponent<Player>().SetName(localName);
    }

}
