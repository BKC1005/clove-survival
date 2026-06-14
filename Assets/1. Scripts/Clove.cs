using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clove : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick;
    public GameObject bulletPrefab;
    public Image XPBar;
    public Image HPBar;
    public float hp = 5;
    public float maxhp = 5;
    public int ex = 0;
    public int lv = 0;
    public TMP_Text lvText;
    float exlimit = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Wait());
        lvText.text = "0";
    }
    public void AddExp()
    {
        ex += 1;

        if (ex >= exlimit)
        {
            lv++;
            exlimit = exlimit * 1.5f;
            exlimit = Mathf.Round(exlimit);
            ex = 0;
            lvText.text = lv.ToString();
        }
        XPBar.fillAmount = (float)ex / exlimit;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        HPBar.fillAmount = hp / maxhp;

    }

    // 몬스터 / 데미지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
            
        }
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
