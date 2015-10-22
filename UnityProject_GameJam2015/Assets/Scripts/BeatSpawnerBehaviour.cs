using UnityEngine;
using System.Collections;

public class BeatSpawnerBehaviour : MonoBehaviour {

    public GameObject beat1Touch;
    public GameObject beat2Touches;
    public GameObject beatNoTouch;
    //public GameObject enemy;

    //private float lastTime = 0;
    private float timeAccumulator = 0;


    private float constantSpeed = 4;
	// Use this for initialization
	void Start () {
	    

        
	}
	
    void FixedUpdate()
    {
        if (BeatSystem.pause == false)
        {
            /*
            timeAccumulator += Time.fixedDeltaTime;

            if (timeAccumulator > 0.47619)
            {
                //Debug.Log("beat");
                timeAccumulator = 0;
            }*/
            transform.Translate(new Vector3(BeatSystem.speed * Time.fixedDeltaTime, 0, 0));

            if (BeatSystem.beatNow == true)
            {
                //Beat Now! Call your function.
                SpawnBeat();

            }
        }
        
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
        int aux;
        aux = Random.Range(0, 3);

        if(aux == 0)
        {
            Instantiate(beat1Touch, this.transform.position, Quaternion.identity);
            //Destroy(Instantiate(beat1Touch, this.transform.position, Quaternion.identity), 6 * Time.fixedTime);
        }

        else if (aux == 1)
        {
            Instantiate(beat2Touches, this.transform.position, Quaternion.identity);
            //Destroy(Instantiate(beat2Touches, this.transform.position, Quaternion.identity), 6 * Time.fixedTime);
        }

        else
        {
            Instantiate(beatNoTouch, this.transform.position, Quaternion.identity);
            //Destroy(Instantiate(beatNoTouch, this.transform.position, Quaternion.identity), 6 * Time.fixedTime);
        }

        //Instantiate(beatFrame, this.transform.position, Quaternion.identity);

        //lastSpawned.transform.parent = this.transform;
    }
    /*
    private void SpawnEnemy()
    {
        Instantiate(enemy, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
    }
    */
}
