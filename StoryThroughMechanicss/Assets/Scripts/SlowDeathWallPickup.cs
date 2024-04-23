using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDeathWallPickup : MonoBehaviour
{
    private GameObject startDeathWall;
    private DeathWall _deathwall;
    private float originalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startDeathWall = GameObject.FindGameObjectWithTag("StartDeathWall");
        startDeathWall.TryGetComponent(out DeathWall deathwall);
        _deathwall = deathwall;
        originalSpeed = _deathwall.speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TimedSlow());
        }
    }

    private IEnumerator TimedSlow()
    {
            _deathwall.speed = 0.75f;
            yield return new WaitForSeconds(3);
            _deathwall.speed = originalSpeed;
            Destroy(gameObject);
    }
}
