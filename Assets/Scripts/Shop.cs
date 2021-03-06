using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ListOfAllCards ListOfAllCards;
    public Deck Deck;
    public List<Card> CardsToBuy;
    public List<Card> InstantiatedCards;
    public List<Button> BuyButtons = new List<Button>();
    public Button BuyHealButton;
    public int shopSize = 6;
    public Vector3[] positions;
    public int cardCost = 250;
    public int destroyCost = 100;
    public int healCost = 200;
    public int itemCost = 250;
    public Button BuyItem1;
    public GameObject Item1;
    public GameObject Item1Instance;
    public Button BuyItem2;
    public GameObject Item2;
    public GameObject Item2Instance;
    public GameObject ItemHolder;
    public Player player;
    public Text playerGold;
    // Start is called before the first frame update
    void Start()
    {
        ListOfAllCards = FindObjectOfType<ListOfAllCards>();
        Deck = FindObjectOfType<Deck>();
        player = FindObjectOfType<Player>();
        Treasure treasures = FindObjectOfType<Treasure>();
        Item1 = treasures.PullRandom();
        Item2 = treasures.PullRandom();
        if(Item1 == null)
        {
            BuyItem1.gameObject.SetActive(false);
        }
        else
        {
            GameObject instance = Instantiate(Item1);
            Item1Instance = instance.GetComponentInChildren<PassiveItem>().gameObject;
            Item1Instance.transform.SetParent(ItemHolder.transform);
        }
        if(Item2 == null)
        {
            BuyItem2.gameObject.SetActive(false);
        }
        else
        {
            GameObject instance = Instantiate(Item2);
            Item2Instance = instance.GetComponentInChildren<PassiveItem>().gameObject;
            Item2Instance.transform.SetParent(ItemHolder.transform);
        }
        positions = new Vector3[shopSize];
        positions[0] = new Vector3(-36f, 5.5f, 7.2f);
        positions[1] = new Vector3(-33.25f, 5.5f, 7.2f);
        positions[2] = new Vector3(-30.55f, 5.5f, 7.2f);
        positions[3] = new Vector3(-36f, 1.6f, 7.2f);
        positions[4] = new Vector3(-33.25f, 1.6f, 7.2f);
        positions[5] = new Vector3(-30.55f, 1.6f, 7.2f);
        StartCoroutine(PopulateShop());
        playerGold.text = player.gold.ToString();
        foreach (Button b in BuyButtons)
        {
            if(player.gold >= cardCost)
            {
                b.interactable = true;
            }
            else
            {
                b.interactable = false;
            }
        }
        if(player.gold >= healCost)
        {
            BuyHealButton.interactable = true;
        }
        else
        {
            BuyHealButton.interactable = false;
        }
        if(player.gold >= itemCost)
        {
            BuyItem1.interactable = true;
            BuyItem2.interactable = true;
        }
        else
        {
            BuyItem1.interactable = false;
            BuyItem2.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PopulateShop()
    {
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < shopSize; i++)
        {
            CardsToBuy.Add(ListOfAllCards.DrawRandom());
            Card added = Instantiate(CardsToBuy[i]);
            InstantiatedCards.Add(added);
            added.transform.position = positions[i];
            added.transform.eulerAngles = new Vector3(-90f, 0, -90f);
            InstantiatedCards[i].GetComponent<Collider>().enabled = false;
        }
        yield return null;
    }

    public void BuyCard(int i)
    {
        if(i >= 0 && i < CardsToBuy.Count && player.gold >= cardCost)
        {
            Debug.Log("Card bought");
            player.gold -= cardCost;
            playerGold.text = player.gold.ToString();
            Deck.AddCard(CardsToBuy[i]);
            Card ToDestroy = InstantiatedCards[i];
            Destroy(ToDestroy.gameObject);
            foreach (Button b in BuyButtons)
            {
                if (player.gold >= cardCost)
                {
                    b.interactable = true;
                }
                else
                {
                    b.interactable = false;
                }
            }
            if (player.gold >= healCost)
            {
                BuyHealButton.interactable = true;
            }
            else
            {
                BuyHealButton.interactable = false;
            }
            if (player.gold >= itemCost)
            {
                BuyItem1.interactable = true;
                BuyItem2.interactable = true;
            }
            else
            {
                BuyItem1.interactable = false;
                BuyItem2.interactable = false;
            }
        }
    }

    public void BuyHeal()
    {
        if(player.gold >= healCost)
        {
            player.Heal(player.maxHealth - player.health);

            foreach (Button b in BuyButtons)
            {
                if (player.gold >= cardCost)
                {
                    b.interactable = true;
                }
                else
                {
                    b.interactable = false;
                }
            }
            if (player.gold >= itemCost)
            {
                BuyItem1.interactable = true;
                BuyItem2.interactable = true;
            }
            else
            {
                BuyItem1.interactable = false;
                BuyItem2.interactable = false;
            }
        }
    }
    public void BuyItemOne()
    {
        if (player.gold >= itemCost)
        {
            player.gold -= itemCost;
            playerGold.text = player.gold.ToString();
            player.InventoryUI.GetComponentInChildren<Inventory>().AddItem(Item1);
            Destroy(Item1Instance);

            foreach (Button b in BuyButtons)
            {
                if (player.gold >= cardCost)
                {
                    b.interactable = true;
                }
                else
                {
                    b.interactable = false;
                }
            }
            if (player.gold >= itemCost)
            {
                BuyItem2.interactable = true;
            }
            else
            {
                BuyItem2.interactable = false;
            }
            if (player.gold >= healCost)
            {
                BuyHealButton.interactable = true;
            }
            else
            {
                BuyHealButton.interactable = false;
            }
        }
    }

    public void BuyItemTwo()
    {
        if (player.gold >= itemCost)
        {
            player.gold -= itemCost;
            playerGold.text = player.gold.ToString();
            player.InventoryUI.GetComponentInChildren<Inventory>().AddItem(Item2);
            Destroy(Item2Instance);

            foreach (Button b in BuyButtons)
            {
                if (player.gold >= cardCost)
                {
                    b.interactable = true;
                }
                else
                {
                    b.interactable = false;
                }
            }
            if (player.gold >= itemCost)
            {
                BuyItem1.interactable = true;
            }
            else
            {
                BuyItem1.interactable = false;
            }
            if (player.gold >= healCost)
            {
                BuyHealButton.interactable = true;
            }
            else
            {
                BuyHealButton.interactable = false;
            }
        }
    }

    public void RemoveCard(int i)
    {
        //for (int i = 0; i < Deck.CurrentDeck.Count; i++)
        //{
        //    if (c.GetType() == Deck.CurrentDeck[i].GetType())
        //    {
        //        Deck.CurrentDeck.RemoveAt(i);
        //        break;
        //    }
        //}
        if(player.gold >= destroyCost)
        {
            player.gold -= destroyCost;
            playerGold.text = player.gold.ToString();
            Deck.RemoveCardByIndex(i);
            foreach (Button b in BuyButtons)
            {
                if (player.gold >= cardCost)
                {
                    b.interactable = true;
                }
                else
                {
                    b.interactable = false;
                }
            }
            if (player.gold >= healCost)
            {
                BuyHealButton.interactable = true;
            }
            else
            {
                BuyHealButton.interactable = false;
            }
            if (player.gold >= itemCost)
            {
                BuyItem1.interactable = true;
                BuyItem2.interactable = true;
            }
            else
            {
                BuyItem1.interactable = false;
                BuyItem2.interactable = false;
            }
        }
    }
}
