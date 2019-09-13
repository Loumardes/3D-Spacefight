using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // display size
    private float sHeight;
    private float sWidth;

    // mouse pos
    private float mHeight;
    private float mWidth;

    // ship stats
    public bool is_drived;

    //public Sstats shipstats = new Sstats();
    //private Sstats sstats;

    public float shipSpeed;
 //   shipSpeed = sstats.ShipSpeed;
    public float acceleration = 0.1f;

    public float pitch = 2f;
    public float yaw = 2f;
    public float roll = 2f;


    private Vector2 mousePos;


    public float ShipSpeed;
    private float moveSpeed;
    private Vector2 direction;
    private Vector3 movement;

    

    // Start is called before the first frame update
    void Start()
    {
        sHeight = Screen.height / 2;
        sWidth = Screen.width / 2;


        moveSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_drived)
        {
            // Throttle Control
            if (Input.GetKey("z") & moveSpeed <= ShipSpeed)
            {
                moveSpeed += acceleration;
            }

            if (Input.GetKey("s") & moveSpeed >= 0f)
            {
                moveSpeed -= acceleration;
            }
        }

        //moving forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (is_drived)
        {
            direction = Input.mousePosition;
            mHeight = direction.y - sHeight;
            mWidth = direction.x - sWidth;

            transform.Rotate(new Vector3(0f, mWidth * pitch * Time.deltaTime, 0f));
            transform.Rotate(new Vector3(-mHeight * yaw * Time.deltaTime, 0f, 0f));
            // Direction Control
            if (Input.GetKey("q"))
            {
                transform.Rotate(new Vector3(0f, 0f, 50 * roll * Time.deltaTime));
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(new Vector3(0f, 0f, -50 * roll * Time.deltaTime));
            }
        }
    }
}
