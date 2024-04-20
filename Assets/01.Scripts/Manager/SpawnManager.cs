using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] private Transform[] _MonsterSpawnPos;
    [SerializeField] private GameObject _monster;

    [Header("수치")]
    [SerializeField] private float _spawnTime;

    private void Start()
    {
        StartCoroutine(MonsterSpawn());
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            //yield return new WaitUntil(() => GameManager.instance.curState == State.InGame);
            yield return new WaitForSeconds(_spawnTime);

            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        int randIdx = Random.Range(0, 2);

        Instantiate(_monster);
        _monster.transform.position = _MonsterSpawnPos[randIdx].position;
    }
}
