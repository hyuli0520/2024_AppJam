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
            if (GameManager.Instance._isClick)
            {
                Vector3 toPlayer = (_main.transform.position - transform.position).normalized;

                if (toPlayer.x > 0)
                    toPlayer.x = Mathf.Ceil(toPlayer.x);
                else
                    toPlayer.x = Mathf.FloorToInt(toPlayer.x);

                toPlayer *= 2;
                toPlayer.y = 0;

                transform.position += toPlayer;
                StopRay();
                yield return new WaitForSeconds(_stopTime);
            }
            yield return null;
        }
    }

    private void Update()
    {
        print(Managers.UI.playerHp);
        _curPos = transform.position;
    }

    private void StopRay()
    {
        float dis = Vector3.Distance(_main.transform.position, transform.position);
        float playerDis = Vector3.Distance(_player.transform.position, transform.position);

        if (playerDis < 3f && !_isMiss)
        {
            _isAtt = true;
        }
        else if (dis < 1f)
        {
            //게임 종료
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
            yield return new WaitUntil(() => GameManager.Instance._isClick);

            //Managers.UI.playerHp--;

            Destroy(this.gameObject);

            if (Managers.UI.playerHp == 0)
            {
                Managers.Scene.LoadScene(Define.Scene.Start);
                yield break;
            }

            yield return new WaitForSeconds(_stopTime);
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
