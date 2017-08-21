using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(down))
        {
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.56f, 3.56f) - speed * Time.deltaTime); 
        }
        if (Input.GetKey(up))
        {
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.56f, 3.56f) + speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(down) && Time.timeScale == 1)
        {
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(up) && Time.timeScale == 1)
        {
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyUp(down))
        {
            GetComponent<AudioSource>().Stop();
        }
        if (Input.GetKeyUp(up))
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
