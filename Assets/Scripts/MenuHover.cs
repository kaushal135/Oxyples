using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHover : MonoBehaviour
{

    Vector3 startPosition;
    bool goUp;
    float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Time.deltaTime * 0.25f;

        if(Vector3.Distance(startPosition, transform.position) > 0.4)
        {
            if(goUp == true)
            {
                goUp = false;
            }
            else
            {
                goUp = true;
            }
        }

        if(goUp == true)
        {
            transform.Translate(Vector3.up * moveSpeed, Space.World);
        }
        if(goUp == false)
        {
            transform.Translate(Vector3.down * moveSpeed, Space.World);
        }

       
    }
}
