using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour {

    public float speed;
    public Rigidbody rig;
    public GameObject explosion;
    




    void Start()
    {
        
        
        rig.velocity = transform.up * speed;

    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
        else if (other.gameObject.tag == "Player")
        {
            
            GameController.Instance.GameOver();
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}