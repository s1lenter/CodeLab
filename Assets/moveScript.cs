using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class moveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Renderer boxVisual;
    [SerializeField] private InputField input;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject boxColumn;
    private bool canMoveDown = false;

    private string[] rightAnswer = new string[]
    {
        "int[] blocksY = [10, 20, 30, 40, 50];",
        "for(int i = 0; i < blocks.Length; i++)",
        "{",
        "blocksY[i] -= 1;",
        "}",
    };

    private void Start()
    {
        rb = box.GetComponent<Rigidbody2D>();
        coll = box.GetComponent<BoxCollider2D>();
        boxVisual = box.GetComponent<SpriteRenderer>();
        coll.enabled = false;
        rb.Sleep();
        boxVisual.enabled = false;
    }
    private void Update()
    {
        string[] lines = input.text.Split('\n');

        if (lines[0] == rightAnswer[0])
        {
            coll.enabled = true;
            rb.WakeUp();
            boxVisual.enabled = true;
            if (lines.Length == 5)
            {
                for (int i = 1; i < rightAnswer.Length; i++)
                {
                    if (lines[i] == rightAnswer[i])
                        canMoveDown = true;
                    else
                        canMoveDown = false;
                }
            }
            if (canMoveDown && transform.position.y > boxColumn.transform.position.y + 2)
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.05f);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else
        {
            coll.enabled = false;
            rb.Sleep();
            boxVisual.enabled = false;
        }
    }
}
