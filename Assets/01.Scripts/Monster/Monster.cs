using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] private Transform _main;

    [Header("수치")]
    [SerializeField] private float _stopTime;
    [SerializeField] private float _stunTime;
    [SerializeField] private float _jumpPower;

    private RaycastHit2D hit;
    private bool _isStop;

    private void Start()
    {
        StartCoroutine(MonsterMove());
    }

    IEnumerator MonsterMove()
    {
        while (true)
        {
            yield return new WaitWhile(() => _isStop);
            yield return new WaitForSeconds(_stopTime);

            if(!_isStop)
            {

            Vector3 toPlayer = (_main.position - transform.position).normalized;

            toPlayer *= 3;
            toPlayer.y = 0;

            transform.position += toPlayer;
            _isStop = false;
            }
            //transform.DOJump(toPlayer, _jumpPower, 1, 0.3f)
            //        .SetEase(Ease.OutQuad);

        }
    }

    private void Update()
    {
        StopRay();
    }

    private void StopRay()
    {
        Vector3 toPlayer = (_main.position - transform.position).normalized;
        toPlayer.y = 0;
        Vector3 newVec = new Vector3(toPlayer.x * 0.6f, 0, 0);
        print(toPlayer);
        hit = Physics2D.Raycast(transform.position + newVec, toPlayer, 10f);
        Debug.DrawRay(transform.position + newVec, toPlayer, Color.red, 1f);

        if (hit)
        {
            if (hit.rigidbody.TryGetComponent(out Player player))
                player.Damage();

            if(hit.rigidbody.CompareTag("Main"))
            {
                //게임 종료 경우
            }

            _isStop = true;
        }
    }
}
