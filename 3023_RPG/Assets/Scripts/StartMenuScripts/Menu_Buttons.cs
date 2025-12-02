using UnityEngine;
using UnityEngine.UI;

public class Menu_Buttons : MonoBehaviour
{

    [SerializeField] Button newGameButton;
    [SerializeField] Button continueGameButton;
    [SerializeField] GameObject achievementMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newGameButton.onClick.AddListener(StartGame);
        continueGameButton.onClick.AddListener(StartGame);
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HubScene");
    }

    void AchievementMenu()
    {
        achievementMenu.SetActive(true);

    }
}
