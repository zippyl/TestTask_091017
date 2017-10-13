using UnityEngine;
using UnityEngine.UI;

public class MenuUiController : MonoBehaviour
{

    [SerializeField] private GameObject _menuText, _menuPlay, _menuExit;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        LeanTween.moveLocalY(_menuText, 150, 0.5f).setEase(LeanTweenType.easeOutBack)
                .setOnComplete(() => LeanTween.moveLocalY(_menuPlay, -95, 0.5f).setEase(LeanTweenType.easeOutBack)
                    .setOnComplete(() => LeanTween.moveLocalY(_menuExit, -135, 0.5f).setEase(LeanTweenType.easeOutBack)));

        Button btn = _menuPlay.GetComponent<Button>();
        btn.onClick.AddListener(()=> {
            LeanTween.moveY(_menuText, -65, 0.2f).setEase(LeanTweenType.easeInQuint)
                .setOnComplete(() => LeanTween.moveY(_menuPlay, -105, 0.2f).setEase(LeanTweenType.easeInQuint)
                    .setOnComplete(() => LeanTween.moveY(_menuExit, -135, 0.2f).setEase(LeanTweenType.easeInQuint)));
        });
    }
}
