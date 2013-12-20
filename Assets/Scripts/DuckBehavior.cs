using UnityEngine;
using System.Collections;

public class DuckBehavior : MonoBehaviour
{
    public AudioClip duck1;
    public AudioClip duck2;
    public AudioClip duck3;
    public AudioClip duck4;

    private Vector3 lastPos;

    GUIText guiBounces;
    _CP CP;

	// Use this for initialization
	void Start ()
    {
        // Get CP
        CP = GameObject.Find("_CP").GetComponent<_CP>();
        guiBounces = GameObject.Find("GUI_Bounces").guiText;

        // Set random rotation on start
        Vector3 randRot;
        randRot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        transform.rotation = Quaternion.Euler(randRot);
        rigidbody.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));

        lastPos = Vector3.zero;
	}

    // Update is called once per frame
    void Update()
    {
        // Keep inside the room
        if (transform.position.x < -20 || transform.position.x > 20 ||
            transform.position.y < 0 || transform.position.y > 20 ||
            transform.position.z < -20 || transform.position.z > 20)
        {
            Vector3 force = rigidbody.velocity;
            transform.position = lastPos;
            rigidbody.AddForce(-new Vector3(force.x + Random.Range(-10, 10), force.y + Random.Range(-10, 10), force.z + Random.Range(-10, 10)) + rigidbody.angularVelocity*2);
        }

        lastPos = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        CP.bounces += 1;
        CP.CheckBouncingReward();
        guiBounces.text = "Bounces: " + CP.bounces.ToString();

        // Set audio clip and play
        int rand;
        rand = Random.Range(1, 5);

        switch (rand)
        {
            case 1: audio.clip = duck1; break;
            case 2: audio.clip = duck2; break;
            case 3: audio.clip = duck3; break;
            case 4: audio.clip = duck4; break;
        }

        audio.Play();

        // Crazy?
        if (gameObject.name.StartsWith("DuckCrazy"))
        {
            // Get wall normal for bounce calculation
            Vector3 normal = Vector3.zero;
            switch (collision.collider.tag)
            {
                case "Wall100": normal = new Vector3(0, 1, 0); break;
                case "Wall-100": normal = new Vector3(0, -1, 0); break;
                case "Wall001": normal = new Vector3(0, 0, 1); break;
                case "Wall00-1": normal = new Vector3(0, 0, -1); break;
                case "Wall010": normal = new Vector3(1, 0, 0); break;
                case "Wall0-10": normal = new Vector3(-1, 0, 0); break;
            }

            rigidbody.AddForce(Reflect(rigidbody.velocity, normal).normalized / (Random.Range(0.1f, 2.0f)), ForceMode.Impulse);
        }
    }

    // Bounce
    public static Vector3 Reflect(Vector3 vector, Vector3 normal)
    {
        return vector - 2 * Vector3.Dot(vector, normal) * normal;
    }
}
