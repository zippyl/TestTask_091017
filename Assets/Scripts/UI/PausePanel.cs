using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour {

    public GameObject _pauseText, _pausePlay, _pauseExit;

	void OnEnable()
    {
        Time.timeScale = 0.000000000000001f;
        LeanTween.moveLocalY(_pauseText, 100, 0.5f).setEase(LeanTweenType.easeOutBack)
            .setIgnoreTimeScale(true)
            .setOnComplete(() => LeanTween.moveLocalY(_pausePlay, -95, 0.5f).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true)
                .setOnComplete(() => LeanTween.moveLocalY(_pauseExit, -135, 0.5f).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true)));

        Button btn = _pausePlay.GetComponent<Button>();
        btn.onClick.AddListener(()=>
        {
            Time.timeScale = 1f;
            LeanTween.moveY(_pauseText, -65, 0.2f).setEase(LeanTweenType.easeInQuint)
                .setOnComplete(() => LeanTween.moveY(_pausePlay, -105, 0.2f).setEase(LeanTweenType.easeInQuint)
                    .setOnComplete(() => LeanTween.moveY(_pauseExit, -165, 0.2f).setEase(LeanTweenType.easeInQuint)
                        .setOnComplete(() => gameObject.SetActive(false))));
        });
    }
}
