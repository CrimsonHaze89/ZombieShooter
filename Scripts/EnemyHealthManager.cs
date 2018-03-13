using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthManager : MonoBehaviour {

    ScoreManager scoreToAdd;

    public GameObject bloodEffect;

    public int health;
    public int currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = health;
        scoreToAdd = GameObject.Find("GUIscore").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(currentHealth <= 0)
        {
            DestroyEnemy();
        }
	}

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        scoreToAdd.AddToScoreVOID();
        Debug.Log("One Kill!!!");
    }
}
