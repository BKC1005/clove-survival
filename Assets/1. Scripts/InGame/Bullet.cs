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
            if (mon.doubleDamageCounter > 0)
            {
                mon.TakeDamage(2);
            }
            else
            {
                mon.TakeDamage(1);
            }
            if(Random.Range(0f,100f) < 31f)
            {
                if (AbilityManager.Instance.GetAbility(AbilityName.Meddle).level > 0)
                {
                    mon.SetDoubleDamageCounter(2);
                }
            }
            
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
