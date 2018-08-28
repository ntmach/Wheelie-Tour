using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {
    private Rigidbody2D myRigidBody;
    public float moveSpeed;
    public float jumpHeight;
    public float fallSpeed;
    public KeyCode jumpKey;
    public KeyCode fallKey;
    private CircleCollider2D collide;
    public float secondsTilSolidFall;
    public float secondsTilSolidJump;
    public float jumpCooldown;
    public float fallCooldown;
    private float jumpTimeStamp;
    private float fallTimeStamp;
    bool inAir = false;
    bool touchingBottomLane = false;
    public Text distanceText;
    public Text menuDistanceText;
    private Vector2 positionTchStart, direction;
    bool swiped;
    

    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        collide = GetComponent<CircleCollider2D>();
    }
	
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if (Input.GetKeyUp(jumpKey) && jumpTimeStamp <= Time.time && fallTimeStamp <= Time.time && inAir == false)
        {
            jump();
        }

        if (Input.GetKeyUp(fallKey) && jumpTimeStamp <= Time.time && fallTimeStamp <= Time.time && inAir == false && touchingBottomLane == false)
        {
            fall();
        }
        if (Input.touchCount > 0)
        {
            swipe();
        }
        
        positionXToString();
    }
    
    // Figures out whether there is a swipe up or down
    void swipe()
    {
        Touch touch = Input.GetTouch(0);
        switch(touch.phase)
        {
            // Initial touch position
            case TouchPhase.Began:
                positionTchStart = touch.position;
                swiped = false;
                break;
            // touch position moved
            case TouchPhase.Moved:
                direction = touch.position - positionTchStart;
                break;
            // touch end
            case TouchPhase.Ended:
                swiped = true;
                break;
        }

        if(swiped)
        {
            // swiped up
            if (direction.y > positionTchStart.y && jumpTimeStamp <= Time.time && fallTimeStamp <= Time.time && inAir == false)
            {
                jump();
            }
            else if (direction.y < positionTchStart.y
                && jumpTimeStamp <= Time.time && fallTimeStamp <= Time.time && inAir == false && touchingBottomLane == false)
            {
                fall();
            }
            
        }
    }

    void jump()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y + jumpHeight);
        jumpTimeStamp = Time.time + jumpCooldown;
        fallTimeStamp = Time.time + jumpCooldown;
        touchingBottomLane = false;
        StartCoroutine(jumpPhaseTime());
    }

    void fall()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y - fallSpeed);
        fallTimeStamp = Time.time + fallCooldown;
        jumpTimeStamp = Time.time + fallCooldown;
        StartCoroutine(fallPhaseTime());
    }

    // phase for set time.
    IEnumerator fallPhaseTime()
    {
        inAir = true;
        collide.enabled = false;
        yield return new WaitForSeconds(secondsTilSolidFall);
        collide.enabled = true;
        inAir = false;
    }
    // phase for set time.
    IEnumerator jumpPhaseTime()
    {
        inAir = true;
        collide.enabled = false;
        yield return new WaitForSeconds(secondsTilSolidJump);
        collide.enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inAir = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        inAir = false;
        if (collision.gameObject.tag == "Bottom Lane")
        {
            touchingBottomLane = true;
        }
    }

    // turn off player control
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
        if (collision.gameObject.tag == "Hazard")
        {
            moveSpeed = 0;
            inAir = true;
        }
    }

    // updates the text object - displays the distance player has run.
    void positionXToString()
    {
        distanceText.text = "Distance: " + Math.Round(transform.position.x, 0,
            MidpointRounding.AwayFromZero) + "m";
        menuDistanceText.text = "Distance: " + Math.Round(transform.position.x, 0,
            MidpointRounding.AwayFromZero) + "m";
    }
}
