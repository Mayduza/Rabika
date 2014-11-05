using UnityEngine;
using System.Collections;

public class BulletTypeAMovement : MonoBehaviour
{
    public float speed = 6f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 30f)
            gameObject.SetActive(false); 
    }
}
