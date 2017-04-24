using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public float force = 1000.0f;

    Vector3 very_initial_position;
    Vector2 initial_position;
    Vector2 final_position;

    Rigidbody2D myRigidbody;


	// Use this for initialization
	void Start () {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        very_initial_position = this.transform.position;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.position = very_initial_position;
            myRigidbody.isKinematic = true;
            this.transform.rotation = Quaternion.identity;
        }
    }

    void OnMouseDown()
    {
        initial_position = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if (myRigidbody.isKinematic)
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 10.0f);
    }

    void OnMouseUp()
    {
        final_position = Input.mousePosition;

        Vector2 movement = initial_position - final_position;
        //Debug.Log(movement.normalized);

        if (myRigidbody.isKinematic)
        {
            myRigidbody.isKinematic = false;
            myRigidbody.AddRelativeForce(movement.normalized * force);
        }
    }
}
