using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobileMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    InputActionReference moveActionReference;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = moveActionReference.action.ReadValue<Vector2>();
        rb.linearVelocity = moveDir * moveSpeed;
        Debug.Log(moveDir);
    }

}
