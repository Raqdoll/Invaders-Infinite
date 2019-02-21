using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleUse : MonoBehaviour {

    public PlayerMovement player;
    public GameController gameController;
    private bool inUse;
   

	void Start () {
        inUse = false;
	}
	

	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && gameController.trippleShots > 0 && inUse == false)
        {
            inUse = true;
            player.trippleShot = true;
            gameController.trippleShots -= 1;
            gameController.trippleS.text = "Tripple shots: " + gameController.trippleShots + "\n (Space to use)";
        }
        if (player.trippleShot == false)
        {
            inUse = false;
        }
        
    }
}
