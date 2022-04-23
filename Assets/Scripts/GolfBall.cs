using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GolfBall : MonoBehaviour
{
    // VARS
    private float Force = 0;
    private float MaxForce = 2000;

    public AudioSource Swing;
    public PowerBar powerBar;
    public GameObject Arrow;
    public Rigidbody GolfBallRigidBody;
    public Transform CameraTransform;
    public Transform ArrowTransform;


    // Start is called before the first frame update
    void Start()
    {
        powerBar.SetMaxPower(MaxForce);
        powerBar.SetPower(Force);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {       
        Vector3 ballShotDirection = 
        transform.position - CameraTransform.position;  // Vector Between Ball & Camera
        ballShotDirection.y = 0.0f;                     // Locks Vector parallel to ground, != CameraAngle
        ballShotDirection.Normalize();                  // Locks Force Value, != CameraDistance

        // Link Arrow <-> Ball Position
        ArrowTransform.position = transform.position + ballShotDirection * 0.33f;

        // Make Arrow Face Away From Camera
        float angle = Mathf.Atan2(ballShotDirection.z, ballShotDirection.x) * Mathf.Rad2Deg;
        ArrowTransform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        // Rotate Arrow 90 Degrees Parallel w Ground
        ArrowTransform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));


        // CHARGE SHOT (Space Down)
        if (Input.GetKey(KeyCode.Space))
        {
            if (Force < MaxForce)
            {
                Force += 10;
                powerBar.SetPower(Force);
            }
        }

        // SHOOT BALL (Space Up)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GolfBallRigidBody.AddForce(ballShotDirection * Force);  // Apply Force    
            StrokeCounter.IncreaseStrokeCount();                    // StrokeCount++
            Swing.Play();                                           // Play Sound
            Force = 0;                                              // Reset Force
            powerBar.SetPower(Force);                               // Update UI

        }

        // Turn Arrow Off  
        if (GolfBallRigidBody.velocity.magnitude > 0.02f)   
        {
            Arrow.SetActive(false);                              
        }

        // Turn Arrow On
        if (GolfBallRigidBody.velocity.magnitude < 0.05f)   
        {
            Arrow.SetActive(true);                                  
        }      
        
        // Sleep State if you want to not calculate stuff all the time
    }// END Update


    private void OnTriggerEnter(Collider other)
    {
        // Load Next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        /* SPECIFIC GAME OBJECT COLLISION
        if (other.gameObject.name == "test")
        {
            Debug.Log("Do Stuff");
        }*/
    }// END Trigger

/*
    private void OnCollisionEnter(Collider other)
    {
        Swing.Play();   // Play Sound
    }
    */
    
}