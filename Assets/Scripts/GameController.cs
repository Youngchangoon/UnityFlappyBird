using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();

                if(_instance == null)
                {
                    Debug.LogError($"Not have {nameof(GameController)} in scene!");
                }
            }
            return _instance;
        }
    }


    [SerializeField] private UIController uiManager;
    [SerializeField] private SpikeManager spikeManager;

    private int _curScore;

    private void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Time.timeScale = 1f;

        _curScore = 0;
        spikeManager.Init();
        uiManager.Init();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;

        var bestScore = GetAndRecordBestScore(_curScore);
        uiManager.ShowResultPopup(_curScore, bestScore);
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int addingScore)
    {
        _curScore += addingScore;
        uiManager.UpdateScore(_curScore);
    }

    private int GetAndRecordBestScore(int score)
    {
        var bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        return bestScore;
    }
}
