using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
	public player[] playerList;
	public player currentPlayer;
    private Vector3 position;
    public float speed;
    private Vector3 tempForce;
    // Use this for initialization
    void Start()
    {
		currentPlayer = playerList [0];
		//currentPlayer.GetComponent<SpriteRenderer> ().enabled = false;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.E)) {
				currentPlayer.shoot ();
			}

        if (Input.GetKey(KeyCode.UpArrow))
            position.y += Time.deltaTime * speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            position.y -= Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.LeftArrow))
            position.x -= Time.deltaTime * speed;
        else if (Input.GetKey(KeyCode.RightArrow))
            position.x += Time.deltaTime * speed;
    }
    void FixedUpdate()
    {
        if (position.y > 4.5f)
            position.y = 4.5f;
         if (position.y < -4.5f)
            position.y = -4.5f;
		if (position.z < 0f) {
			position.z = 0.5f;
		} else {
			position.z = -0.5f;
		}
        transform.position = Vector3.Lerp(transform.position, position, Time.fixedDeltaTime * 2f);
    }
	public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "monster") {
			tempForce = getForce() - other.GetComponent<monsterControl>().getForce()*2f;
			tempForce.Normalize();
			position.x -= tempForce.x*4f;
			position.y -= tempForce.y*4f;
			currentPlayer.crashed(other.GetComponent<monsterControl>().crashDmg);
			other.GetComponent<monsterControl>().crashed();
        }
    }
	public Vector3 getForce(){
		tempForce.x = position.x - transform.position.x;
		tempForce.y = position.y - transform.position.y;
		tempForce.Normalize();
		return tempForce;
	}
}
