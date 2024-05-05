using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructablePlatform : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;
    [SerializeField] private int drugsUntilDestroyed = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("Gamemanager");
        if (gameManagerObject.TryGetComponent<GameManager>(out GameManager gamemanagerInstance))
        {
            gameManager = gamemanagerInstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.drugsPickedUp >= drugsUntilDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
