using UnityEngine;
using System.Collections;

public class Keyboard_Control : MonoBehaviour {

   
    

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            if(position.x != -6)
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKey("up"))
        {
            Vector3 position = this.transform.position;
            position.y++;
            if (position.y != 5)
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y--;
            if(position.y != -5)
            this.transform.position = position;
        }
	}
}
