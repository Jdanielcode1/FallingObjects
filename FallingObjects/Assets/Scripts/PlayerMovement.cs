using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;
    private SpriteRenderer sr;
    private float Move;

    public Rigidbody2D rb;

    public bool isJumping;
    // Start is called before the first frame update
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //actividor tiempo
        timeR.instanciar.IniciarTiempo();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        if (Move > 0)
        {
            sr.flipX = false;
        }
        else if (Move < 0)
        {
            sr.flipX = true;
        }

        if (transform.position.x <= -12)
        {
            transform.position = new Vector3(-12, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 12)
        {
            transform.position = new Vector3(12, transform.position.y, transform.position.z);
        }



        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }



}
