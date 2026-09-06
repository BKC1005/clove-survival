using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject resultcanvas;

    public void OnClickedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void OnClickedRetry()
    {
        SceneManager.LoadScene("Ingame");
    }
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        resultcanvas.SetActive(true);
    }
}
