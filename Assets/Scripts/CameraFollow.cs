using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int smoothing;//velocidad de seguimiento de la cámara
    Vector3 refPosition;
    [SerializeField] float smoothTime;
    [SerializeField] float cameraSpeed;
    float h, v;
    float distance;//distancia inicial que hay entre la cámara y el player
    void Start()
    {
        distance = Vector3.Distance(transform.position, player.position);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Aquí se suele calcular la posición de la cámara
    void LateUpdate()
    {
       

        //Muevo la cámara
        
        //SimpleMove();
        //Controlled();
    }



    void SimpleMove() {
        //posición a la que quiero mover la cámara
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
