using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{

    GameObject player;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "PlayerTest")
        {
            other.gameObject.GetComponent<OxygenLogic>().PauseDrain();
            
        } 

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.name == "PlayerTest")
        {
            other.gameObject.GetComponent<OxygenLogic>().ResumeDrain();

        }

    }

}
