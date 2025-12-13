using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] int UnlockRequirement = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UnlockRequirement <= GoldManager.instance.GoldCount)
        {
            Destroy(gameObject);
        }
    }
}
