using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUp : MonoBehaviour
{
    SpriteRenderer sr;
    float timer = 1f;

    bool beamStage1 = true;
    bool beamStage2 = false;
    bool beamStage3 = false;

    public Sprite rising1;
    public Sprite rising2;

    float moveSpeed;
    Vector3 startPosition;

    bool goUp = false;

    public GameObject nice;


    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beamStage1)
        {
            timer = timer - Time.deltaTime;

            if(timer < 0)
            {
                beamStage1 = false;
                beamStage2 = true;
                timer = 3;
            }
        }
        if (beamStage2)
        {
            timer = timer - Time.deltaTime;
            transform.Translate(new Vector3(0, 0.02f, 0));
            sr.sprite = rising1;

            if(timer < 0)
            {
                beamStage2 = false;
                beamStage3 = true;
                startPosition = transform.position;
                timer = 3;
            }
        }
        if (beamStage3)
        {
            sr.sprite = rising2;

            moveSpeed = Time.deltaTime * 0.25f;

            timer = timer - Time.deltaTime;
            
            if (Vector3.Distance(startPosition, transform.position) > 0.4)
            {
                if (goUp == true)
                {
                    goUp = false;
                }
                else
                {
                    goUp = true;
                }
            }

            if (goUp == true)
            {
                transform.Translate(Vector3.up * moveSpeed, Space.World);
            }
            if (goUp == false)
            {
                transform.Translate(Vector3.down * moveSpeed, Space.World);
            }

            if(timer < 0)
            {
                nice.SetActive(true);
            }
           
        }
    }
}
