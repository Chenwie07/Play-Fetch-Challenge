using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float dogSpawnDelay = 1.3f; 
    public bool canCall { get; internal set; }

    private void Start()
    {
        canCall = true; 
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canCall)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(CheckTime(dogSpawnDelay)); 
        }
    }
    // this will start immediately you press spacebar, and until after the delay
    // space bar won't call the coroutine because at the moment canCall == false; 
    IEnumerator CheckTime(float delay)
    {
        canCall = false; 
        yield return new WaitForSeconds(delay);
        canCall = true; 
    }
}   
