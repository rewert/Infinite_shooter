using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
	public Rigidbody rb;
	public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    GameObject death;

    private float nextFire;
    GameObject explode;

	void Start()
	{
        death = Resources.Load<GameObject>("Prefabs/death") as GameObject;
        explode = Resources.Load<GameObject>("Prefabs/explode") as GameObject;
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3 
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Instantiate(death, transform.position, transform.rotation);
        }
    }
    public void kill(){
        Destroy(gameObject);
    }
    public void spawn(){
        Instantiate(explode, transform.position, transform.rotation);
    }
}