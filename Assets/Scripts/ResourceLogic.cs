using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLogic : MonoBehaviour
{
    public int resourceValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var resourceMgr = collision.gameObject.GetComponent<ResourceManager>();
        if (resourceMgr != null)
        {
            resourceMgr.AddResource(resourceValue);
            Destroy(this.gameObject);
        }

    }

}
