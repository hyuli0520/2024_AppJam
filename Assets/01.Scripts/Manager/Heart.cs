using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Heart : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] private Transform _lHeartSpawnPoint;
    [SerializeField] private Transform _rHeartSpawnPoint;
    [SerializeField] private GameObject _lHeartPrefab;
    [SerializeField] private GameObject _rHeartPrefab;
    [SerializeField] private Transform _lHeart;
    [SerializeField] private Transform _rHeart;
    [SerializeField] private PlayerAtt playerAttack;

    [Header("수치")]
    [SerializeField] private float _createTime;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _distance;

    void Start()
    {
        StartCoroutine(CreateHeart());
    }

    IEnumerator CreateHeart()
    {
        while (true)
        {
            //yield return new WaitUntil(() => GameManager.instance.curState == State.InGame);
            yield return new WaitForSeconds(_createTime);

            CreateHalfHeart();
        }
    }

    private void CreateHalfHeart()
    {
        GameObject left = Instantiate(_lHeartPrefab);
        GameObject right = Instantiate(_rHeartPrefab);

        left.transform.position = _lHeartSpawnPoint.position;
        right.transform.position = _rHeartSpawnPoint.position;

        MoveHeart(left, _lHeart);
        MoveHeart(right, _rHeart);
    }

    private void MoveHeart(GameObject heart, Transform target)
    {
        heart.transform.DOMove(target.position, _moveTime)
            .OnUpdate(() => CalcDistance(heart, target));
    }

    private void CalcDistance(GameObject heart, Transform target)
    {
        float disance = Vector2.Distance(heart.transform.position, target.position);

        if (disance <= 0)
        {
            Destroy(heart);
            GameManager.Instance._isClick = false;
        }
        else if (disance < _distance)
        {
            playerAttack.MouseClick();
            GameManager.Instance._isClick = true;
        }
    }
}
