using UnityEngine;

public class LocationTracker : MonoBehaviour
{
    public static LocationTracker Instance { get; private set; }

    public string PlayerLocation { get; private set; }

    public int StepsTaken { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeLocation(string location)
    {
        PlayerLocation = location;
    }

    public void Step()
    {
        StepsTaken++;
    }
}
