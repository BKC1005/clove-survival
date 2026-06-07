using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float angle = Random.Range(0f, 360f);

        direction = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad)
        );
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = transform.position + (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            Monster mon = collision.GetComponent<Monster>();
            mon.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    public void timer()
    {
        StartCoroutine(timer());
        IEnumerator timer()
        {
            yield return new WaitForSeconds(5f); // 0.5초 기다리기
            Destroy(gameObject);
        }
    }
}
