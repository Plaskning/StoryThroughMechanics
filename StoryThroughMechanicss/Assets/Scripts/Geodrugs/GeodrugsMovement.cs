using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeodrugsMovement : MonoBehaviour
{

    public Collider2D boxCollider;
    private Rigidbody2D rb2D;
    public float moveSpeed;
    public Vector2 vel;
    public bool canMove = false;
    Vector2 vecGravity;
    private GameObject spawnPoint;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;



    [Header("Yellow")]
    [SerializeField] public bool canYellow;
    [SerializeField] float yellowDuration;
    [SerializeField] float yellowForwardPower;
    [SerializeField] float yellowUpwardPower;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
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
            canYellow = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(YellowAbility());
            }
        }
        if (isDead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        DevCommands();
    }
    public void Move()
    {
        rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
    }

    public IEnumerator YellowAbility()
    {
        

        canYellow = false;
        float originalGravity = rb2D.gravityScale;
        rb2D.gravityScale = 0f;



        rb2D.velocity = new Vector2(transform.localScale.x * yellowForwardPower, transform.localScale.y * yellowUpwardPower);
        yield return new WaitForSeconds(yellowDuration * 0.2f);
        rb2D.gravityScale = 2f;
        rb2D.velocity = new Vector2(transform.localScale.x * (yellowForwardPower * 1f), transform.localScale.y * (yellowUpwardPower * 0.8f));
        yield return new WaitForSeconds(yellowDuration * 0.2f);
        rb2D.gravityScale = 3f;
        rb2D.velocity = new Vector2(transform.localScale.x * (yellowForwardPower * 1f), transform.localScale.y * (yellowUpwardPower * 0.6f));
        yield return new WaitForSeconds(yellowDuration * 0.2f);
        rb2D.velocity = new Vector2(transform.localScale.x * (yellowForwardPower * 1f), transform.localScale.y * (yellowUpwardPower * 0.5f));
        yield return new WaitForSeconds(yellowDuration * 0.2f);
        rb2D.velocity = new Vector2(transform.localScale.x * (yellowForwardPower * 1f), transform.localScale.y * (yellowUpwardPower * 0.4f));
        yield return new WaitForSeconds(yellowDuration * 0.2f);


        //trailRenderer.emitting = false; //Testing if it should be until grounded or not
        rb2D.gravityScale = originalGravity;
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
    }
}
