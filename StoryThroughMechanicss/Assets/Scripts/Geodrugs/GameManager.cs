using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float OriginalGravity = -9.81f;
    public float currentGravity = 0;
    public float gravityMultiplier = 1;
    public int drugsPickedUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateDrugStatus()
    {
        drugsPickedUp++;
        gravityMultiplier = (drugsPickedUp * 2) + 1;
    }
    
    public void highGravityMethod()
    {
        UpdateDrugStatus();
        StopAllCoroutines();
        StartCoroutine(HighGravity());
    }

    public IEnumerator HighGravity()
    {
        Physics2D.gravity = new Vector2(0, -2.81f - gravityMultiplier);
        yield return new WaitForSeconds(1.25f);
        Physics2D.gravity = new Vector2(0, OriginalGravity - (gravityMultiplier * 0.1f));
    }
}
