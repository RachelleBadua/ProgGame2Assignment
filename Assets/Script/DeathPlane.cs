using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
           Debug.Log("RIP..you fell of the platform");
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
