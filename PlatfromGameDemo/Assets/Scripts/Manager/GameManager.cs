using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    CanvasController canvasController;

    //Singleton pattern
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
        canvasController = FindAnyObjectByType<CanvasController>();
        PlayerManager.Instance.GetPlayer();
    }
    private void Update()
    {
        if (canvasController == null)
        {
            canvasController = FindAnyObjectByType<CanvasController>();
        }
    }

    //Oyun kontrolleri



    public void RestartLevel()
    {
        if (!GlobalVariables.isFirstLevelPassed)
        {
            canvasController.Destroy();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        GlobalVariables.isFirstLevelPassed = true;
        GlobalVariables.isLevelCompleted = false;
        GlobalVariables.isBerryCollected = false;
        GlobalVariables.currentLevel++;
        PlayerManager.Instance.GetPlayer();
        SceneManager.LoadScene(GlobalVariables.currentLevel);
    }

    

    public void GameStart()
    {
        Debug.Log("Game Started!");
    }
}
