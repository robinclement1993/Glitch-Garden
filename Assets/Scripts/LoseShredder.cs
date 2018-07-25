using UnityEngine;
using System.Collections;

public class LoseShredder : MonoBehaviour {
	private LevelManager levelManager;
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D() {
		levelManager.LoadLevel("03b_Lose");
	}
}
