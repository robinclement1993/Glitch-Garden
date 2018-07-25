using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator anim;
	private Spawner myLaneSpawner;
	
	void Start() {
		anim = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		
		
		//Creates a parent if necessary
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}

	void Update () {
		if(IsAttackerAheadInLane()){
			anim.SetBool("isAttacking", true);
		} else {
			anim.SetBool("isAttacking", false);
		}
	}
	

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
	bool IsAttackerAheadInLane() {
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		
		foreach(Transform child in myLaneSpawner.transform){
			if (transform.position.x <= child.transform.position.x) {
				return true;
			}
		}
		return false;
	}
	
	void SetMyLaneSpawner () {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner lanespawner in spawners) {
			if(lanespawner.transform.position.y == transform.position.y){
				myLaneSpawner = lanespawner;
				return;
			}
		}
		Debug.LogError("No spawner found in lane " + transform.position.y);
	}
}
