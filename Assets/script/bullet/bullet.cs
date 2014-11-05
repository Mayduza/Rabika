using UnityEngine;
using System.Collections;

public class bullet : wells_object {
	public Vector3 position;
	public void setPosition(Vector3 pos ){
		position = pos;
	}
	public void destroy(){
		wells.destroy (this);
	}
}
