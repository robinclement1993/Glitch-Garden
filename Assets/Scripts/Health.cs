using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float health = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0) {
			//Optionally trigger animation of dying
			DestroyObject();
		}
	}
	
	public void DestroyObject(){
		Destroy(gameObject);
	}
}
