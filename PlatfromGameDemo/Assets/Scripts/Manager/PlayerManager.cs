using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Oyuncu nesnesinin spawn edildi�i s�n�f

    private static PlayerManager instance;
    private GameObject player;
    public Vector2 initialPlayerPosition = new Vector2(-8, -3);
    
    //Singleton pattern
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    private void Update()
    {
        //E�er oyuncu yoksa spawn et
        if (player == null)
        {
            SpawnPlayer();
        }
    }
    private void SpawnPlayer()
    {
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), initialPlayerPosition, Quaternion.identity);
    }

    //Oyuncu nesnesini d�nd�r
    public GameObject GetPlayer()
    {
        return player;
    }
}
