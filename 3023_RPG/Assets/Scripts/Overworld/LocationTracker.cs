using UnityEngine;

public class LocationTracker : MonoBehaviour
{
    public static LocationTracker Instance { get; private set; }

    public string PlayerLocation { get; private set; }

    public int LocationIndex { get; private set; }

    public Vector2 PlaceInScene { get; private set; } = Vector2.zero;

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

    public void SavePlaceInScene(Vector2 place)
    {
        PlaceInScene = place;
    }

    public void SaveLocationIndex(int index)
    {
        LocationIndex = index;
    }
}
