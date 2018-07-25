using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {
	
	private Animator anim;
	private Attacker attacker; 
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		attacker = gameObject.GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		
		//Leave the method if not colliding with defender
		if(!obj.GetComponent<Defender>()){
			return;
		}
		
		if(obj.GetComponent<GraveStone>()){
			anim.SetTrigger("jumpTrigger");
		} else{
			anim.SetBool("isAttacking", true);
			attacker.Attack(obj);
		}
	}
}
