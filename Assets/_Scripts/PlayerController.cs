using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20;


    //screenHalfWidthInWorldUnits
    private float sHWIWU;
    [SerializeField] private GameObject[] playerShadows = new GameObject[2];

    void Start()
    {
        sHWIWU = (Camera.main.orthographicSize * Camera.main.aspect);
        playerShadows[0].transform.position = new Vector2(-sHWIWU * 2, transform.position.y);
        playerShadows[1].transform.position = new Vector2(sHWIWU * 2, transform.position.y);
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        var direction = new Vector2(inputX, inputY).normalized;
        var velocity = direction * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.x < -sHWIWU)
        {
            transform.position = new Vector2(-sHWIWU, transform.position.y);
        }

        if (transform.position.x > sHWIWU)
        {
            transform.position = new Vector2(sHWIWU, transform.position.y);
        }
        
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            transform.position = new Vector2(transform.position.x, -Camera.main.orthographicSize);
        }

        if (transform.position.y > Camera.main.orthographicSize)
        {
            transform.position = new Vector2(transform.position.x, Camera.main.orthographicSize);
        }
    }
}