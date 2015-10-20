using UnityEngine;
using System.Collections;

public class BeatSystem : MonoBehaviour{

    public AudioClip clip;
    private AudioSource thisAudioSource;

    public int bpm;

    public static float beatRateMaster = 1;
    public static float beatRateCurrent = 0;

    private static float beatSpeed = 0.518481123120817f;

    void Awake()
    {
        thisAudioSource = this.GetComponent<AudioSource>();
        thisAudioSource.clip = clip;

        thisAudioSource.Play();

        beatSpeed = bpm / 60;
        //Debug.Log("BPM: " + beatSpeed);
    }

    public static bool SetTheBeat()
    {
        if (beatRateCurrent >= beatRateMaster)
        {
            beatRateCurrent = 0;
            return true;
        }
        
        beatRateCurrent += (beatSpeed * Time.deltaTime);
        return false;
    }
}
