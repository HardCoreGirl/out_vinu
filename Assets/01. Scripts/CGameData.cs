using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEmoColor
{
    public int[] n_listColor = new int[3];
}

public class CGameData : MonoBehaviour
{
    #region SingleTon
    public static CGameData _instance = null;

    public static CGameData Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CGameData install null");

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            _instance = null;
        }
    }
    #endregion

    private int m_nStage = 0;

    private float[] m_listXpoz = new float[9];
    private float[] m_listYpoz = new float[4];

    private float m_fAnswerSpeed = 1f;

    private bool m_bIsLoad = false;

    private int m_nLobbyPage = 0;

    private Color[] m_listColor = new Color[11];

    private int[] m_listA = new int[35];

    private IDictionary<string, int[]> m_dicEmoColor;

    private IDictionary<int, float[]> m_dicNotePosition;
    private float[] m_listNoteIndex;


    private IDictionary<int, int[]> m_dicSong;
    private IDictionary<int, string> m_dicSongTitle;
    private IDictionary<int, string[]> m_dicLyrics;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitGameData()
    {
        if (!m_bIsLoad)
        {
            m_bIsLoad = true;
            GameObject.DontDestroyOnLoad(this);

            SetStage(25001);
            //SetStage(1);
            SetLobbyPage(0);

            m_listXpoz[0] = -3.89f;
            m_listXpoz[1] = -2.91f;
            m_listXpoz[2] = -1.95f;
            m_listXpoz[3] = -0.97f;
            m_listXpoz[4] = 0f;
            m_listXpoz[5] = 0.97f;
            m_listXpoz[6] = 1.95f;
            m_listXpoz[7] = 2.91f;
            m_listXpoz[8] = 3.89f;

            m_listYpoz[0] = 1.45f;
            m_listYpoz[1] = 0.49f;
            m_listYpoz[2] = -0.49f;
            m_listYpoz[3] = -1.45f;

            m_fAnswerSpeed = 1.5f;

            m_listColor[0] = Vec2Clr(new Vector3(255, 255, 255));
            m_listColor[1] = Vec2Clr(new Vector3(240, 0, 0));   // red
            m_listColor[2] = Vec2Clr(new Vector3(240, 190, 0));
            m_listColor[3] = Vec2Clr(new Vector3(240, 250, 0));
            m_listColor[4] = Vec2Clr(new Vector3(165, 210, 0));
            m_listColor[5] = Vec2Clr(new Vector3(0, 220, 0));
            m_listColor[6] = Vec2Clr(new Vector3(0, 220, 220));
            m_listColor[7] = Vec2Clr(new Vector3(90, 0, 255));
            m_listColor[8] = Vec2Clr(new Vector3(170, 0, 220));
            m_listColor[9] = Vec2Clr(new Vector3(200, 0, 200));
            m_listColor[10] = Vec2Clr(new Vector3(0, 0, 0));

            m_dicEmoColor = new Dictionary<string, int[]>();
            LoadEmoColor();

            m_dicNotePosition = new Dictionary<int, float[]>();
            m_dicNotePosition.Add(8, new float[] { -7, -5, -3, -1, 1, 3, 5, 7});
            m_dicNotePosition.Add(10, new float[] { -7.2f, -5.6f, -4f, -2.4f, -0.8f, 0.8f, 2.4f, 4f, 5.6f, 7.2f });
            m_dicNotePosition.Add(12, new float[] { -7.7f, -6.3f, -4.9f, -3.5f, -2.1f, -0.7f, 0.7f, 2.1f, 3.5f, 4.9f, 6.3f, 7.7f });
            m_dicNotePosition.Add(13, new float[] { -7.8f, -6.5f, -5.2f, -3.9f, -2.6f, -1.3f, 0, 1.3f, 2.6f, 3.9f, 5.2f, 6.5f, 7.8f });

            m_listNoteIndex = new float[] { -0.4f, -0.25f, -0.1f, 0.2f, 0.35f, 0.5f, 0.65f, 0.8f };


            m_dicSong = new Dictionary<int, int[]>();
            m_dicSongTitle = new Dictionary<int, string>();
            m_dicLyrics = new Dictionary<int, string[]>();

            m_dicSongTitle.Add(0, "");
            m_dicSong.Add(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            m_dicLyrics.Add(0, new string[] { "", "", "", "", "", "", "", "" });

            m_dicSongTitle.Add(1, "");
            m_dicSong.Add(1, new int[] { 8, 7, 6, 5, 4, 3, 2, 1 });
            m_dicLyrics.Add(1, new string[] { "", "", "", "", "", "", "", "" });
            
            m_dicSongTitle.Add(2, "똑같아요");
            m_dicSong.Add(2, new int[] { 1, 3, 5, 1, 3, 5, 6, 6, 6, 5 });
            m_dicLyrics.Add(2, new string[] { "무", "엇", "이", "무", "엇", "이", "똑", "같", "은", "가" });

            m_dicSongTitle.Add(3, "똑같아요");
            m_dicSong.Add(3, new int[] { 1, 3, 5, 1, 3, 5, 6, 6, 6, 5, 1, 3, 5, 1, 3, 5, 6, 6, 6, 5 });
            m_dicLyrics.Add(3, new string[] { "무", "엇", "이", "무", "엇", "이", "똑", "같", "은", "가", "무", "엇", "이", "무", "엇", "이", "똑", "같", "은", "가" });

            m_dicSongTitle.Add(4, "산토끼");
            m_dicSong.Add(4, new int[] { 1, 3, 5, 1, 3, 5, 6, 6, 6, 5 });
            m_dicLyrics.Add(4, new string[] { "", "", "", "", "", "", "", "" });

            m_dicSongTitle.Add(5, "산토끼");
            m_dicSong.Add(5, new int[] { 1, 3, 5, 1, 3, 5, 6, 6, 6, 5, 1, 3, 5, 1, 3, 5, 6, 6, 6, 5 });
            m_dicLyrics.Add(5, new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });

            m_dicSongTitle.Add(6, "나비야");
            m_dicSong.Add(6, new int[] { 1, 3, 5, 1, 3, 5, 6, 6, 6, 5, 1, 3, 5, 1, 3, 5, 6, 6, 6, 5 });
            m_dicLyrics.Add(6, new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });

        }
    }

    public void SetStage(int nStage)
    {
        m_nStage = nStage;
    }

    public int GetStage()
    {
        return m_nStage;
    }

    public float GetGridXPoz(int nIndex)
    {
        return m_listXpoz[nIndex];
    }

    public float GetGridYPoz(int nIndex)
    {
        return m_listYpoz[nIndex];
    }

    public float GetAnswerSpeed()
    {
        return m_fAnswerSpeed;
    }    

    public void SetLobbyPage(int nPage)
    {
        m_nLobbyPage = nPage;
    }

    public int GetLobbyPage()
    {
        return m_nLobbyPage;
    }

    public Color GetColor(int nIndex)
    {
        return m_listColor[nIndex];
    }

    public int[] GetEmoColor(string strKey)
    {
        return m_dicEmoColor[strKey];
    }

    public Color GetMusicBlockColor(int nBlockIndex)
    {
        int nConvertIndex = 0;
        switch(nBlockIndex)
        {
            case 0: nConvertIndex = 4; break;
            case 1: nConvertIndex = 8; break;
            case 2: nConvertIndex = 3; break;
            case 3: nConvertIndex = 7; break;
            case 4: nConvertIndex = 2; break;
            case 5: nConvertIndex = 6; break;
            case 6: nConvertIndex = 1; break;
            case 7: nConvertIndex = 5; break;
        }

        return GetColor(nConvertIndex);
    }

    public float[] GetNotePoz(int nNoteCount)
    {
        return m_dicNotePosition[nNoteCount];
    }

    public float GetNoteIndex(int nNoteIndex)
    {
        return m_listNoteIndex[nNoteIndex];
    }

    public string GetSongTitle(int nIndex)
    {
        return m_dicSongTitle[nIndex];
    }

    public int[] GetSong(int nIndex)
    {
        return m_dicSong[nIndex];
    }

    public string[] GetLyric(int nIndex)
    {
        return m_dicLyrics[nIndex];
    }

    private Vector3 Clr2Vec(Color clr)
    {
        int r = (int)(clr.r * 255);
        int g = (int)(clr.g * 255);
        int b = (int)(clr.b * 255);

        return new Vector3(r, g, b);
    }

    private Color Vec2Clr(Vector3 vec)
    {
        float r = vec.x / 255;
        float g = vec.y / 255;
        float b = vec.z / 255;

        return new Color(r, g, b);
    }

    private void LoadEmoColor()
    {
        m_dicEmoColor.Add("A", new int[]{
                10, 10,  1, 10, 10,
                10, 1, 10, 1, 10,
                1, 10, 10, 10, 1,
                1, 10, 10, 10, 1,
                1, 1, 1, 1, 1,
                1, 10, 10, 10, 1,
                1, 10, 10, 10, 1,
            });

        m_dicEmoColor.Add("B", new int[]{
                1, 1,  1, 1, 10,
                1, 10, 10, 10, 1,
                1, 10, 10, 10, 1,
                1, 1, 1, 1, 10,
                1, 10, 10, 10, 1,
                1, 10, 10, 10, 1,
                1, 1, 1, 1, 10,
            });

        m_dicEmoColor.Add("C", new int[]{
                10, 1,  1, 1, 10,
                1, 10, 10, 10, 1,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 1,
                10, 1, 1, 1, 10,
            });

        m_dicEmoColor.Add("D", new int[]{
                1, 1,  1, 1, 10,
                10, 1, 10, 10, 1,
                10, 1, 10, 10, 1,
                10, 1, 10, 10, 1,
                10, 1, 10, 10, 1,
                10, 1, 10, 10, 1,
                1, 1,  1, 1, 10,
            });

        m_dicEmoColor.Add("E", new int[]{
                1, 1,  1, 1, 1,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 10,
                1, 1, 1, 1, 10,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 10,
                1, 1,  1, 1, 1,
            });

        m_dicEmoColor.Add("F", new int[]{
                1, 1,  1, 1, 1,
                1, 10, 10, 10, 10,
                1, 1, 1, 1, 10,
                1, 1, 1, 1, 10,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 10,
                1, 10,  10, 10, 10,
            });

        m_dicEmoColor.Add("G", new int[]{
                10, 1,  1, 1, 10,
                1, 10, 10, 10, 1,
                1, 10, 10, 10, 10,
                1, 10, 10, 10, 10,
                1, 10, 10, 1, 1,
                1, 10, 10, 10, 1,
                10, 1,  1, 1, 1,
            });

        m_dicEmoColor.Add("H", new int[]{
                1, 10,  10, 10, 1,
                1, 10,  10, 10, 1,
                1, 10,  10, 10, 1,
                1, 1,  1, 1, 1,
                1, 10,  10, 10, 1,
                1, 10,  10, 10, 1,
                1, 10,  10, 10, 1,
            });

        m_dicEmoColor.Add("I", new int[]{
                10, 1,  1, 1, 10,
                10, 10,  1, 10, 10,
                10, 10,  1, 10, 10,
                10, 10,  1, 10, 10,
                10, 10,  1, 10, 10,
                10, 10,  1, 10, 10,
                10, 1,  1, 1, 10,
            });

        m_dicEmoColor.Add("E01", new int[]{
                5, 6,  6, 6, 5,
                6, 6,  6, 6, 6,
                6, 10,  6, 10, 6,
                6, 6,  6, 6, 6,
                5, 6,  6, 6, 5,
                5, 3,  6, 3, 5,
                5, 5,  6, 5, 5,
            });

    }
}
