using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] string songKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.PlayMusic(songKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
