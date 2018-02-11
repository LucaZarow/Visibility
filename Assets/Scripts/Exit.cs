using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //when reaching the top right area
    IEnumerator OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Finish"))
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Win");
        }
    }
}
