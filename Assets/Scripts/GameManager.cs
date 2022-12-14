using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Camera [] camaras;
    [SerializeField] private PlayerController playerController;



    // Start is called before the first frame update
    void Start()
    {

        camaras[1].enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {

            if(camaras[0].enabled == true)
            {
                camaras[0].enabled = false;
                camaras[1].enabled = true;

            }else if(camaras[1].enabled == true)
            {
                camaras[0].enabled = true;
                camaras[1].enabled = false;

            }


        }
    }


    private void ChangeCamera() {

        
    
    }

   


}
