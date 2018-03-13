using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Text txt;

    public int score = 0;

	void Start ()
    {
        txt = GetComponent<Text>();
	}
	
	void Update ()
    {
        printScore ();
	}

    public void AddToScoreVOID ()
    {
        score++;
        printScore();
    }

    public void printScore()
    {
        txt.text = "Kills: " + score + "   ";
    }
    

}
