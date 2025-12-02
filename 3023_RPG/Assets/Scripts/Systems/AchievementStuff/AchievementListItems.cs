using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListItems : MonoBehaviour
{
    [SerializeField] TMP_Text achievementName;
    [SerializeField] TMP_Text achievementDescription;
    [SerializeField] Image image;
    public bool isDone; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Achievement achievement)
    {
        achievementName.text = achievement.title;
        achievementDescription.text = achievement.description;
        isDone = achievement.achieved;

        if(isDone)
        {
            image.color = Color.green;
        }
    }
}
