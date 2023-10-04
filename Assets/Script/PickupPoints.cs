using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour
{
    public GameObject particleSystemToSpawn;
    public Transform spawnPoint;

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("trigger the method!!!");

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("You got a point pickup");
            GameManager.Instance.IncrementScore();
            Instantiate(particleSystemToSpawn, spawnPoint.position, spawnPoint.rotation);
            gameObject.SetActive(false);

        }
    }
}
