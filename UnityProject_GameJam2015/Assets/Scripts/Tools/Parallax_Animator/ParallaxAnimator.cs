using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ParallaxAnimator : MonoBehaviour {

    public float parallaxMinSpeed;
    public float parallaxMaxSpeed;

    //Sets The size that will have relative to camera view
    public float parallaxLayersWidthScale;
    public float parallaxLayersHeightScale;

    public List<Texture2D> parallaxTextures;

    private GameObject[] parallaxLayers;
	// Use this for initialization
    void Awake()
    {
        parallaxLayers = new GameObject[parallaxTextures.Count];
        parallaxLayers.Initialize();

        for (int i = 0; i < parallaxTextures.Count; i++)
        {
            GameObject parallaxChild = GameObject.CreatePrimitive(PrimitiveType.Quad);
            parallaxChild.name = "ParallaxLayer_" + i;
            parallaxChild.transform.parent = this.gameObject.transform;

            parallaxChild.GetComponent<MeshRenderer>().material.mainTexture = parallaxTextures[i];

            parallaxChild.transform.localPosition = new Vector3(parallaxChild.transform.position.x, parallaxChild.transform.position.y, 
                                                           BeatSystem.CrossMultiply(i, 0, parallaxLayers.Length - 1, 0, 1));

            parallaxChild.GetComponent<MeshRenderer>().material.shader = Shader.Find("Sprites/Diffuse");

            parallaxChild.AddComponent<ParallaxLayerUpdate>();
            parallaxChild.GetComponent<ParallaxLayerUpdate>().movementSpeed = SetParallaxLayerSpeed(i);
        }
    }

    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            parallaxLayers[i] = this.transform.GetChild(i).gameObject;
            parallaxLayers[i].GetComponent<ParallaxLayerUpdate>().movementSpeed = SetParallaxLayerSpeed(i);
        }

        //Rescale
        float height = (Camera.main.orthographicSize * 2.0f);
        float width = (height * Screen.width / Screen.height) * parallaxLayersWidthScale;
        transform.localScale = new Vector3(width, height * parallaxLayersHeightScale, 0.1f);
    }

    #region Auxiliar Functions
    private float SetParallaxLayerSpeed(int index)
    {
        if (parallaxLayers.Length > 1)
        {
            float aux = parallaxLayers.Length - index;
            float aux2 = BeatSystem.CrossMultiply(aux, 1, parallaxLayers.Length, parallaxMinSpeed, parallaxMaxSpeed);

            return aux2;
        }
        else
            return parallaxMaxSpeed;
    }
    #endregion
}