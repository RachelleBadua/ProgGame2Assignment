using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDoubleJump : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerGameObject;
    CharacterMovement character;

    public GameObject particleSystemToSpawn;
    public Transform spawnPoint;

    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        character = (CharacterMovement)playerGameObject.GetComponent(typeof(CharacterMovement));
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("trigger the method!!!");
        
        if (collision.gameObject.tag == "Player")
        {
            HideAndShow(30.0f);
            Instantiate(particleSystemToSpawn, spawnPoint.position, spawnPoint.rotation);
            //gameObject.SetActive(false);
            Debug.Log("DOUBLE JUMP!!!");
            character.DoubleJump();
        }
    }

    private void HideAndShow(float delay)
    {
        gameObject.SetActive(false);
        Invoke(nameof(Show), delay);
    }   

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
