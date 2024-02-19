using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;
    public Transform initialPlayerPosition;

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
        player = Instantiate(playerPrefab, initialPlayerPosition.position, Quaternion.identity);
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
