using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeodrugsMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Collider2D boxCollider;
    private Rigidbody2D rb2D;
    public float moveSpeed;
    public Vector2 vel;
    public bool canMove = false;
    Vector2 vecGravity;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Yellow")]
    [SerializeField] public bool canJump;
    [SerializeField] float duration; // 0.15
    [SerializeField] float ForwardPower; // 8.2
    [SerializeField] float UpwardPower; // 20


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }

        if (isGrounded())
        {
            canJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke("JumpMethod", gameManager.drugsPickedUp * 0.05f);
            }
        }
        if (isDead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        DevCommands();
    }

    private void JumpMethod()
    {
        StartCoroutine(Jump());
    }

    public IEnumerator Jump()
    {
        canJump = false;
        float originalGravity = rb2D.gravityScale;
        rb2D.gravityScale = 0f;



        rb2D.velocity = new Vector2(transform.localScale.x * ForwardPower, transform.localScale.y * UpwardPower);
        yield return new WaitForSeconds(duration * 0.2f);
        rb2D.gravityScale = 2f;
        rb2D.velocity = new Vector2(transform.localScale.x * (ForwardPower * 1f), transform.localScale.y * (UpwardPower * 0.8f));
        yield return new WaitForSeconds(duration * 0.2f);
        rb2D.gravityScale = 3f;
        rb2D.velocity = new Vector2(transform.localScale.x * (ForwardPower * 1f), transform.localScale.y * (UpwardPower * 0.6f));
        yield return new WaitForSeconds(duration * 0.2f);
        rb2D.velocity = new Vector2(transform.localScale.x * (ForwardPower * 1f), transform.localScale.y * (UpwardPower * 0.5f));
        yield return new WaitForSeconds(duration * 0.2f);
        rb2D.velocity = new Vector2(transform.localScale.x * (ForwardPower * 1f), transform.localScale.y * (UpwardPower * 0.4f));
        yield return new WaitForSeconds(duration * 0.2f);


        //trailRenderer.emitting = false; //Testing if it should be until grounded or not
        rb2D.gravityScale = originalGravity;
    }
    public void Move()
    {
        rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.85f, 0.06f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    bool isDead()
    {
        return Physics2D.OverlapCapsule(transform.position, new Vector2(1.05f, 0.06f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void DevCommands()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !canMove)
        {
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
