using UnityEngine;
using UnityEngine.UI;

public class MenuAchievements : MonoBehaviour
{
    [SerializeField] AchievementListItems achievementItem;
    [SerializeField] Transform content;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnEnable()
    {

        Build();
    }

    void Build()
    {
        

        foreach(var achievement in AchievementManager.achievements)
        {
            var achievementListItem = Instantiate(achievementItem, content);
            achievementListItem.Setup(achievement);
        }
    }

    public void CloseMenu()
    {
        foreach (Transform listItem in content)
        {
            Destroy(listItem.gameObject);
            
        }
        gameObject.SetActive(false);
    }
}
