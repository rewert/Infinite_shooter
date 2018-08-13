 using UnityEngine;
 using System.Collections;
 
 public class turretfollow : MonoBehaviour 
 {   
    public GameObject target;
    public GameObject missile;

	void Start(){
		target = GameObject.FindGameObjectWithTag("Player");
        missile = Resources.Load<GameObject>("Prefabs/missile") as GameObject;
        InvokeRepeating("LaunchProjectile", 2.0f, 5.0f);
	}

    void Update()
    {   
        if (target == null){
            return;
        }
        Vector3 targetPosition = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z);
		transform.LookAt(targetPosition);
	}
    
    void LaunchProjectile (){        
        Instantiate (missile, transform.position + new Vector3 (0, 100, -10), transform.rotation);
    }
 }
 