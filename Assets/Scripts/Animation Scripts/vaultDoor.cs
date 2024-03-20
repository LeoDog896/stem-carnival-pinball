using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaultDoor : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 jump = new Vector2(0, Random.Range(30.0f, 40.0f));
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(jump, ForceMode2D.Impulse);
        Destroy(gameObject, 1);
    }

    
}
