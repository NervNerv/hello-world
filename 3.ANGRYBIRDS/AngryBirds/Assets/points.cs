using UnityEngine;
using System.Collections;

public class points : MonoBehaviour {

    public float height = 8.0f;

    Vector3 initial_position;

	// Use this for initialization
	void Start () 
    {
        initial_position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.up * Time.deltaTime * height;

        if (initial_position.y + height <= this.transform.position.y)
            Destroy(this.gameObject);
	}
}
