using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 direction;

    public void Shoot(Vector2 dir)
    {
        direction = dir;
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

    public void EndTimer()
    {
        StartCoroutine(timer());
        IEnumerator timer()
        {
            yield return new WaitForSeconds(5f); // 0.5초 기다리기
            Destroy(gameObject);
        }
    }
}
