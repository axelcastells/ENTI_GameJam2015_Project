using UnityEngine;
using System.Collections;

public class BeatSpawnerBehaviour : MonoBehaviour {

    public GameObject beatFrame;
    public GameObject enemy;

    //private float lastTime = 0;
    private float timeAccumulator = 0;


    private float constantSpeed = 4;
	// Use this for initialization
	void Start () {
	    

        
	}
	
    void FixedUpdate()
    {
        /*
        timeAccumulator += Time.fixedDeltaTime;
        
        if (timeAccumulator > 0.47619)
        {
            //Debug.Log("beat");
            timeAccumulator = 0;
        }*/
        
        if (BeatSystem.beatNow == true)
        {
            //Beat Now! Call your function.
            SpawnBeat();
            if (Random.Range(0, 6) < 4) SpawnEnemy();

        }
        
    }
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(constantSpeed*Time.deltaTime, 0, 0));
	}

    private void SpawnBeat()
    {
        /*
        GameObject lastSpawned;
        Debug.Log("BeatSpawn!");
        lastSpawned = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lastSpawned.GetComponent<Renderer>().material.color = Color.blue;
        lastSpawned.transform.position = this.transform.position;

        lastSpawned.transform.localScale = new Vector3(0.5f, 1.1f, 3.1f);

        lastSpawned.transform.tag = "Destroyable";
        */
        Instantiate(beatFrame, this.transform.position, Quaternion.identity);

        //lastSpawned.transform.parent = this.transform;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
    }
}
