using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    private Player _player;
   
    private TextMeshProUGUI _playerTextUI;
    private string playerName;


    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _playerTextUI = GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;

        if (playerName != _player.playerName)
        {
            playerName = _player.playerName;
            _playerTextUI.SetText(playerName);
        }
    }
}
