using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        SoundManager.AddSound("planets", Resources.Load<AudioClip>("planets"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("dyskopia", Resources.Load<AudioClip>("dyskopia"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("beach", Resources.Load<AudioClip>("beach"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("venus", Resources.Load<AudioClip>("venus"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("sherbet", Resources.Load<AudioClip>("sherbet"), SoundType.SOUND_MUSIC);
        //SoundManager.AddSound("boundless-blue", Resources.Load<AudioClip>("boundless-blue"), SoundType.SOUND_MUSIC);
        //SoundManager.AddSound("venus", Resources.Load<AudioClip>("venus"), SoundType.SOUND_MUSIC);

        //SoundManager.AddSound("collision", Resources.Load<AudioClip>("collision"), SoundType.SOUND_SFX);
        SoundManager.AddSound("grass step", Resources.Load<AudioClip>("grass step"), SoundType.SOUND_SFX);
        SoundManager.AddSound("hub step", Resources.Load<AudioClip>("hub step"), SoundType.SOUND_SFX);

        SoundManager.PlayMusic("planets");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
