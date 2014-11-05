using UnityEngine;
using System.Collections;

public class BulletA :bullet  {
	public float speed;
    public int damage;
	void FixedUpdate(){
		position.x += Time.fixedDeltaTime*speed;
		transform.position = position;
	}
}
