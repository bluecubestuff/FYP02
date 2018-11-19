using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider Healthbar;
    public Slider Manabar;
    public Text str,dex,intel;
    [SerializeField]
    float health = 100f;
    [SerializeField]
    float mana = 100f;

    float strength = 1f;
    float dexterity = 1f;
    float intelligence = 1f;

    public float Health { get { return health; } }

    public float Mana { get { return mana; } }

    private static Player instance = null;

    public static Player Instance { get { return instance; } }

	// Use this for initialization
	void Start () {

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
        Healthbar.value = Health;
        Manabar.value = Mana;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scrolls"))
        {
            //get scroll type add stat
            if (other.gameObject.name.Contains("Sword"))
                strength += 1;
            if (other.gameObject.name.Contains("Bow"))
                dexterity += 1;
            if (other.gameObject.name.Contains("Staff"))
                intelligence += 1;

            str.text = strength.ToString();
            dex.text = dexterity.ToString();
            intel.text = intelligence.ToString();

            other.gameObject.SetActive(false);
        }
    }

    public void UpdateHealth(float _hp)
    {
        health += _hp;
        Debug.Log(health);
        if (health <= 0f)
            health = 0f;
    }


}
