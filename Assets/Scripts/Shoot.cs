using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    [SerializeField]LayerMask targets;
    Camera camera;
     PlayerMovement playerMovement;
    Vector3 targetPoint;
    [SerializeField]GameObject ammo;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootForce;
    [SerializeField] Transform hand;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targets)) {
                targetPoint = hit.point;
                playerMovement.anim.SetTrigger("shoot");
                playerMovement.Turn(hit.point);
                playerMovement.canMove = false;
                
            
            }
        }
    }

    public void ShootBullet() {
        GameObject ammoShoot=Instantiate(ammo, shootPoint.position, shootPoint.rotation);
        ammoShoot.transform.LookAt(hit.point);
        ammoShoot.GetComponent<Rigidbody>().AddForce(ammoShoot.transform.forward*shootForce);
    
    
    }
}
