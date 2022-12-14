using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //private Transform m_Target;
    [SerializeField]
    private Transform Anchor;
    [SerializeField]
    private float _sens = 60.0f;

    //[SerializeField] private float mouseSensibility = 0f;

    //private int m_Index = 0;

    //[SerializeField]
    //private Vector3 m_Offset;

    //
    // 
    public float distance;
    public Vector2 sensitivity;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Update()
    {
        //transform.position = m_Target[m_Index].transform.position + m_Target[m_Index].transform.forward * m_Offset.z + m_Target[m_Index].transform.up * m_Offset.y;
        //transform.LookAt(m_Target[m_Index].transform.position);

        /*if (Input.GetKeyDown(KeyCode.C))
            m_Index = (m_Index + 1) % m_Target.Length;*/

        MoveCamera();
    }



    private void MoveCamera() {

        Vector2 input = MouseInput();

        transform.Rotate(Vector3.up * input.x * _sens * Time.deltaTime);

        Vector3 angle = Anchor.eulerAngles;
        angle.x += input.y * _sens * Time.deltaTime;
        Anchor.eulerAngles = angle;

    }

    private void LateUpdate()
    {
        

    }


    
    private Vector2 MouseInput()
    {

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector2(x, y);


    }

}
