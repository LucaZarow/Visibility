using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rigidBody;
    Vector2 velocity;

    void Start(){
        rigidBody = GetComponent<Rigidbody2D> ();
    }

    void Update(){
        velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized * 10;
    }

    void FixedUpdate(){
        rigidBody.MovePosition (rigidBody.position + velocity * Time.fixedDeltaTime);
    }
}

