using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtt : MonoBehaviour
{
    [SerializeField] private float _attDis;

    private float _saveDis = float.MaxValue;
    private float _delaytime = 0;
    private Monster _disMonster;

    private void Start()
    {
     //   StartCoroutine(Att());
    }

    IEnumerator Att()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(_delaytime);

            _delaytime = 0;
            FindNealMonster();
        }
    }

    public void MouseClick()
    {
        print("ss");
        if (Input.GetMouseButtonDown(0))
            FindNealMonster();
    }

    private void FindNealMonster()
    {
        if (!GameManager.Instance._isClick) return;

        foreach (Monster obj in GameManager.Instance._monsters)
        {
            float dis = Vector3.Distance(transform.position, obj._curPos);

            if (dis < _saveDis && dis < _attDis)
            {
                _saveDis = dis;
                _disMonster = obj;
            }
        }

        Die();
    }

    private void Die()
    {
        print(_disMonster);
        //죽는 애니메이션
        if (GameManager.Instance._monsters.Contains(_disMonster))
        {
            GameManager.Instance._monsters.Remove(_disMonster);
            Destroy(_disMonster.gameObject);
        }
    }
}
