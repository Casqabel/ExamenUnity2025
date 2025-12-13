using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] collect player;
    [SerializeField] Transform doorOpen;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.open) {
            StartCoroutine("OpenDoor");
        }
    }

    IEnumerator OpenDoor()
    {
        player.open = false;
        while (transform.position != doorOpen.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpen.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
