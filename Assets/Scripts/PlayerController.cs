using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_RotationSpeed;

    Vector3 m_Movement = Vector3.zero;
    private Rigidbody m_Rigidbody;
    private bool isGround = true;
    [SerializeField] float jumpHeight = 0.5f;
    [SerializeField] private LayerMask layerGround;
    private int dbJump = 2;
    private float gravity = 15f;
    private Vector3 gravityVector = -Vector3.up;

    private enum formasGeometricas { CUBO, ESFERA };
    private formasGeometricas formaActual;
    [SerializeField] GameObject[] formasPlayer;


    [SerializeField] GameObject [] plataformas;
    [SerializeField] Transform[] puntosSpawn;
    private Transform puntoReaparicion;


    private int iterator = 0;
    private bool canMove = true;


    [SerializeField]
    private Camera camera;
    private Vector2 input;
    private Vector2 direccion;
    private Vector3 objective;
    private int punto = 0;

    //[SerializeField] private InputActionAsset playerInputsActions;

    private void Start()
    {
        formaActual = formasGeometricas.CUBO;
        m_Rigidbody = GetComponent<Rigidbody>();
        //this.GetComponent<PlayerController>().enabled = false;

    }

    void Update()
    {

        CambioForma();

         
        //rotate
        if (formaActual == formasGeometricas.CUBO)
        {

            if (Input.GetKey(KeyCode.A))
                transform.Rotate(-Vector3.up * m_RotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.up * m_RotationSpeed * Time.deltaTime);

        }

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
        if (Input.GetKeyDown(KeyCode.C))
        {
            gravityVector.y *= -1;
        }


        if (IsGround()) {
            dbJump = 2;
        }


            m_Movement.Normalize();

        //transform.position += m_Movement * m_Speed *Time.deltaTime;

        //objective = camera.ScreenToWorldPoint(Input.mousePosition);
       

    }

    private void FixedUpdate()
    {
        if(m_Movement != Vector3.zero)        
            m_Rigidbody.MovePosition(transform.position + m_Movement * m_Speed * Time.fixedDeltaTime);
       
        AplicarGravedad();


        if(formaActual == formasGeometricas.ESFERA)
        {
            if(canMove == true)
                m_Rigidbody.velocity = new Vector3(0, 0, 3.5f);
        }



    }

    private void Jump()
    {
        m_Rigidbody.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
    }

    private void AplicarGravedad()
    {
        m_Rigidbody.AddForce(gravityVector * gravity, ForceMode.Force);
    }

    private bool IsGround()
    {
        if (formaActual == formasGeometricas.CUBO)
        {
            return Physics.Raycast(transform.position, Vector3.down, formasPlayer[0].GetComponent<BoxCollider>().bounds.extents.y * 2f, layerGround);
        }
        else
        {
            return Physics.Raycast(transform.position, Vector3.down, formasPlayer[1].GetComponent<SphereCollider>().bounds.extents.y * 2f, layerGround);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.GetComponent<PlayerController>().enabled = true;
            iterator = 0;
        }
        if (collision.gameObject.tag == "Trampolin")
        {
            m_Rigidbody.AddForce(Vector2.up * 10, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "Plataforma")
        {
            iterator++;
            if (iterator == 1)
            {
                transform.position = plataformas[0].transform.position;
            }
            else if (iterator == 2) { 
                transform.position = plataformas[1].transform.position;
            }

            //DestroyPlataforma()
           
        }
       

        if (collision.gameObject.tag == "Suelo")
        {
            iterator = 0;
            punto = 0;
        }

      


    }

    private void CambioForma()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {

            if (formasPlayer[0].activeSelf)
            {
                formasPlayer[0].SetActive(false);
                formasPlayer[1].SetActive(true);
                formaActual = formasGeometricas.ESFERA;
            }
            else if (formasPlayer[1].activeSelf)
            {
                formasPlayer[1].SetActive(false);
                formasPlayer[0].SetActive(true);
                formaActual = formasGeometricas.CUBO;


            }
        }






    }






}
