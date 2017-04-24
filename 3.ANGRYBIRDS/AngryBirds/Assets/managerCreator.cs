using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class managerCreator : MonoBehaviour {

    public GameObject SM = null;
    
	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(this.gameObject);
                
        if (!FindObjectOfType<ScoreManager>())
            Instantiate(SM);

        SM = GameObject.FindGameObjectWithTag("SCORE");

	}
	
	// Update is called once per frame
	void Update () {
	
       
	}
}
