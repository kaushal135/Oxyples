using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardLogic : MonoBehaviour
{
    public float damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<OxygenLogic>().decreaseOxygen(damageAmount);
        collision.gameObject.GetComponent<PlayerLogic>().StartCoroutine("FlashPlayer");
    }

}
