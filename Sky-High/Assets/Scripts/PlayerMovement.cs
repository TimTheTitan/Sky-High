using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float movementVelocity;

    [SerializeField] private LayerMask environmentLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private int currentHeight;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        currentHeight = 0;
    }

    private void Update()
    {

        //Jump
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        //Adding score based on the player's hight
        if (currentHeight < transform.position.y)
        {
            GameManager.instance.AddScore((int)(transform.position.y - currentHeight));
            currentHeight = (int)transform.position.y;
        }

        Movement();
    }

    private void Movement()
    {
        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-movementVelocity, rigidbody2d.velocity.y);
        }
        else
        {
            //Move right
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody2d.velocity = new Vector2(+movementVelocity, rigidbody2d.velocity.y);
            }
            //This results in stopping the velocity of the player when the A or D keys aren't used
            else
            {
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

    //Jump only when the player is on the ground
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, environmentLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}
