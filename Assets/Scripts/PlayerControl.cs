using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public BulletControl bulletControl;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            bulletControl.CallBulletA(transform.position);
        if (Input.GetKeyDown(KeyCode.S))
            bulletControl.CallBulletB(transform.position);
    }
}
