using UnityEngine;
using System.Collections;

public class gun : MonoBehaviour {
    public Transform bul;
    public Rigidbody bull;
    public static Transform bulletspawn;
    public static Rigidbody bullet;
    public  GunPurse guns;
    private Vector3 rel;
    public AudioClip clip;
    private AudioSource aud;
    private bool fan;
    private Player plan;
    public int bulletDamage;
    public ParticleSystem pSys;
    public int capacity;


    public class GunPurse
    {
        public int ammo;
        public int grenades;
        public int bookbagCapacity;
        public int bulspeed;
        
        public int bulletforce;
        public Rigidbody clone;

        public GunPurse()
        { }
        public GunPurse(int a, int b, int c)
        {
            ammo = a;
            grenades = b;
            bookbagCapacity = c;
            bulspeed = 20000;
           
        }
        public void Fire()
        {
            if (bookbagCapacity <= 0)
            {

            }
            else
            {
                clone = Instantiate(bullet, bulletspawn.position, bulletspawn.rotation) as Rigidbody;
                clone.AddForce(bulletspawn.forward * bulspeed);
                bookbagCapacity--;
            }
        }

    }
	// Use this for initialization
	void Start () {
        pSys = GetComponentInChildren<ParticleSystem>();
        bulletspawn = bul;
        bullet = bull;
        plan = GetComponent<Player>();
        guns = new GunPurse(10,3,2000);
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        capacity = guns.bookbagCapacity;
        bulletDamage = plan.p_Level * 2;
        plan.BulDam = bulletDamage;
        DoUpdates();
       
	}
    void DoUpdates()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            aud.Stop();
            guns.Fire();
            pSys.Play();
            
            aud.Play();
            
        }
        else if (Input.GetKey(KeyCode.X))
        {
            if (aud.time > 4)
            {

                aud.time = 0.7f;

            }
            if (fan == true)
            {
                aud.loop = true;

            }

            guns.Fire();
            fan = true;
            pSys.loop = true;
            pSys.Play();
            
            

        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            fan = false;
            aud.loop = false;
            aud.Stop();
            pSys.loop = false;
        }
        else
        {


            // Do Nothing


        }

    }
    
}
