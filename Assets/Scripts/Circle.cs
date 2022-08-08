using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If we create more shapes (octagon, pentagon, etc) we could could create super/subclasses
//that way we can share re-usable code (such as modifying colors)
public class Circle : MonoBehaviour
{
    //public var to expose in inspector
    [Header("Circle Follow Speed")]
    [Tooltip("How fast the circle follows the cursor")]
    public float moveSpeed;

    [Header("Default color")]
    public Color defaultColor;

    private SpriteRenderer m_SpriteRenderer;
    private List<SpriteRenderer> listOfSquares = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constants.TAG_SQUARE)
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            if (!listOfSquares.Contains(sr))
            {
                listOfSquares.Add(sr);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Constants.TAG_SQUARE)
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            if (listOfSquares.Contains(sr))
            {
                listOfSquares.Remove(sr);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageCursor();
        ManageColor();
    }

    //add the colors together
    //or use the default color based on # of square interactions
    private void ManageColor()
    {
        int numOfSquares = listOfSquares.Count;

        if (numOfSquares == 0)
        {
            m_SpriteRenderer.color = defaultColor;
        }
        else
        {
            Color col = new Color(0, 0, 0);
            foreach (SpriteRenderer sr in listOfSquares)
            {
                col += sr.color;
            }
            m_SpriteRenderer.color = (col / (numOfSquares == 1 ? 1 : numOfSquares - 1));
        }
    }

    //the circle game object will follow the mouse
    private void ManageCursor()
    {
        Vector3 mousePos = Input.mousePosition;

        //takes the pos of the mouse click on screen and converts to world position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
    }
}
