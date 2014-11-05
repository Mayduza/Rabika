//v1.0
using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class wells : MonoBehaviour {
	private static bool isFirstReset = false;
	private static List<wells_object> wells_objects;
	private static List<List<wells_object>> used;
	private static List<List<wells_object>> unused;
	void Awake () {
		reset ();
	}
	private static void add (wells_object wo) {
		if (!isFirstReset) {
			reset ();
			isFirstReset = true;
		}
		if (wo.wells_object_id == -1||wo.wells_object_id >= wells_objects.Count) {
			wo.wells_object_id = wells_objects.Count;
			wells_objects.Add(wo);
			used.Add(new List<wells_object>());
			unused.Add(new List<wells_object>());
		}
	}
	public static void reset () {
		wells_object[] woA = Resources.FindObjectsOfTypeAll(typeof(wells_object)) as wells_object[];
		foreach (wells_object wo in woA)
			wo.wells_object_id = -1;
		wells_objects = new List<wells_object> ();
		used = new List<List<wells_object>> ();
		unused = new List<List<wells_object>> ();
	}

	public static void destroy (wells_object _wo) {
		_wo.gameObject.SetActive (false);
		used [_wo.wells_object_id].Remove(_wo);
		unused [_wo.wells_object_id].Add (_wo);
	}

	public static wells_object create(wells_object _wo,bool use = true) {
		add (_wo);
		return create(_wo.wells_object_id,use);
	}
	public static wells_object[] create(wells_object _wo,int num,bool use = true) {
		add (_wo);
		return create(_wo.wells_object_id,num,use);
	}
	private static wells_object[] create(int _wo_id,int num,bool use ) {

		wells_object[] _wo = new wells_object[num];
		
		unused[_wo_id].CopyTo(0,_wo,0,Mathf.Min(unused[_wo_id].Count,num));
		unused[_wo_id].RemoveRange(0,Mathf.Min(unused[_wo_id].Count,num));

		for(int i = 0 ; i < _wo.Length ; ++i) {
			if(_wo[i]==null) {
				_wo[i] = GameObject.Instantiate(wells_objects[_wo_id]) as wells_object;
				_wo[i].wells_object_id = _wo_id;
			} //else {
//				PrefabUtility.RevertPrefabInstance(_wo[i].gameObject);
//			}
			_wo[i].gameObject.SetActive(use);

			if(use) {
                //(_wo[i] as bullet).setArm(a);
				_wo[i].init();
			}
		}

		if(use)
			used[_wo_id].AddRange(_wo);
		else
			unused[_wo_id].AddRange(_wo);

		return _wo;

	}
	private static wells_object create(int _wo_id,bool use) {
		wells_object _wo = null;
		if (unused [_wo_id].Count > 0) {
			_wo = unused [_wo_id].GetRange (0, 1) [0];
			//PrefabUtility.RevertPrefabInstance(_wo.gameObject);
			unused [_wo_id].RemoveAt (0);
		} else {
			_wo = GameObject.Instantiate (wells_objects [_wo_id]) as wells_object;
			_wo.wells_object_id = _wo_id;
		}

		_wo.gameObject.SetActive(use);

		if (use) {
			//( _wo as bullet ).setArm(a);
			_wo.init ();
			used [_wo_id].Add (_wo);
		} else {
			unused [_wo_id].Add (_wo);
		}

		return _wo;
	}
}
