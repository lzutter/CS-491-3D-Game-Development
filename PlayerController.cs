using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public GameObject howToPlay;
    
    //inventory
    static int[] inventory = { 0, 0, 0, 1 };
    Text keys;
    Text jumpPotions;
    Text runPotions;

    // Use this for initialization
    void Start () {
        /*keys = GetComponent<Text>();
        jumpPotions = GetComponent<Text>();
        runPotions = GetComponent<Text>();

        keys.text = inventory[0].ToString();
        runPotions.text = inventory[1].ToString();
        jumpPotions.text = inventory[2].ToString();*/
    }

    //handles picking up potions and keys and unlocking locked doors
    void OnTriggerEnter(Collider obj)
    {
        //do what this object does based on it's tag
        if (obj.tag == "Locked Door" && inventory[0] > 0)
        {
            Destroy(obj.gameObject);
        }
        else if (obj.tag == "Key") {

            inventory[0]++;
            //Debug.Log("Keys = " + inventory[0]);
            Destroy(obj.gameObject);
        }
        else if (obj.tag == "Run Potion")
        {

            inventory[1]++;
            Destroy(obj.gameObject);
        }
        else if (obj.tag == "Jump Potion")
        {

            inventory[2]++;
            Destroy(obj.gameObject);
        }
        else if (obj.tag == "Goal Potion") {
            SceneManager.LoadScene(inventory[3]);
            inventory[0] = 0;
            inventory[1] = 0;
            inventory[2] = 0;
            inventory[3]++;
        }
    }

    // Update is called once per frame
    void Update () {

        //Hides and shows the How to Play canvas
        if (Input.GetKeyDown("h")) {
            bool active;
            if (howToPlay.activeInHierarchy == true){
                active = false;
            } else {
                active = true;
            }
            howToPlay.SetActive(active);
        }

        //
        // The inventory part actually works, but I regretably couldn't figure out updating the text
        //

        //drinks a run potion
        if (Input.GetKeyDown("q")) {
            inventory[1]--;
            //runPotions.text = inventory[1].ToString();
            
        }

        //drinks a jump potion
        if (Input.GetKeyDown("e"))
        {
            inventory[2]--;
            //jumpPotions.text = inventory[2].ToString();
            
        }

        //resets level and inventory (not reseting inventory means the player keeps items gained before reset)
        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            inventory[0] = 0;
            inventory[1] = 0;
            inventory[2] = 0;
        }
    }
}
