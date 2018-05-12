using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

    [SerializeField]
    private GameObject spwan;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject player;

    public int destruction;

    private Spwan spw;
    private GUIText txt;
    private Entety py;

    // Use this for initialization
    void Start() {
        destruction = 0;
        spw = spwan.GetComponent<Spwan>();
        txt = text.GetComponent<GUIText>();
        py = player.GetComponent<Entety>();
    }

    public void deplay() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //int wave = spw.level;
        //txt.text = wave + "\n" + destruction;
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void play() {
        playerCamera.enabled = true;
        mainCamera.enabled = false;
        spw.playing = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        destruction = 0;
        py.Health = 10;
        Debug.Log(playerCamera.enabled);
        Debug.Log(mainCamera.enabled);
        Debug.Log(Cursor.lockState);
        Debug.Log(Cursor.visible);
    }

    public void exit() {
        Application.Quit();
    }
}
