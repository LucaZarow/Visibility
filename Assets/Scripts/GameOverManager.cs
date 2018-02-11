using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
	
	//either restarts or exits on click
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene("Main");
		}
		if (Input.GetMouseButtonDown (1)) {
			Application.Quit ();
		}
	}
}
