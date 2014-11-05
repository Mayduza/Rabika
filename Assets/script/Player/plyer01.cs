using UnityEngine;
using System.Collections;

public class plyer01 : player {
	private float AS = 0.5f;
	private float lastshoot = 0;
	private bool isShooting;
	// Use this for initialization
	public void Start(){
		currentHp = MaxHp;
	}
	public override void shoot(){
		if(isShooting){
			CancelInvoke ("createBullect");
			isShooting = false;
		}else{
			if(Time.realtimeSinceStartup - lastshoot < AS)
				InvokeRepeating ("createBullect", AS, AS);
			else
				InvokeRepeating("createBullect",AS-(Time.realtimeSinceStartup-lastshoot),AS);
			isShooting = true;
		}
	}
	private void createBullect(){
		if (Time.realtimeSinceStartup - lastshoot < AS)
			return;
		wells_object wo = wells.create (bullet);
		wo.GetComponent<bullet> ().setPosition (transform.position);
		wo.gameObject.transform.position = transform.position;
		lastshoot = Time.realtimeSinceStartup;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public override void crashed(float dmg){
		currentHp -= dmg;
		print (currentHp);
	}
}
