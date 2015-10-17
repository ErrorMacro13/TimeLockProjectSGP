using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource hover;
    public AudioSource click;
    public AudioSource back;
    public int GameState = 0;
    public static SoundManager ths;
    public string PlayerName = "Cody";
    public static SoundManager Instance { get; private set; }
    float deltaTime = 0.0f;
    public bool DisableFPS = false;
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }
    public Vector3 a;
    void OnGUI()
    {
        if (!DisableFPS)
        {
            int w = Screen.width;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, a.x, w, 30/*h * 2 / 100*/);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = 30;//h * 2 / 100;
            style.normal.textColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
  
    // Use this for initialization
    void Start () {
    }

    void ArcadeState()
    {
        GameState = 1;
    }

    void FreePlayState()
    {
        GameState = 2;
    }

    int GetState()
    {
        return GameState;
    }

    void In()
    {
        click.Play();
    }
    void Out()
    {
        back.Play();
    }
    void Hovered()
    {
        hover.Play();
    }
    void SavePlayersData(PlayersData data)
    {
        data.name = PlayerName;
        data.mode = GameState;
        data.bounceBack.SendMessage("SavePlayersData", data);
    }
}
