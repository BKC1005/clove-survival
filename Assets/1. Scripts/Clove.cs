using System.Collections;
using UnityEngine;

public class Clove : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick;
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Shoot()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 15, LayerMask.GetMask("Monster"));
        if(cols.Length == 0)
        {
            return;
        }
        Monster closestMon = null;
        float minDistace = float.MaxValue;
        int minIndex = 0;

        for (int a = 0; a < cols.Length; a++)
        {
            float dis = Vector2.Distance(transform.position, cols[a].transform.position);
            if(minDistace >= dis)
            {
                minDistace = dis;
                minIndex = a;
            }
        }

        closestMon = cols[minIndex].GetComponent<Monster>();
        Vector2 direction = (closestMon.transform.position - transform.position).normalized;
        GameObject obj = Instantiate(bulletPrefab);
        Bullet bullet = obj.GetComponent<Bullet>();// 
        bullet.EndTimer();
        bullet.Shoot(direction);
        obj.transform.position = transform.position;
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Shoot();
        }
    }


    // Update is called once per frame
    void Update()

    {
        transform.Translate(joystick.Direction * speed * Time.deltaTime);
        
    }
}
