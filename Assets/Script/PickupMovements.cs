using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovements : MonoBehaviour
{
    float speed = 100.0f;
    //float speedHover = 5.0f;
    //float height = 5.0f;
    //float frequency= 1.0f;
    //float amplitude= 0.5f;
    float timer = 0;
    Rigidbody rigidBody;

    Vector3 movement = new Vector3(0, 1, 0);
    //Vector3 posOffset = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*Quaternion deltaRoation = Quaternion.Euler(new Vector3(0, 1, 0) * Time.fixedDeltaTime * speed);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRoation);*/

        // to rotate 
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        
        // to hover up and down
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            movement = -1 * movement;
        }
        transform.Translate(movement * Time.deltaTime);

    }
}
