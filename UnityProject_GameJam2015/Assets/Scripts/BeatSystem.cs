using UnityEngine;
using System.Collections;

public class BeatSystem : MonoBehaviour{

    public AudioClip clip;

    public static float beatRateMaster = 1;
    public static float beatRateCurrent = 0;

    private static float beatSpeed = 1;

    void Awake()
    {
        this.GetComponent<AudioSource>().clip = clip;
        this.GetComponent<AudioSource>().Play();
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
