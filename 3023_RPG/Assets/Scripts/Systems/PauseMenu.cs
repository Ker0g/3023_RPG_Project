using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] GameObject achievementMenu;
    InputAction pause;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(pause.triggered)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    private void Start()
    {
        pause = inputActions.FindAction("Pause");
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ShowAchievements()
    {
        Debug.Log("Showing Achievements");
        achievementMenu.SetActive(true);
    }
}
