using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
    public GameObject bulletAPrefab, 
        bulletBPrefab;
    GameObject[] bulletAArray,
        bulletBArray;

    int bulletMaxCount = 25,
        bulletACount = 0, 
        bulletBCount = 0;

    // Use this for initialization
    void Start()
    {
        bulletAArray = new GameObject[bulletMaxCount];
        bulletBArray = new GameObject[bulletMaxCount];

        for (int i = 0; i < bulletMaxCount; i++)
        {
            bulletAArray[i] = Instantiate(bulletAPrefab,
                new Vector3(-100f, -100f, 0f), Quaternion.identity) as GameObject;
            bulletAArray[i].transform.parent = transform;
            bulletAArray[i].SetActive(false);

            bulletBArray[i] = Instantiate(bulletBPrefab,
                new Vector3(-100f, -100f, 0f), Quaternion.identity) as GameObject;
            bulletBArray[i].transform.parent = transform;
            bulletBArray[i].SetActive(false);
        }
    }

    public void CallBulletA(Vector3 pos)
    {
        GameObject bulletSelected = bulletAArray[bulletACount++];
        bulletSelected.transform.position = pos;
        bulletSelected.SetActive(true);
        bulletACount %= bulletAArray.Length;
    }

    public void CallBulletB(Vector3 pos)
    {
        GameObject bulletSelected = bulletBArray[bulletBCount++];
        bulletSelected.transform.position = pos;
        bulletSelected.SetActive(true);
        bulletBCount %= bulletBArray.Length;
    }
}
