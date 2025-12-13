using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Back()
    {
        SceneManager.LoadScene("StartScene");
    }
}
