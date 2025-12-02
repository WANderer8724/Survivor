using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecAtack : MonoBehaviour
{
    public GameObject objectToDelete;
    public GameObject player;
    float time = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        objectToDelete.transform.Rotate(0, (500 * Time.deltaTime), 0);

        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(objectToDelete);
        }
    }
}
