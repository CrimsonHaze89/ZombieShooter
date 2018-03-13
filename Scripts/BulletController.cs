using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damageToGive = 1;

    public ParticleSystem bloodEffect;

    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Destroy (Instantiate(bloodEffect.gameObject, other.transform.position, Quaternion.identity) as GameObject, 4);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
