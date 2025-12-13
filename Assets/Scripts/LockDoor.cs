using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockDoor : MonoBehaviour
{[SerializeField] collect player;
    TextMeshPro text;
    [SerializeField] int coins;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet")) {
            if (player.coins >= coins) {
                text.enabled = false;
                player.open = true;

            }
            else {
                text.enabled = true;
                text.text = "Te faltan " + (coins - player.coins) + "monedas para abrir la puerta";
                StartCoroutine("disenableText");

            }
        }
    }

    IEnumerator disenableText()
    {
        yield return new WaitForSeconds(5);
        text.enabled = false;
        yield return null;
    }
}
