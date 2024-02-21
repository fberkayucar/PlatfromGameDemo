using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    CanvasController canvasController;

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
        canvasController = FindObjectOfType<CanvasController>();
        Debug.Log(GlobalVariables.currentLevel);
        PlayerManager.Instance.GetPlayer();
    }


    public void RestartLevel()
    {
        canvasController.RestartTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        canvasController.LevelCompleted();
        canvasController.RestartTimer();
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
