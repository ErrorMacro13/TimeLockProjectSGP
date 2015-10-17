using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {
	void Update () {
        if (Input.GetKey(KeyCode.Escape)) Application.LoadLevel("MainMenu");
	}
}
