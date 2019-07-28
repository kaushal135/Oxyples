using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private float movementThreshold = 0.1f;
    public float moveSpeed = 10f;
    public Joystick joystick;
    private Rigidbody2D rb2D;
    private Animator animator;

    [SerializeField]
    private AudioClip[] sfx;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3();
        moveVector.x = joystick.Horizontal * moveSpeed;
        moveVector.y = joystick.Vertical * moveSpeed;


        if (moveVector.magnitude > movementThreshold)
        {
            //audio
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(sfx[0]);
            }

            rb2D.velocity = moveVector;
            animator.SetFloat("inputX", moveVector.x);
            animator.SetFloat("inputY", moveVector.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            rb2D.velocity = Vector2.zero;
            animator.SetBool("isWalking", false);
        }
    }

    IEnumerator FlashPlayer()
    {
        audioSource.PlayOneShot(sfx[1]);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            renderer.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
    }

}
