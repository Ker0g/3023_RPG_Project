using UnityEngine;

public class EncounterDecider : MonoBehaviour
{
    [SerializeField] EnemySpawner lakeSpawner;
    [SerializeField] EnemySpawner fieldSpawner;
    [SerializeField] EnemySpawner caveSpawner;
    [SerializeField] EnemySpawner bossSpawner;

    string location = LocationTracker.Instance.PlayerLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        if (location == "Lake")
        {
            Instantiate(lakeSpawner, transform);
        }
        else if (location == "Field")
        {
            Instantiate (fieldSpawner, transform);
        }
        else if (location == "Cave")
        {
            Instantiate(caveSpawner, transform);
        }
        else if(location == "Hub")
        {
            Instantiate(bossSpawner, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
