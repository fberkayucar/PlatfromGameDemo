using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int currentLevel = 0;

    // Singleton instance oluþturma
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                    DontDestroyOnLoad(instance.gameObject);
                }
            }

            return instance;
        }
    }

    private void Start()
    {
        Debug.Log(currentLevel);
        PlayerManager.Instance.GetPlayer();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerManager.Instance.GetPlayer();
    }

    public void LoadNextLevel()
    {
        Debug.Log("Level Completed!");
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
        PlayerManager.Instance.GetPlayer();
    }

    public void GameStart()
    {
        Debug.Log("Game Started!");
    }
}
