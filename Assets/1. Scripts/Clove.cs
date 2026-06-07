using System.Collections;
using UnityEngine;

public class Clove : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick;
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shoot();
    }
    void shoot()
    {
        Vector2 bulletPosition = Random.insideUnitCircle.normalized * 15;
        GameObject obj = Instantiate(bullet);
        Bullet timer = FindFirstObjectByType<Bullet>(); 
        timer.timer();

        obj.transform.position = transform.position;
        Bullet bullet2 = obj.GetComponent<Bullet>();

        StartCoroutine(wait());


    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        shoot();

    }


    // Update is called once per frame
    void Update()

    {
        transform.Translate(joystick.Direction * speed * Time.deltaTime);
        
    }
}
