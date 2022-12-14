using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFormController : MonoBehaviour
{

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_RotationSpeed;

    Vector3 m_Movement = Vector3.zero;
    private Rigidbody m_Rigidbody;
    private bool isGround = true;
    [SerializeField] float jumpHeight = 3.0f;
    [SerializeField] private LayerMask layerGround;
    private int dbJump = 1;
    [SerializeField] PlayerController playerController;
    //[SerializeField] private InputActionAsset playerInputsActions;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        this.GetComponent<PlayerController>().enabled = false;

    }

    void Update()
    {

        transform.position = playerController.transform.position;

        //rotate
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * m_RotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * m_RotationSpeed * Time.deltaTime);

        m_Movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            m_Movement += transform.forward;
        if (Input.GetKey(KeyCode.S))
            m_Movement -= transform.forward;


        //strafe
        if (Input.GetKey(KeyCode.Q))
            m_Movement -= transform.right;
        if (Input.GetKey(KeyCode.E))
            m_Movement += transform.right;



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (dbJump > 1)
            {
                Jump();
                dbJump--;
            }

        }

        if (IsGround())
            dbJump = 2;


        m_Movement.Normalize();

        //transform.position += m_Movement * m_Speed *Time.deltaTime;
    }

    private void FixedUpdate()
    {
        m_Rigidbody.MovePosition(transform.position + m_Movement * m_Speed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        m_Rigidbody.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
    }


    private bool IsGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().bounds.extents.y * 1f, layerGround);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            dbJump = 2;
            this.GetComponent<PlayerController>().enabled = true;
        }
        if (collision.gameObject.tag == "Trampolin")
        {
            m_Rigidbody.AddForce(Vector2.up * 20, ForceMode.Impulse);
        }
    }
}
