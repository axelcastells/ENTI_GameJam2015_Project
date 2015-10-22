using UnityEngine;
using System.Collections;

public class BeatSystem : MonoBehaviour{

    public AudioClip clip;
    private static AudioSource thisAudioSource;

    public static bool pause = false;

    public int bpm;
    public static double bps;

    public static float beatCounter = 0;

    private static float beatSpeed = 10;

    public static float speed;
    //public float speedAux;

    public static bool beatNow = false;

    void Awake()
    {
        pause = false;

        thisAudioSource = this.GetComponent<AudioSource>();
        thisAudioSource.clip = clip;

        //Beats per second
        bps = ((double)1 / ((double)bpm / (double)60));

        speed = CrossMultiply(bpm, 100, 240, 10, 30);

        Debug.Log("BPS: " + bps);

        StartBeatSystem();

    }

    void Start()
    {
        StartBeatSystem();
    }

    void FixedUpdate()
    {
        if(pause == false)
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

    //Activates and Deactivates a GameObject
    public static void TogglePause(GameObject pauseMenu)
    {
        if(pause == false)
        {
            thisAudioSource.Pause();
            pauseMenu.SetActive(true);
        }

        else if(pause == true)
        {
            thisAudioSource.Play();
            pauseMenu.SetActive(false);
        }

        pause = !pause;
    }

    public static float CrossMultiply(float value, float inMin, float inMax, float outMin, float outMax)
    {

        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
