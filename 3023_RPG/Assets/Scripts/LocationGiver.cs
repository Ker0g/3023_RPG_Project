using UnityEngine;

public class LocationGiver : MonoBehaviour
{
    [SerializeField] string location;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LocationTracker.Instance.ChangeLocation(location);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
