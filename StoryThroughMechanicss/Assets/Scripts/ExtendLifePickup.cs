using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtendLifePickup : MonoBehaviour
{
    private GameObject timeline;
    //[SerializeField] private GridLayoutGroup gridLayoutGroup;
    private GameObject uiTimeline;
    [SerializeField] private RectTransform UITimeline;

    // Start is called before the first frame update
    void Start()
    {
        timeline = GameObject.FindGameObjectWithTag("Timeline");
        //uiTimeline = GameObject.FindGameObjectWithTag("TopGrid");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gridLayoutGroup.cellSize += new Vector2(5, 0);
            timeline.transform.position += new Vector3(5, 0, 0);
            UITimeline.position -= new Vector3(110, 0, 0);
            Destroy(gameObject);
        }
    }
}
