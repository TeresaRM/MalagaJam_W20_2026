using UnityEngine;
using static UnityEngine.GridBrushBase;

public class TapeAnimation : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    Vector3 oldForward;
    [SerializeField] private Sprite turningLeft;
    [SerializeField] private Sprite turningRight;
    [SerializeField] private Sprite forward;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        oldForward = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAnimation();
        Debug.Log(rb.angularVelocity);
    }

    void ChooseAnimation()
    {
        Vector3 cross = Vector3.Cross(oldForward, transform.up);

        if (cross.z > 0)
        {
            sprite.sprite = turningLeft;
        }
        else if (cross.z < 0)
        {
            sprite.sprite = turningRight;
        }
        else
        {
            sprite.sprite = forward;
        }

    }
}
