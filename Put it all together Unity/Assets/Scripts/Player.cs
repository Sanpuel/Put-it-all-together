using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runspeed = 5f;



    Rigidbody2D myRigidBody;
    Animator myanimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runspeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myanimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
           transform.localScale= new Vector2(2*Mathf.Sign(myRigidBody.velocity.x), 2f);
        }
    } 
}
