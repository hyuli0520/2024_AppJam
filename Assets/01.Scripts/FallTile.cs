using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTile : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FallingTile());
    }

    private IEnumerator FallingTile()
    {
        while (true)
        {
            yield return new WaitUntil(()=>GameManager.Instance._isEndMusic);
            print("SS");
            GameManager.Instance.ReMoveTile();
            GameManager.Instance._isEndMusic = false;
        }
    }
}
