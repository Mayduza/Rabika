using UnityEngine;
using System.Collections;

public class spawnMonsterCollider : MonoBehaviour {
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "spawn") {
			other.GetComponent<spawn>().OnSpawnMonster();
		}
	}
	void FixedUpdate()
	{
		if (transform.position.z < 0f) {
			transform.position += Vector3.forward;
		} else {
			transform.position += Vector3.back;
		}

	}
}
