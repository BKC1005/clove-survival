using UnityEngine;

public class Ex : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Clove player = FindFirstObjectByType<Clove>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("add Ex2213123");
        if (collision.tag == "Player")
        {
            Debug.Log("add Ex");
            Clove player = collision.GetComponent<Clove>();
            player.AddExp();
            Destroy(gameObject);
        }
    }
}
