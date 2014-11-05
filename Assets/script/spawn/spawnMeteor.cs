using UnityEngine;
using System.Collections;

public class spawnMeteor : spawn {

	public override void OnSpawnMonster()
	{	
		wells_object wo = wells.create (monster);
		wo.gameObject.transform.parent = transform.parent;
		wo.gameObject.transform.position = transform.position;
	}
}
