using UnityEngine;
using System.Collections;

public class monsterControl : wells_object {
	public float crashDmg;
	private Vector3 position;
	public float MaxHp;
	protected float currentHp;
	public float speed;
	private Vector3 tempForce;
	public virtual void init(){
		
	}
	public Vector3 getForce(){
		tempForce.x = position.x - transform.position.x;
		tempForce.y = position.y - transform.position.y;
		tempForce.Normalize();
		return tempForce;
	}
	public virtual void attacked(float dmg,bulletType type){

	}
	public virtual void crashed(){
		
	}
	public void OnTriggerEnter(Collider other){
		if (other.tag == "bullet") {
			other.GetComponent<bullet>().destroy();
			wells.destroy(this);
		}
	}
}
