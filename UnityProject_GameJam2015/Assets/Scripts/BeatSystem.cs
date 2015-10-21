using UnityEngine;
using System.Collections;

public class BeatSystem : MonoBehaviour{

    public AudioClip clip;
    private static AudioSource thisAudioSource;

    public int bpm;
    public static double bps;

    public static float beatCounter = 0;

    private static float beatSpeed = 10;

    public static float speed;
    //public float speedAux;

    public static bool beatNow = false;

    void Awake()
    {
        thisAudioSource = this.GetComponent<AudioSource>();
        thisAudioSource.clip = clip;

        //Beats per second
        bps = ((double)1 / ((double)bpm / (double)60));

        speed = CrossMultiply(bpm, 120, 240, 15, 30);

        Debug.Log("BPS: " + bps);

        StartBeatSystem();

    }

    void Start()
    {

    }

    void FixedUpdate()
    {

        beatNow = SetTheBeat();
        
    }
    
    //Beat Now!
    private static bool SetTheBeat()
    {
        beatCounter += Time.fixedDeltaTime;
        //Debug.Log(beatCounter += Time.fixedDeltaTime);
        
        if (beatCounter > bps)
        {
            Debug.Log("Beat!");
            beatCounter = 0;

            return true;
        }
        
        return false;
    }

    public void StartBeatSystem()
    {
        thisAudioSource.Play();
        beatCounter = 0;

    }

    public static float CrossMultiply(float value, float inMin, float inMax, float outMin, float outMax)
    {

        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
