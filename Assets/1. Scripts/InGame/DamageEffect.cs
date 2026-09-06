using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public void PlayEffect()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        gameObject.SetActive(true);
        Invoke("OffDamageEffect", 0.15f);
    }
    void OffDamageEffect()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
       
    }
}
