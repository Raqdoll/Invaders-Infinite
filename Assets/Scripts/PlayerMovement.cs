using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public GameObject ammo;
    public Transform ammoSpawn;
    public Transform ammoSpawn2;
    public Transform ammoSpawn3;
    public Rigidbody rigidbodys;
    public bool trippleShot;
    
    private float nextFire;

    public float fireRate;



    // Use this for initialization
    void Start () {
        StartCoroutine(Bullet());
        
        trippleShot = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        

        Vector3 movement = new Vector3(-Input.GetAxis("Horizontal"),0);
        
        rigidbodys.MovePosition(transform.position + movement);

        
        if (Input.GetButton("Vertical") && Time.time > nextFire && GameController.Instance.gameOver == false && trippleShot == false)
        {
            nextFire = Time.time + fireRate;
            Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);
        }
        if (Input.GetButton("Vertical") && Time.time > nextFire && GameController.Instance.gameOver == false && trippleShot == true)
        {
            nextFire = Time.time + fireRate;
            Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);
            Instantiate(ammo, ammoSpawn2.position, ammoSpawn2.rotation);
            Instantiate(ammo, ammoSpawn3.position, ammoSpawn3.rotation);
            StartCoroutine(Tripple());
            
        }



    }
    IEnumerator Bullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameController.Instance.SpeedupTimerS * 2);
            fireRate = fireRate / GameController.Instance.speedModifier;
        }
    }
    IEnumerator Tripple()
    {
        if(trippleShot == true)
        {
            
            yield return new WaitForSeconds(3);
            trippleShot = false;
            
        }
    }
}
