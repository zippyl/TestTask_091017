using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int hp = 100;
    private int killCount = 0;
    [SerializeField] private Text _hp;
    [SerializeField] private Text _killCount;
    [SerializeField] private GameObject _gameOverPanel;
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

    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");

        if (Mathf.Abs(v) > 0.1 || Mathf.Abs(h) > 0.1)
        {
            fps.speed = 8;
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isRuning", false);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                fps.speed = 16;
                _animator.SetBool("isRuning", true);
                _animator.SetBool("isWalking", false);
            }
        }
        else
        {
            _animator.SetTrigger("isIdle");
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isRuning", false);
        }
    }

    internal void TakeDamage()
    {
        hp -= Random.Range(5, 20);
        LeanTween.scale(_hp.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.2f)
            .setOnComplete(() => { LeanTween.scale(_hp.gameObject, new Vector3(1f, 1f, 1f), 0.2f); });
        _hp.text = "hp: " + hp;
        if (hp <= 0)
        {
            hp = 0;
            FindObjectOfType<MainSceneUIController>().GameOver();
        }
    }

    public void UpdateKC()
    {
        KillCount++;
        _killCount.text = "Kill count: " + killCount;
        LeanTween.scale(_killCount.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.2f)
            .setOnComplete(() => { LeanTween.scale(_killCount.gameObject, new Vector3(1f, 1f, 1f), 0.2f); });
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
