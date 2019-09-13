using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universal_movement : MonoBehaviour
{
    // display size
    private float Screen_Height;
    private float Screen_Width;

    // mouse pos
    public float Sensitivity = 100;
    private float mHeight;
    private float mWidth;

    private Vector2 direction;

    // keyboard input
    float key_Horizontal;
    float key_Vertical;

    // ship stats
    public Rigidbody Body;

    public bool is_drived;

    public float pitch = 2f;
    public float yaw = 2f;
    public float roll = 2f;

    public float Max_Thrust;
    public float Thrust;
    public float Thrust_change;
    public float Space_Drag;

    void Start()
    {
        Screen_Height = Screen.height / 2;
        Screen_Width = Screen.width / 2;


        Thrust = 0f;
    }
    void FixedUpdate()	// Update à chaque frame physique
    {
        if (is_drived)
        {
            // Throttle Control
            if (Input.GetKey("z") & Thrust <= Max_Thrust)
            {
                Thrust += Thrust_change;
            }

            if (Input.GetKey("s") & Thrust >= 0f)
            {
                Thrust -= Thrust_change;
            }
            Thrust = Mathf.Clamp(Thrust, 0f, Max_Thrust);

            // Direction Control
            direction = Input.mousePosition;
            mHeight = Mathf.Clamp(direction.y - Screen_Height, -Sensitivity, Sensitivity) / Sensitivity;
            mWidth = Mathf.Clamp(direction.x - Screen_Width, -Sensitivity, Sensitivity) / Sensitivity;

            transform.Rotate(new Vector3(0f, mWidth * pitch * Time.deltaTime, 0f));
            transform.Rotate(new Vector3(-mHeight * yaw * Time.deltaTime, 0f, 0f));
            // Direction Control
            if (Input.GetKey("q"))
            {
                transform.Rotate(new Vector3(0f, 0f, roll * Time.deltaTime));
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(new Vector3(0f, 0f, -roll * Time.deltaTime));
            }
        }


        //Vector3 movement = new Vector3(mHorizontal, 0.0f, mVertical);

        Body.AddRelativeForce(0, 0, Thrust, ForceMode.Force);

    }
}
