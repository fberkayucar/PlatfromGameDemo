using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 1;

    private void Start()
    {
        PlayerManager.Instance.GetPlayer();
    }

    public void LoadLevel(int levelIndex)
    {

    }

    public void RestartLevel()
    {
        Debug.Log("Aþama2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerManager.Instance.GetPlayer();
    }

    public void LoadNextLevel()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
