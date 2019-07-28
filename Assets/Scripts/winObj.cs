using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winObj : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<sceneLoader>().LoadLevel(2);
    }
}
