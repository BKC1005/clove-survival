using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;
    [SerializeField] GameObject bossPrefab;
    public int bosscount = 0;

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
    void BossSpawn()
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * 15;
        GameObject obj2 = Instantiate(bossPrefab);
        obj2.transform.position = spawnPosition;
        StartCoroutine(wait());


    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        bosscount++;
        if (bosscount == 10)
        {
            BossSpawn();
        }
        Spawn();

    }

 
}
