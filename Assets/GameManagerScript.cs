using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private Realtime realtime;
    private RealtimeAvatarManager realtimeAvatarManager;
    public string gameSceneName;
    public string tutorialSceneName;


    private void Awake()
    {
        realtime = GetComponent<Realtime>();
        realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();
        realtimeAvatarManager.avatarCreated += AvatarCreated;
        realtimeAvatarManager.avatarDestroyed += AvatarDestroyed;
    }

    // player joins room
    private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        // Avatar created!
        print("Avatar created!");
    }

    // player leaves room
    private void AvatarDestroyed(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        // Avatar destroyed!
        print("Avatar destroyed!");
    }

    public void ChangeRoom(string roomName)
    {
        if (roomName == "GameRoom")
        {
            realtime.Connect(roomName);
            SceneManager.LoadScene(gameSceneName);
        }

        else if (roomName == "TutorialRoom")
        {
            realtime.Connect(roomName);
            SceneManager.LoadScene(tutorialSceneName);
        }
    }
}
