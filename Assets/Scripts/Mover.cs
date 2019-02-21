using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour

{
    public GameObject bullet;
    public Transform ammoSpawn;
    


    
    void Start()
    {
        
        StartCoroutine(Move());
        StartCoroutine(Shoot());
    }

    
    void Update()
    {

    }

    IEnumerator Move()
    {
        for (int i = 0; i < 16; i++)
        {
            transform.position += new Vector3(-40f / 16, 0, 0);
            yield return new WaitForSeconds(1 / GameController.Instance.speed);
               
        }

        transform.position += new Vector3(0, -8f, 0);
        yield return new WaitForSeconds(1 / GameController.Instance.speed);
        

        for (int i = 0; i < 16; i++)
        {
            transform.position += new Vector3(40f / 16, 0, 0);
            yield return new WaitForSeconds(1 / GameController.Instance.speed);
               
        }

        transform.position += new Vector3(0, -8f, 0);
        yield return new WaitForSeconds(1 / GameController.Instance.speed);
        

        StartCoroutine(Move());
    }


    IEnumerator Shoot()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.value * 30);

            if (GameController.Instance.gameOver == false)
            {
                Instantiate(bullet, ammoSpawn.position, ammoSpawn.rotation);
            }
        }
    }
}
