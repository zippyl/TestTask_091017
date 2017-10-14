using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int hp = 100;
    private int killCount = 0;
    [SerializeField] private Text _hp;
    [SerializeField] private Text _killCount;
    [SerializeField] private GameObject _gameOverPanel, _backHP, _backKillCount;
    [SerializeField] private Animator _animator;
    FPSController fps;

    void Start()
    {
        fps = FindObjectOfType<FPSController>();
        Time.timeScale = 1f;
        _hp.text = "HP: " + hp;
        _killCount.text = "Kill Count: " + killCount;
        StartCoroutine(FindObjectOfType<SceneFader>().Fade(SceneFader.FadeDirection.Out));
    }

    internal void TakeDamage()
    {
        hp -= Random.Range(5, 20);
        LeanTween.scale(_backHP, new Vector3(1.2f, 1.2f, 1.2f), 0.2f)
            .setOnComplete(() => { LeanTween.scale(_backHP, new Vector3(1f, 1f, 1f), 0.2f); });
        _hp.text = "HP: " + hp;
        if (hp <= 0)
        {
            hp = 0;
            _hp.text = "HP: " + hp;
            FindObjectOfType<MainSceneUIController>().GameOver();
        }
    }

    public void UpdateKC()
    {
        KillCount++;
        _killCount.text = "Kill count: " + killCount;
        LeanTween.scale(_backKillCount, new Vector3(1.2f, 1.2f, 1.2f), 0.2f)
            .setOnComplete(() => { LeanTween.scale(_backKillCount, new Vector3(1f, 1f, 1f), 0.2f); });
    }

    public int KillCount
    {
        get
        {
            return killCount;
        }
        set
        {
            killCount = value;
        }
    }
}
