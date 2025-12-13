using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance { get; private set; }

    public int GoldCount { get; private set; } = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int moreGold)
    {
        GoldCount += moreGold;
    }
}
