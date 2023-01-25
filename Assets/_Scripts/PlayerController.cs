using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20;

    private float playerHalfWidth;

    //screenHalfWidthInWorldUnits
    private float sHWIWU;
    [SerializeField] private GameObject[] playerShadows = new GameObject[2];

    void Start()
    {
        playerHalfWidth = transform.localScale.x / 2;
        sHWIWU = (Camera.main.orthographicSize * Camera.main.aspect); //;
        float shadowXPos = transform.position.x + Camera.main.orthographicSize;
        playerShadows[0].transform.position = new Vector2(-sHWIWU*2, transform.position.y);
        playerShadows[1].transform.position = new Vector2(sHWIWU*2, transform.position.y);
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector3.right * velocity * Time.deltaTime);
        if (transform.position.x < -sHWIWU)
        {
            transform.position = new Vector2(sHWIWU, transform.position.y);
        }

        if (transform.position.x > sHWIWU)
        {
            transform.position = new Vector2(-sHWIWU, transform.position.y);
        }
    }
}