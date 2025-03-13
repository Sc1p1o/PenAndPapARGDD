using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public DBConnector dbConnection;
    
    private void Awake()
    {
        // Singleton-Setup
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dbConnection = gameObject.AddComponent<DBConnector>();
        
        dbConnection.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
