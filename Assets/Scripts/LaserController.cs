using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, speed * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + new Vector2(0, speed * Time.deltaTime));
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Estado Enter, Colidindo com: " + other.gameObject.name);
        Destroy(other.gameObject);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Estado Stay, Colidindo com: " + other.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Estado Exit, Colidindo com: " + other.gameObject.name);
    }
}
