using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = (GoldManager.instance.GoldCount.ToString());
    }
}
