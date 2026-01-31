using LootLocker.Extension.Responses;
using Unity.VisualScripting;
using UnityEngine;

public class pruebacollider : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float moveSpeed;

    public LayerMask CheckPointLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject muebles;
    void Start()
    {


    }

    // Update is called once per frame
    private void Update()
    {
        Move(GetDirection());

        if (Input.GetMouseButton(0))
        {



        }
    }
    private void Move(Vector2 direction)
    {
        _rb.AddForce(direction.normalized * moveSpeed * Time.deltaTime);
    }
    private Vector2 GetDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("holi he colisionado");

        //Tengo que instanciar el checkpoint ocn un ID para que no cuente doble si pasa dos veces por el mismo
        if (collision.gameObject.layer == CheckPointLayer)
        {
            Debug.Log("holi he colisionado verde");
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }


}
