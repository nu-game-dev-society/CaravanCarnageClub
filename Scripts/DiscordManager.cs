using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordManager : MonoBehaviour {

    private string applicationId = "540255683837296671";
    private string steamId = "";
    private DiscordRpc.RichPresence presence = new DiscordRpc.RichPresence();
    private DiscordRpc.EventHandlers handlers;

    private bool connected = false;

    void OnEnable () {
        handlers = new DiscordRpc.EventHandlers();
        handlers.readyCallback += ReadyCallback;
        handlers.disconnectedCallback += DisconnectedCallback;
        handlers.errorCallback += ErrorCallback;
        DiscordRpc.Initialize(applicationId, ref handlers, true, steamId);
    }

    void OnDisable()
    {
        DiscordRpc.ClearPresence();
        DiscordRpc.Shutdown();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        UpdatePresence();
        DiscordRpc.RunCallbacks();
    }

    public void ReadyCallback(ref DiscordRpc.DiscordUser connectedUser)
    {
        connected = true;

        Debug.Log(string.Format("Discord: connected to {0}#{1}: {2}", connectedUser.username, connectedUser.discriminator, connectedUser.userId));

        UpdatePresence();
    }

    private void UpdatePresence()
    {
        if (!connected) { return; }

        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "mainMenu":
                presence.details = "At the main menu";
                break;
            case "main":
                presence.details = "In singleplayer\n";

                presence.state = "Score: " + ((int)Mathf.RoundToInt(GameManager.Instance.score)).ToString().PadLeft(8, '0');

                long epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

                presence.endTimestamp = epoch + (long)(GameManager.Instance.timeLeft * 1000);
                break;
            default:
                presence.details = "";
                break;
        }

        presence.largeImageKey = "logo";
        DiscordRpc.UpdatePresence(presence);
    }

    public void DisconnectedCallback(int errorCode, string message)
    {
        Debug.Log(string.Format("Discord: disconnect {0}: {1}", errorCode, message));
    }

    public void ErrorCallback(int errorCode, string message)
    {
        Debug.Log(string.Format("Discord: error {0}: {1}", errorCode, message));
    }

}
