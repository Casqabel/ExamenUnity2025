using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int turnSpeed;
    [SerializeField]
    float jumpForce;
    Rigidbody rb;
    Animator anim;
    AudioSource audioSource;
    Vector3 movement;//voy a guardarme la dirección de movimiento
    Vector3 movementRelative;
    float horizontal,
          vertical;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    Transform rayPos;
    [SerializeField]
    float rayLen;
    [SerializeField]
    LayerMask rayMask;

    Vector3 refRay;
   
    Transform camera;
    bool isGrounded;
    bool jump;
    [SerializeField]
    bool RelativeMovement;
    bool secondJump;


    void Start()
    {
        camera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {   
        InputPlayer();
        Animating();
       
    }
    private void FixedUpdate()
    {
        Ray();
       
            Move();
      
       
        Rotation();
        if (jump) 
        {
            Jump();
            if (secondJump) anim.SetTrigger("secondJump");
            jump = false;
        
        }
    }
    void Jump() {
        rb.AddForce(Vector3.up* jumpForce);
    }
    private void Move()
    { if (RelativeMovement) 
        {
            rb.velocity = new Vector3(movementRelative.x * walkSpeed, rb.velocity.y, movementRelative.z * walkSpeed);
        }
        else 
        {
            rb.velocity = new Vector3(movement.x * walkSpeed, rb.velocity.y, movement.z * walkSpeed); 
        }
       // rb.MovePosition(transform.position + (movement * walkSpeed));
        
    }
  

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");//AD
        vertical = Input.GetAxis("Vertical");//WS
        movement = new Vector3(horizontal, 0, vertical);
        movementRelative = new Vector3(camera.forward.x, 0, camera.forward.z) * vertical + new Vector3(camera.right.x,0, camera.right.z )* horizontal;
        movementRelative.Normalize();
        movement.Normalize();//Normalizar un vector significa que hacemos que su módulo valga 1 (m)
        
        //es decir, es un vector UNITARIO, que solo me da dirección
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || !secondJump)) 
        {
            if (!secondJump)  secondJump = true; 
            jump = true;
        }

    }
    void Animating()
    {
        if (horizontal != 0 || vertical != 0)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);

        anim.SetBool("isGrounded", isGrounded);
    }
    void Rotation()
    {
        Vector3 desiredForward;
        if (RelativeMovement)
        {
            desiredForward = Vector3.RotateTowards(transform.forward, movementRelative, turnSpeed * Time.deltaTime, 0);
        }

        else
        {
            desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0);
        }
        Quaternion rotation = Quaternion.LookRotation(desiredForward);

        rb.MoveRotation(rotation);
    }
    void Ray() 
    {
        if (Physics.Raycast(rayPos.transform.position, Vector3.down, rayLen, rayMask))
        {
            isGrounded = true;
            secondJump = false;
        }
        else {
            isGrounded = false;
        
        }
    }
}
