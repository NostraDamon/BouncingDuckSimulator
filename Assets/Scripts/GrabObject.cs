using UnityEngine;
using System.Collections;

public class GrabObject : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject pickedUpObject;
    private Vector3 lastPos;

    void Start ()
    {
        lastPos = Vector3.zero;
    }

    void Update ()
    {
        // Keep player inside the room
        if (transform.position.x < -20 || transform.position.x > 20 ||
            transform.position.y < 0 || transform.position.y > 20 ||
            transform.position.z < -20 || transform.position.z > 20)
        {
            transform.position = lastPos;
        }

        lastPos = transform.position;

        // Grab
        if(Input.GetMouseButton(0))
        {
            // Lock mouse cursor
            Screen.lockCursor = true;
            Screen.showCursor = false;

            if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                //the order of the parameters might be wrong.
                if(hit.collider.gameObject.tag == "Duck")
                {
                    if (Vector3.Distance(transform.position, hit.collider.transform.position) < 4)
                    {
                        //if used a tag to see whether the object cn be picked up, you can use another method that may suit you better
                        pickedUpObject = hit.collider.gameObject; //we use this to determine whether an object is picked up by the player. If it's not null, then the player is doing so.
                        //hit.collider.gameObject.transform.parent = transform; //attach the object to the camera so it moves along with it.
                        hit.collider.gameObject.transform.position = transform.position + transform.forward; //might need changing as it's untested.
                        hit.collider.rigidbody.velocity = Vector3.zero;
                        hit.collider.rigidbody.angularVelocity /= 1.1f;
                    }
                }
            }
        }
        else if(pickedUpObject!=null)
        {
            //if player is not holding E but was picking up an object last frame
            pickedUpObject.rigidbody.AddForce(transform.forward * 2, ForceMode.Impulse);
            //pickedUpObject.transform.parent=null; //drop the object
            pickedUpObject=null;  //and nullify the object pointer
        }

        // Unlock mouse cursor
        if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.lockCursor = false;
            Screen.showCursor = true;
        }
    }
}
