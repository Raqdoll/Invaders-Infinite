using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRowSpawn : MonoBehaviour {

    public Transform enemy;



    // Use this for initialization
    void Start () {
		
        for(int i = 0; i < 8; i++)
        {
            Instantiate(enemy, new Vector3(-i*12f + 50f, 115f, 0f), Quaternion.identity); 
        }





	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
