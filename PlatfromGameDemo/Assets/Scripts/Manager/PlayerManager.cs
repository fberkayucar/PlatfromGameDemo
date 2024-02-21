using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    private GameObject player;
    public Vector2 initialPlayerPosition = new Vector2(-8, -3);
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
        if (player == null)
        {
            SpawnPlayer();
        }
    }
    private void SpawnPlayer()
    {
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), initialPlayerPosition, Quaternion.identity);
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
