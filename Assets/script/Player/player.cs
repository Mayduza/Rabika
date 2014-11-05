using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public bullet bullet;
	public float MaxHp;
	protected float currentHp;
	public virtual void shoot(){
		
	}
	public virtual void crashed(float dmg){
		
	}
}
