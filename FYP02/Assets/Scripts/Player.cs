using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider Healthbar;
    [SerializeField]
    float health = 100f;

    float strength = 1f;
    float dexterity = 1f;
    float intelligence = 1f;

    public float Health { get { return health; } }

    private static Player instance = null;

    public static Player Instance { get { return instance; } }

	// Use this for initialization
	void Awake () {

        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        //Healthbar.value = Health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scrolls"))
        {
            //get scroll type add stat
            other.gameObject.SetActive(false);
        }
    }
}
