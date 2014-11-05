using UnityEngine;
using System.Collections;

public class BulletTypeBMovement : MonoBehaviour
{
    public float speed = 10f;

    float teta = 90f;
    // Use this for initialization
    void Start()
    {
        //GetComponent<BulletControl>().enabled = true; // false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, Mathf.Sin(teta) * 0.1f, 0f);
        teta += Time.deltaTime;
        if (transform.position.x > 30f)
            gameObject.SetActive(false); 
    }
}
