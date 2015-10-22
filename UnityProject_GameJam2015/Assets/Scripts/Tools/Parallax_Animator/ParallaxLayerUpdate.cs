using UnityEngine;
using System.Collections;

public class ParallaxLayerUpdate : MonoBehaviour {

    public float movementSpeed;
    private float movementSpeedAux;

    private Transform player;

    private Vector2 animatedOffset;

    // Use this for initialization
	void Start () 
    {        
        animatedOffset = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (BeatSystem.pause == false)
        {
            movementSpeedAux = movementSpeed * BeatSystem.CrossMultiply(BeatSystem.speed, 15, 30, 0.1f, 1);
            animatedOffset += new Vector2(0, movementSpeedAux) * Time.deltaTime;
        

            this.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", animatedOffset);
        }
	}
}
