using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool _gameOver;
    public static bool _levelCompleted;

    public GameObject _gameOverPanel;
    public GameObject _levelCompletedPanel;

    public static int _currentLevelIndex;
    public Slider _gameProgressSlider;
    public TextMeshProUGUI _currentLevelText;
    public TextMeshProUGUI _nextLevelText;

    public static int _numberOfPassedRings;

    private void Awake()
    {
        _currentLevelIndex = PlayerPrefs.GetInt("CurrenLevelIndex", 1);
    }

    void Start()
    {
        Time.timeScale = 1;
        _numberOfPassedRings = 0;
        _gameOver = _levelCompleted = false;
    }


    void Update()
    {
        _currentLevelText.text = _currentLevelIndex.ToString();
        _nextLevelText.text = (_currentLevelIndex + 1).ToString();

        int progress = _numberOfPassedRings * 100 / FindObjectOfType<TowerBuilder>()._levelCount;
        _gameProgressSlider.value = progress;
        if (_gameOver)
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene(1);
            }
        }
        if (_levelCompleted)
        {
            Time.timeScale = 0;
            _levelCompletedPanel.SetActive(true);
            if (Input.touchCount > 0)
            {
                PlayerPrefs.SetInt("CurrenLevelIndex", _currentLevelIndex + 1);
                SceneManager.LoadScene(1);
            }
        }
    }
}
