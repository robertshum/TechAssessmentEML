using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [Header("Color change after hovering for 'x' seconds")]
    public float timeBeforeChange = 3;

    private SpriteRenderer m_SpriteRenderer;
    private bool isThereCircleContact = false;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageColor();
    }

    private void ManageColor()
    {
        if (isThereCircleContact)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }

        //this will change the color of the square EVERY 3 seconds.
        //assumption: requirements did not say if it changes just once or continuously.
        if (currentTime >= 3)
        {
            m_SpriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            currentTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constants.TAG_CIRCLE)
        {
            isThereCircleContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Constants.TAG_CIRCLE)
        {
            isThereCircleContact = false;
        }
    }
}
