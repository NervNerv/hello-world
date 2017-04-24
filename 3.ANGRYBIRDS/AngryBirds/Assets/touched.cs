using UnityEngine;
using System.Collections;

public class touched : MonoBehaviour {

    public float life = 1000;
    public float life_limit_1 = 0.9f;
    public float life_limit_2 = 0.6f;
    public float life_limit_3 = 0.3f;

    public Sprite sprite_limit_1;
    public Sprite sprite_limit_2;
    public Sprite sprite_limit_3;

    public GameObject explosion;
    public GameObject points;
    public int point_score = 0;

    private float hit_factor = 0.75f;
    private float initial_life;
    SpriteRenderer my_renderer;
    private ScoreManager SM;
    
	// Use this for initialization
	void Start () 
    {
        initial_life = life;
        my_renderer = GetComponent<SpriteRenderer>();
        SM = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (life < life_limit_1 * initial_life &&
            life > life_limit_2 * initial_life)
        {
            my_renderer.sprite = sprite_limit_1;
        }
        else if (life < life_limit_2 * initial_life &&
                 life > life_limit_3 * initial_life)
        {
            my_renderer.sprite = sprite_limit_2;
        }
        else if (life < life_limit_3 * initial_life &&
                 life > 0)
        {
            my_renderer.sprite = sprite_limit_3;
        }
        else if (life <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(explosion).transform.position = transform.position;
            if (points) Instantiate(points).transform.position = transform.position + Vector3.up * 3.0f;
            SM.AddScore(point_score);

            Application.LoadLevel(0);
        }
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        float hit_force = col.relativeVelocity.sqrMagnitude;

        if (hit_force >= 1)
            life -= hit_force * hit_factor;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        float hit_force = col.relativeVelocity.sqrMagnitude;

        if (hit_force >= 1)
            life -= hit_force * hit_factor;
    }

}
