using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int smoothing;//velocidad de seguimiento de la c�mara
    Vector3 refPosition;
    [SerializeField] float smoothTime;
    [SerializeField] float cameraSpeed;
    float h, v;
    float distance;//distancia inicial que hay entre la c�mara y el player
    void Start()
    {
        distance = Vector3.Distance(transform.position, player.position);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Aqu� se suele calcular la posici�n de la c�mara
    void LateUpdate()
    {
       

        //Muevo la c�mara
        
        //SimpleMove();
        Controlled();
    }



    void SimpleMove() {
        //posici�n a la que quiero mover la c�mara
        transform.position = player.position - transform.forward * distance;
    }

    void Controlled() {
        h = -Input.GetAxis("Mouse X");
        v = -Input.GetAxis("Mouse Y"); ;
        SimpleMove();
        transform.Translate(new Vector3(h*cameraSpeed*Time.deltaTime,v*cameraSpeed* Time.deltaTime, 0));
        transform.LookAt(player);
    }
}
