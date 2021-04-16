using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingThings : MonoBehaviour
{
    public Transform grabDetect;
    public Transform turtleHolder;
    public float ray_distance;
    private GameObject carrying;

    // Start is called before the first frame update
    void Start()
    {
        carrying = null;
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit2D taking_the_item_check = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, ray_distance);

        if (taking_the_item_check.collider != null && taking_the_item_check.collider.tag == "trampoline")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                taking_the_item_check.collider.gameObject.transform.parent = turtleHolder;  // it makes Leprechaun parent of the turtle
                taking_the_item_check.collider.gameObject.transform.position = turtleHolder.position;
                taking_the_item_check.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // makes no gravity
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If we are carrying something then drop it otherwise check to see if we should pick up something.
            if (carrying != null)
            {
                carrying.transform.parent = null;
                //carrying.GetComponent<Rigidbody2D>().isKinematic = false; // makes no gravity
                carrying = null;
            }
            else
            {
                RaycastHit2D taking_the_item_check = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, ray_distance);
                if (taking_the_item_check.collider != null && taking_the_item_check.collider.tag == "trampoline")
                {
                    carrying = taking_the_item_check.collider.gameObject;
                    taking_the_item_check.collider.gameObject.transform.parent = turtleHolder;  // it makes Leprechaun parent of the turtle
                    taking_the_item_check.collider.gameObject.transform.position = turtleHolder.position;
                    //taking_the_item_check.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // makes no gravity
                }
            }
        }
    }
}
