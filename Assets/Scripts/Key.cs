using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public Door door;

    bool taken = false;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
	}
    int t=0;
	// Update is called once per frame
	void Update () {
        if (GetComponent<Renderer>().enabled == true)
            t++;
        //used for hidden key in Results
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(t);
            t = 0;
        }
        */

	}

    public bool getTaken(){
        return taken;
    }
    //click when visible
    void OnMouseDown(){
        if (GetComponent<Renderer>().enabled == true)
        {
            door.gameObject.SetActive(false);
            gameObject.SetActive(false);
            taken = true;
        }
    }
}
