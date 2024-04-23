using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] public float speed;
    [SerializeField] bool shouldMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove)
            rb.velocity = new Vector2(1 * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
