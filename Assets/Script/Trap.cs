using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Gotta do it again...You touched a trap");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
