using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float speed;
    public Rigidbody rigidbodys;
    public GameObject explosion;
   


	
	void Start () {

        rigidbodys.velocity = transform.up * speed;

	}
	
	
	void Update () {

        
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "EnemyBullet")
        {
            GameController.Instance.AddScore(250);
            GameController.Instance.SlowDown();
            Destroy(gameObject);
            Destroy(other.gameObject);  
        }
        else if (other.gameObject.tag == "Enemy")
        {

            GameController.Instance.AddScore(100);

            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
