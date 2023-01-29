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
        var inputXY = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        var direction = new Vector2(inputXY.x, inputXY.y).normalized;
        var velocity = direction * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Translate(velocity * Time.deltaTime);

        var pos = transform.position;
        var playerLimitedPosX = pos.x < -sHWIWU ? -sHWIWU : pos.x > sHWIWU ? sHWIWU : pos.x;
        var playerLimitedPosY = pos.y < -Camera.main.orthographicSize ? -Camera.main.orthographicSize :
            pos.y > Camera.main.orthographicSize ? Camera.main.orthographicSize : pos.y;
        transform.position = new Vector2(playerLimitedPosX, playerLimitedPosY);
    }
}