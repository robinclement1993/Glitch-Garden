using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed *Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Health health = collider.GetComponent<Health>();
		if(collider.GetComponent<Attacker>() && health){
			health.DealDamage(damage);
			Destroy(gameObject);
		} else {
			return;
		}
	}
}
