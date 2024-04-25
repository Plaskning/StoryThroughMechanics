using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float OriginalGravity = -9.81f;
    public float gravityMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void highGravityMethod()
    {
        StopAllCoroutines();
        StartCoroutine(HighGravity());
    }

    public IEnumerator HighGravity()
    {
        Physics2D.gravity = new Vector2(0, -9.81f * gravityMultiplier);
        yield return new WaitForSeconds(1.25f);
        Physics2D.gravity = new Vector2(0, OriginalGravity);

    }
}
