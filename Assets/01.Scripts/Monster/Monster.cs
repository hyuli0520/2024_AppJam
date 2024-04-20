using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{

    [Header("수치")]
    [SerializeField] private float _stopTime;
    [SerializeField] private float _stunTime;

    public bool _isStop = false;
    public Vector3 _curPos;

    private Player _player;
    private MainHp _main;
    private bool _isAtt = false;
    private bool _isMiss = false;
    private bool _isAttMain = false;

    private void Awake()
    {
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _main = FindObjectOfType<MainHp>();

        _isStop = false;
        StartCoroutine(MonsterMove());
        StartCoroutine(DamageToPlayer());
        StartCoroutine(DamageToMain());
    }

    IEnumerator MonsterMove()
    {

        while (true)
        {
            yield return new WaitForSeconds(_stopTime);

            if (!_isStop)
            {
                Vector3 toPlayer = (_main.transform.position - transform.position).normalized;

                if (toPlayer.x > 0)
                    toPlayer.x = Mathf.Ceil(toPlayer.x);
                else
                    toPlayer.x = Mathf.FloorToInt(toPlayer.x);
                toPlayer *= 2;
                toPlayer.y = 0;

                transform.position += toPlayer;
                _isStop = false;
            }
        }
    }

    private void Update()
    {
        _curPos = transform.position;
        StopRay();
    }

    private void StopRay()
    {
        float dis = Vector3.Distance(_main.transform.position, transform.position);
        float playerDis = Vector3.Distance(_player.transform.position, transform.position);

        if (playerDis < 3f && !_isMiss)
        {
            _isStop = true;
            _isAtt = true;
        }
        else if (dis < 3f)
        {
            //게임 종료
            _isStop = true;
            _isAttMain = true;
        }
        else
            _isStop = false;
    }

    IEnumerator DamageToMain()
    {
        while (true)
        {
            yield return new WaitUntil(() => _isAttMain);
            yield return new WaitForSeconds(_stunTime);

            SceneManager.LoadScene("Ending");

            yield break;
        }
    }

    IEnumerator DamageToPlayer()
    {
        while (true)
        {
            yield return new WaitUntil(() => _isAtt);
            yield return new WaitForSeconds(_stunTime);

            _player.Damage();
            _isMiss = true;

            yield break;
        }
    }
}
