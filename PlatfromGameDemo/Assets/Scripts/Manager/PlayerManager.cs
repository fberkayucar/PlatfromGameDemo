using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    private GameObject player;
    public Vector2 initialPlayerPosition = new Vector2(-7, -3);
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


    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), initialPlayerPosition, Quaternion.identity);
        Debug.Log("Player spawned");
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
