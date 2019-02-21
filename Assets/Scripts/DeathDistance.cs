using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDistance : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameController.Instance.GameOver();
        }
    }
}
