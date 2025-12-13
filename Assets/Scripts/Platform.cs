using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField]
    Transform[] pointsTransforms;
    Vector3[] points;
    [SerializeField] float speed;
    Vector3 destiny;
    int point;

    // Start is called before the first frame update
    void Awake()
    {
        point = 0;
        points = new Vector3[pointsTransforms.Length];
        for (int i = 0; i < pointsTransforms.Length; i++) {
            points[i] = pointsTransforms[i].position;
        }
        destiny = points[0];

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
        ChangeTarget();
    }

    void ChangeTarget() {
        if (transform.position == destiny) {
            point = (point + 1) % points.Length;
            destiny = points[point];
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
