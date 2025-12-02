using TMPro;
using UnityEngine;

public class AchievementPopup : MonoBehaviour
{

    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    public void Popup(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
    }
}
