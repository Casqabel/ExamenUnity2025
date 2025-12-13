using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [SerializeField] Transform doorOpen;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet")) {
            StartCoroutine("OpenDoor");
        }
    }

    IEnumerator OpenDoor() {
        while (transform.position != doorOpen.position) { 
        transform.position = Vector3.MoveTowards(transform.position, doorOpen.position, speed * Time.deltaTime);
        yield return null;
        }
    }
}
