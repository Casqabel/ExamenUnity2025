using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomMessage : MonoBehaviour
{
    [SerializeField] string[] mensajes;
    string mensaje;
    TextMeshPro textPro;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        textPro=GetComponent<TextMeshPro>();
        mensaje = mensajes[Random.Range(0, mensajes.Length)];
        textPro.text = mensaje; 
        player=GameObject.Find("Dummy");

    }

    // Update is called once per frame
    void Update()
    {
        textPro.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));

    }
}
