using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneElementController : MonoBehaviour
{

    //Variables
    Player player;

    private void Awake()
    {
        SceneManager.sceneLoaded += SceneLogic;
        player = FindObjectOfType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SceneLogic(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("Sample Combat") || scene.name.Equals("Combat"))
        {
            player.CombatUI.SetActive(true);
            player.TileMoveUI.SetActive(false);
            player.GetComponent<PlayerClickToMove>().enabled = false;
            player.GetComponent<Movement>().enabled = false;
            player.t = FindObjectOfType<Turns>();
            Debug.Log("Combat scene loaded");
        }
        else if (scene.name.Equals("TileMovement"))
        {
            player.CombatUI.SetActive(false);
            player.TileMoveUI.SetActive(true);
            PlayerClickToMove PCTM = player.GetComponent<PlayerClickToMove>();
            PCTM.enabled = true;
            player.GetComponent<Movement>().enabled = true;
            PCTM.t = FindObjectOfType<TurnsTile>();
            PCTM.movesLeft = PCTM.movesDefault;
            PCTM.EndTurnButton.interactable = true;
            Debug.Log("Tile scene loaded");
        }
    }
}
