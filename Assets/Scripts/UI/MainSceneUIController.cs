using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUIController : MonoBehaviour {

    [SerializeField] private GameObject _mainHP, _mainKillCount, _gameOver, _replay, _exit,
        _gameOverPanel, _pausePanel, _pauseButton;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        Cursor.visible = true;
        LeanTween.moveLocalX(_mainHP, 180, 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocalX(_mainKillCount, -120, 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocalX(_pauseButton, -380, 0.5f).setEase(LeanTweenType.easeOutBack);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            _pausePanel.SetActive(true);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0.0000000000000001f;
        _gameOverPanel.SetActive(true);
        LeanTween.moveLocalY(_gameOver, 100, 0.5f).setEase(LeanTweenType.easeOutBack)
                .setOnComplete(() => LeanTween.moveLocalY(_replay, 0, 0.5f).setEase(LeanTweenType.easeOutBack)
                    .setIgnoreTimeScale(true)
                        .setOnComplete(() => LeanTween.moveLocalY(_exit, -50, 0.5f).setEase(LeanTweenType.easeOutBack)
                            .setIgnoreTimeScale(true)))
            .setIgnoreTimeScale(true);
    }

    public void Pause()
    {
        _pausePanel.SetActive(true);
    }
}
