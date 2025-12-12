using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{[SerializeField] Transform[] rockPositions;
    [SerializeField]GameObject rockPrefab;
   // [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LaunchRocks");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator LaunchRocks() {
        Transform point;
        for(; ; ) {
            point = rockPositions[UnityEngine.Random.Range(0, rockPositions.Length)];
            GameObject rock=Instantiate(rockPrefab, point.position, transform.rotation);
            Destroy(rock, 20);
            yield return new WaitForSeconds(2f);
        }
    }
}
