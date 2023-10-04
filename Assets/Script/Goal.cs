using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("HAHHAHA");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("HALuu");
            GameManager.Instance.LoadNextLevel();
            //Debug.Log("YOU WIN!!");
        }
    }
}
