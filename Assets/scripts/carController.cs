using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    public float carSpeed;
    public float maxPos = 2.2f;

    Vector3 position;
    public uiManager ui;

    // Use this for initialization
    Rigidbody2D rb;
    bool currntPlatformAndroid = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        currntPlatformAndroid = true;
    }
	void Start () {
       
        position = transform.position;
        if (currntPlatformAndroid == true)
        {
            Debug.Log("Android");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currntPlatformAndroid == true)
            { }
        else {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);

            transform.position = position;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
        transform.position = position;

    }
        
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            ui.gameOverActivated();
         
        }
    }

    void TouchMove()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            float middle = Screen.width / 2;

            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }

        }

        else
        {
            SetVelocityZero();
        }

    }

    public void MoveLeft() {
        rb.velocity = new Vector2(-carSpeed, 0);
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }
    public void SetVelocityZero()
    {
        rb.velocity =Vector2.zero;
    }


}
