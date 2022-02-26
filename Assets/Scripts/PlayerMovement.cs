using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum players{
    player1,
    player2
    }
    // Start is called before the first frame update
    public Rigidbody2D myRigidBody;
    public int speed;
    public int jumpForce;
    public BoxCollider2D boxCollider;
    public LayerMask Player2Layer;
    public LayerMask Player1Layer;
    public LayerMask layerMask;
    public Animator animator;
    public SpriteRenderer spriteRendere;
    public GameManager gManager;
    public players curPlayer;

    int jumpCount = 2;
    bool canJumpP2 = false;
    void Start()
    {
        if (curPlayer == players.player1)
        {
            Physics2D.IgnoreLayerCollision(0, 6);
            Physics2D.IgnoreLayerCollision(0, 8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0;
        if (curPlayer == players.player1)
        {
            direction = Input.GetAxis("LettersHorizontal");
        }
        else
        {
            direction = Input.GetAxis("ArrowsHorizontal");
            if (gManager.jumpCount >= 6)
            {
                canJumpP2 = true;
                gManager.jumpCount = 0;
            }

        }


        myRigidBody.velocity = new Vector2(speed * direction, myRigidBody.velocity.y);

        animator.SetFloat("PlayerSpeed",Mathf.Abs(direction));
        if (direction > 0)
        {
            spriteRendere.flipX = false;
        }
        else if(direction < 0)
        {
            spriteRendere.flipX = true;
        }
        if (curPlayer == players.player1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded() ))
            {

                myRigidBody.AddForce(new Vector2(speed * direction, jumpForce));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) && (isGrounded() ) && canJumpP2)
            {

                myRigidBody.AddForce(new Vector2(speed * direction, jumpForce));
                jumpCount--;
                if(jumpCount ==0)
                {
                    canJumpP2 = false;
                }
                
            }

        }

            animator.SetBool("jumping", !isGrounded());
    }


    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,1.0f,layerMask);

         

        return hit.transform != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (curPlayer == players.player1)
        {
            if (collision.gameObject.tag == "Gem")
            {
                gManager.gems.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                gManager.score++;
                gManager.jumpCount++;

            }
            if (collision.gameObject.tag == "WinP1")
            {
                gManager.P1_ready = true;
                
            }
            if(collision.gameObject.tag == "Door")
            {
                
                gManager.changeCameraView(this);
            }

        }
        else
        {
            if (collision.gameObject.tag == "WinP2")
            {
                gManager.P2_ready = true;
               
            }
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            gManager.RestartGame();
        }
    }

}
