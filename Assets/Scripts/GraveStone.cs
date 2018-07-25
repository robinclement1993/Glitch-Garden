using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {

	private Animator anim;
	
	void Start() {
		anim = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.GetComponent<Attacker>()){
			anim.SetTrigger("underAttack Trigger");
		}
	}
}
