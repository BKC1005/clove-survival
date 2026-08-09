using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 0.8f;
    public int hp = 50;
    public Transform playerTr;
    public GameObject exPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Clove player = FindFirstObjectByType<Clove>();
        MonsterSpawner mm = FindFirstObjectByType<MonsterSpawner>();
        playerTr = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTr.position, moveSpeed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            for(int i  = 0; i < 15; i++)
            {
                GameObject expObject = Instantiate(exPrefab);
                expObject.transform.position = transform.position + (Vector3)Random.insideUnitCircle;

            }
        }
    }
}
