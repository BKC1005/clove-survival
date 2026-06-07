using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
            Vector2 spawnPosition = Random.insideUnitCircle.normalized * 15;
            GameObject obj = Instantiate(monsterPrefab);
            obj.transform.position = spawnPosition;
            StartCoroutine(wait());
       

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        Spawn();

    }

 
}
