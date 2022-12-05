using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    Quaternion leftside;
    Quaternion FrontSide;
    [SerializeField] float MoveSpeed;
    [SerializeField] float LerpValue;
    [SerializeField] float DriftFrowardSpeed;

    [SerializeField] bool survive;

    int speedcounter = 0;

    public bool grounded = false;
    public bool GroundPlay = false;
    [SerializeField] float groundHeight = 2;


    [SerializeField] AudioClip[] AudioClips;

    AudioSource As;
     
    void Start()
    {
        //  rb = GetComponent<Rigidbody>();

        As = GetComponent<AudioSource>();
        leftside.eulerAngles = new Vector3(0, 90, 0);
        FrontSide.eulerAngles = new Vector3(0, 0, 0);


        if (survive) 
        {
            InvokeRepeating("SpeedUp", 0, 8);
        }

    }

    void groundcheck() 
    {
        grounded = (Physics.Raycast(transform.position, Vector3.down, groundHeight /*LayerMask.NameToLayer("Ground")*/));
        if (!grounded) 
        {
            GroundPlay = true;
        }
        if (grounded && GroundPlay) 
        {
            GroundPlay = false;
            As.clip = AudioClips[0];

            As.Play();
          
        }
        
    }


    IEnumerator ClipPlayDelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        GroundPlay = true;
    }

    void SpeedUp()
    {
        speedcounter++;
        Debug.Log("xx");
        MoveSpeed = (MoveSpeed * 100) / 95;
        DriftFrowardSpeed = (DriftFrowardSpeed * 100) / 95;
        LerpValue = LerpValue + 0.003f;
        if (speedcounter > 20)
            CancelInvoke("SpeedUp");
    }


    void Movement() 
    {

       
        if (Input.GetMouseButton(0)) 
        {
            transform.position += new Vector3(MoveSpeed, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, leftside, LerpValue);
            if (transform.eulerAngles.y < 85) 
            {
                transform.position += new Vector3(0, 0, DriftFrowardSpeed);
            }
        }
        else 
        {
            transform.position += new Vector3(0, 0, MoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, FrontSide, LerpValue);
            if (transform.eulerAngles.y >5)
            {
                transform.position += new Vector3(DriftFrowardSpeed, 0, 0);
            }
        }


    }



    void Update()
    {
        Movement();
        groundcheck();

        if (Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadScene(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin") 
        {

            Debug.Log("COOOIN");

            other.gameObject.transform.GetChild(0).transform.gameObject.SetActive(true);
            other.gameObject.transform.GetChild(1).transform.gameObject.SetActive(false);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
        }
    }

}
