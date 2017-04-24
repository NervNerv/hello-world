using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public Text score_text;

	// Use this for initialization
	void Start () 
    {
        score_text.text = score.ToString();     
	}
	

    public void AddScore(int amount)
    {
        score += amount;
        score_text.text = score.ToString();
    }
}
