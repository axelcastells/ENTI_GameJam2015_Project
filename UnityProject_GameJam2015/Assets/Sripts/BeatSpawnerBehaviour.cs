using UnityEngine;
using System.Collections;

public class BeatSpawnerBehaviour : MonoBehaviour {

    private GameObject lastSpawned;
	// Use this for initialization
	void Start () {
	    
        
	}
	
    void FixedUpdate()
    {
        if (BeatSystem.SetTheBeat() == true)
        {
            SpawnBeat();
        }
    }
	// Update is called once per frame
	void Update () {

        this.transform.Translate(new Vector3(BeatSystem.beatRateMaster * Time.deltaTime, 0, 0));
	}

    private void SpawnBeat()
    {
        Debug.Log("BeatSpawn!");
        lastSpawned = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lastSpawned.GetComponent<Renderer>().material.color = Color.blue;
        lastSpawned.transform.position = this.transform.position;

        lastSpawned.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        //lastSpawned.transform.parent = this.transform;
    }
}
