using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetBeatRateTool : MonoBehaviour {

    public AudioClip clip;
    // Use this for initialization
    private List<double> beats;

    private float currentBeatRate = 0;

    private bool start = false;

	void Start () {

        beats = new List<double>();
        
    }
	
	// Update is called once per frame
	void Update () {

        currentBeatRate += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Space))
            Push();

        if (Input.GetKeyUp(KeyCode.K))
            FigureOutBPM();
	}

    private void Push()
    {
        beats.Add(currentBeatRate);

        Debug.Log("Beat (" + beats.Count + "): " + currentBeatRate);

        currentBeatRate = 0;
    }

    public double FigureOutBPM()
    {
        double sum = 0;


        foreach (double beat in beats)
        {
            sum += beat;
        }

        Debug.Log(sum /= (beats.Count-1));
        return sum /= beats.Count;
    }
}
