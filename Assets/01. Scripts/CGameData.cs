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

    private IDictionary<int, string> m_dicBoard31Frame1Title;
    private IDictionary<int, string> m_dicMovieTitle;


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

            //SetStage(25001);
            //SetStage(99999999);   // 설정페이지
            SetStage(6);  // 도형 ( 자전거 )
            //SetStage(31001);
            //SetStage(32001);



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

            //Vector3 vecColor = Vector3.zero;
            m_listColor[0] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_00_00", 255), 
                (float)PlayerPrefs.GetInt("CLR_00_01", 255), 
                (float)PlayerPrefs.GetInt("CLR_00_02", 255)));

            m_listColor[1] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_01_00", 240),
                (float)PlayerPrefs.GetInt("CLR_01_01", 0),
                (float)PlayerPrefs.GetInt("CLR_01_02", 0)));

            m_listColor[2] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_02_00", 240),
                (float)PlayerPrefs.GetInt("CLR_02_01", 190),
                (float)PlayerPrefs.GetInt("CLR_02_02", 0)));

            m_listColor[3] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_03_00", 240),
                (float)PlayerPrefs.GetInt("CLR_03_01", 250),
                (float)PlayerPrefs.GetInt("CLR_03_02", 0)));

            m_listColor[4] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_04_00", 165),
                (float)PlayerPrefs.GetInt("CLR_04_01", 210),
                (float)PlayerPrefs.GetInt("CLR_04_02", 0)));

            m_listColor[5] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_05_00", 0),
                (float)PlayerPrefs.GetInt("CLR_05_01", 220),
                (float)PlayerPrefs.GetInt("CLR_05_02", 0)));

            m_listColor[6] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_06_00", 0),
                (float)PlayerPrefs.GetInt("CLR_06_01", 220),
                (float)PlayerPrefs.GetInt("CLR_06_02", 220)));

            m_listColor[7] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_07_00", 90),
                (float)PlayerPrefs.GetInt("CLR_07_01", 0),
                (float)PlayerPrefs.GetInt("CLR_07_02", 255)));

            m_listColor[8] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_08_00", 170),
                (float)PlayerPrefs.GetInt("CLR_08_01", 0),
                (float)PlayerPrefs.GetInt("CLR_08_02", 220)));

            m_listColor[9] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_09_00", 200),
                (float)PlayerPrefs.GetInt("CLR_09_01", 0),
                (float)PlayerPrefs.GetInt("CLR_09_02", 200)));

            m_listColor[10] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_10_00", 0),
                (float)PlayerPrefs.GetInt("CLR_10_01", 0),
                (float)PlayerPrefs.GetInt("CLR_10_02", 0)));


            //PlayerPrefs.GetInt()

            //m_listColor[0] = Vec2Clr(new Vector3(255, 255, 255));
            //m_listColor[1] = Vec2Clr(new Vector3(240, 0, 0));   // red
            //m_listColor[2] = Vec2Clr(new Vector3(240, 190, 0));
            //m_listColor[3] = Vec2Clr(new Vector3(240, 250, 0));
            //m_listColor[4] = Vec2Clr(new Vector3(165, 210, 0));
            //m_listColor[5] = Vec2Clr(new Vector3(0, 220, 0));
            //m_listColor[6] = Vec2Clr(new Vector3(0, 220, 220));
            //m_listColor[7] = Vec2Clr(new Vector3(90, 0, 255));
            //m_listColor[8] = Vec2Clr(new Vector3(170, 0, 220));
            //m_listColor[9] = Vec2Clr(new Vector3(200, 0, 200));
            //m_listColor[10] = Vec2Clr(new Vector3(0, 0, 0));

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


            m_dicBoard31Frame1Title = new Dictionary<int, string>();
            m_dicBoard31Frame1Title.Add(0, "곰세마리");
            m_dicBoard31Frame1Title.Add(1, "반짝반짝 작은별");
            m_dicBoard31Frame1Title.Add(2, "나비야");
            m_dicBoard31Frame1Title.Add(3, "산토끼");

            Debug.Log("Init Title");
            m_dicMovieTitle = new Dictionary<int, string>();
            m_dicMovieTitle.Add(0, "1번동영상");
            m_dicMovieTitle.Add(1, "2번동영상");
            m_dicMovieTitle.Add(2, "3번동영상");
            m_dicMovieTitle.Add(3, "4번동영상");
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

    public void SetColor(int nIndex, int nRed, int nGreen, int nBlue)
    {
        m_listColor[nIndex] = Vec2Clr(new Vector3(nRed, nGreen, nBlue));
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

    public string GetBoard31Frame1Title(int nIndex)
    {
        return m_dicBoard31Frame1Title[nIndex];
    }

    public string GetMovieTitle(int nIndex)
    {
        Debug.Log("Movie Title : " + nIndex);
        return m_dicMovieTitle[nIndex];
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
                0, 0,  1, 0, 0,
                0, 1, 0, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("B", new int[]{
                1, 1,  1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("C", new int[]{
                0, 1,  1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("D", new int[]{
                1, 1,  1, 1, 0,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                1, 1,  1, 1, 0,
            });

        m_dicEmoColor.Add("E", new int[]{
                1, 1,  1, 1, 1,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 1,  1, 1, 1,
            });

        m_dicEmoColor.Add("F", new int[]{
                1, 1,  1, 1, 1,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 0,
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
            });

        m_dicEmoColor.Add("G", new int[]{
                0, 1,  1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 1, 1,
                1, 0, 0, 0, 1,
                10, 1,  1, 1, 1,
            });

        m_dicEmoColor.Add("H", new int[]{
                1, 0,  0, 0, 1,
                1, 0,  0, 0, 1,
                1, 0,  0, 0, 1,
                1, 1,  1, 1, 1,
                1, 0,  0, 0, 1,
                1, 0,  0, 0, 1,
                1, 0,  0, 0, 1,
            });

        m_dicEmoColor.Add("I", new int[]{
                0, 1,  1, 1, 0,
                0, 0,  1, 0, 0,
                0, 0,  1, 0, 0,
                0, 0,  1, 0, 0,
                0, 0,  1, 0, 0,
                0, 0,  1, 0, 0,
                0, 1,  1, 1, 0,
            });

        m_dicEmoColor.Add("J", new int[]{
                0, 0, 1, 1, 1,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                0, 1, 1, 0, 0,
            });

        m_dicEmoColor.Add("K", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 1, 0,
                1, 0, 1, 0, 0,
                1, 1, 0, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("L", new int[]{
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 1,
            });

        m_dicEmoColor.Add("M", new int[]{
                1, 0, 0, 0, 1,
                1, 1, 0, 1, 1,
                1, 0, 1, 0, 1,
                1, 0, 1, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("N", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 0, 0, 1,
                1, 0, 1, 0, 1,
                1, 0, 0, 1, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("O", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("P", new int[]{
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
            });

        m_dicEmoColor.Add("Q", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 1, 0, 1,
                1, 0, 0, 1, 0,
                0, 1, 1, 0, 1,
            });

        m_dicEmoColor.Add("R", new int[]{
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 0,
                1, 0, 1, 0, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("S", new int[]{
                0, 1, 1, 1, 1,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                0, 1, 1, 1, 0,
                0, 0, 0, 0, 1, 
                0, 0, 0, 0, 1,
                1, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("T", new int[]{
                1, 1, 1, 1, 1,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
            });

        m_dicEmoColor.Add("U", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("V", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 0, 1, 0,
                0, 0, 1, 0, 0,
            });

        m_dicEmoColor.Add("W", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 1, 0, 1,
                1, 0, 1, 0, 1,
                0, 1, 0, 1, 0,
            });

        m_dicEmoColor.Add("X", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 0, 1, 0,
                0, 0, 1, 0, 0,
                0, 1, 0, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("Y", new int[]{
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 0, 1, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
            });

        m_dicEmoColor.Add("Z", new int[]{
                1, 1, 1, 1, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 1, 0,
                0, 0, 1, 0, 0,
                0, 1, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 1,
            });

        m_dicEmoColor.Add("1", new int[]{
                0, 0, 1, 0, 0,
                1, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                1, 1, 1, 1, 1,
            });

        m_dicEmoColor.Add("2", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 0, 0, 1, 0,
                0, 0, 1, 0, 0,
                0, 1, 0, 0, 0,
                1, 1, 1, 1, 1,
            });

        m_dicEmoColor.Add("3", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 1, 1, 0,
                0, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("4", new int[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 0,
                0, 1, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 1, 1, 1, 1,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
            });

        m_dicEmoColor.Add("5", new int[]{
                1, 1, 1, 1, 1,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 0,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                1, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("6", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("7", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
            });

        m_dicEmoColor.Add("8", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("9", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 1,
                0, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
            });

        m_dicEmoColor.Add("0", new int[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
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

        m_dicEmoColor.Add("E02", new int[]{
                10, 10, 10, 10, 10,
                10, 10, 10, 10, 10,
                6, 6,  10, 6, 6,
                10, 6,  10, 6, 10,
                6, 2,  2, 2, 6,
                6, 6,  2, 6, 6,
                6, 6,  6, 6, 6,
            });

        m_dicEmoColor.Add("E03", new int[]{
                10, 2,  10, 2, 10,
                3, 2,  3, 2, 3,
                10, 10,  3, 10, 10,
                10, 2,  1, 2, 10,
                10, 2,  3, 2, 10,
                10, 10,  3, 10, 10,
                10, 10,  3, 10, 10,
            });

        m_dicEmoColor.Add("E04", new int[]{
                3, 5,  5, 5, 3,
                3, 3, 3, 3, 3,
                5, 10,  3, 10, 5,
                5, 3,  3, 3, 5,
                3, 2,  10, 2, 3,
                3, 3,  3, 3, 3,
                3, 3,  3, 3, 3,
            });

        m_dicEmoColor.Add("E05", new int[]{
                6, 6,  6, 6, 6,
                6, 10,  6, 10, 6,
                6, 6,  6, 6, 6,
                6, 6,  1, 8, 6,
                10, 8,  1, 1, 10,
                10, 8,  8, 1, 1,
                10, 8,  8, 8, 10,
            });

        m_dicEmoColor.Add("E06", new int[]{
                7, 7, 6, 2, 6,
                7, 7, 3, 3, 3,
                7, 3, 3, 10, 3,
                3, 3, 3, 3, 3,
                3, 2, 3, 6, 6,
                3, 2, 3, 6, 6,
                7, 3, 3, 6, 6,
            });

        m_dicEmoColor.Add("E07", new int[]{
                6, 3, 6, 3, 6,
                3, 6, 6, 6, 3,
                3, 6, 6, 3, 6,
                3, 6, 6, 6, 6,
                3, 6, 6, 3, 6,
                3, 6, 6, 6, 3,
                6, 3, 6, 3, 6,
            });

        m_dicEmoColor.Add("E08", new int[]{
                2, 2, 2, 2, 2,
                2, 3, 3, 2, 2,
                3, 3, 10, 3, 2,
                10, 3, 3, 2, 2,
                3, 3, 10, 3, 2,
                2, 3, 3, 2, 2,
                2, 2, 2, 2, 2,
            });

        m_dicEmoColor.Add("E09", new int[]{
                6, 6, 6, 6, 6,
                6, 2, 6, 6, 6,
                3, 3, 3, 1, 6,
                3, 3, 10, 3, 1,
                3, 3, 3, 3, 1,
                3, 3, 3, 3, 1,
                3, 3, 3, 1, 6,
            });

        m_dicEmoColor.Add("E10", new int[]{
                8, 1, 2, 10, 8,
                8, 8, 2, 2, 8,
                2, 2, 2, 3, 8,
                2, 2, 2, 2, 2,
                2, 2, 8, 8, 8,
                2, 2, 8, 8, 8,
                2, 8, 2, 2, 8,
            });

        m_dicEmoColor.Add("E11", new int[]{
                6, 1, 5, 6, 6,
                6, 1, 5, 6, 6,
                5, 5, 10, 5, 6,
                6, 5, 5, 6, 6,
                6, 5, 5, 5, 6,
                5, 5, 5, 6, 6,
                6, 5, 6, 6, 6,
            });

        m_dicEmoColor.Add("E12", new int[]{
                1, 1, 1, 1, 1,
                1, 1, 3, 3, 1,
                1, 3, 3, 3, 3,
                3, 3, 3, 3, 1,
                1, 3, 3, 3, 3,
                1, 1, 3, 3, 1,
                1, 1, 1, 1, 1,
            });

        m_dicEmoColor.Add("E13", new int[]{
                6, 6, 3, 6, 6,
                6, 2, 2, 2, 1,
                1, 2, 10, 2, 1,
                1, 2, 2, 2, 1,
                1, 2, 2, 2, 6,
                6, 6, 2, 6, 6,
                6, 1, 2, 1, 6,
            });

    }
}
