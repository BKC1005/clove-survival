using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 1;
    public int hp = 10;
    public Transform playerTr;
    public GameObject exPrefab;
    public int expCount=10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Clove player = FindFirstObjectByType<Clove>();
        playerTr = player.transform;

        if (Time.time > 30)
        {
            hp += 5;
            moveSpeed += 0.5f;
        }

        if (Time.time > 60)
        {
            hp += 5;
            moveSpeed += 0.5f;
        }

        if (Time.time > 90)
        {
            hp += 5;
            moveSpeed += 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTr.position, moveSpeed * Time.deltaTime);
    }

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            for(int i  = 0; i < expCount; i++)
            {
                GameObject expObject = Instantiate(exPrefab);
                expObject.transform.position = transform.position + (Vector3)Random.insideUnitCircle;

            }
        }
    }
}
