using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    public Transform[] Decors;
    private float[] parallaxScales;
    public float smoothing;
    public float smooth_y = 0.5f;

    private Vector3 previousCameraPosition;

	// Use this for initialization
	void Start () {

        previousCameraPosition = transform.position;

        parallaxScales = new float[Decors.Length];
        for(int i = 0; i < parallaxScales.Length; i++)
        {

            parallaxScales[i] = Decors[i].position.z * -1;

        }
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
        for(int i = 0; i < Decors.Length; i++)
        {
            Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);

            Decors[i].position = new Vector3(Decors[i].position.x + parallax.x, Decors[i].position.y + parallax.y * smooth_y, Decors[i].position.z);

        }

        previousCameraPosition = transform.position;

	}
}
