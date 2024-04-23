using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private float VerticalSpeed;
    [SerializeField] private int horizontalSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        //moveVertical *= VerticalSpeed * Time.deltaTime; -110

        rb.velocity = new Vector2(horizontalSpeed, moveVertical * VerticalSpeed);
    }
}
