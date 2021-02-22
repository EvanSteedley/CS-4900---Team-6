using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSelectable : MonoBehaviour
{
    public Renderer ren;
    public Color defaultColor;
    [SerializeField]
    TileSelection s;
    PlayerClickToMove PCTM;
    bool selected;
    // Start is called before the first frame update
    void Awake()
    {
        s = FindObjectOfType<TileSelection>();
        ren = gameObject.GetComponent("Renderer") as Renderer;
        defaultColor = ren.material.color;
        PCTM = FindObjectOfType<PlayerClickToMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void OnMouseOver()
    //{
    //    // Debug.Log(ren.material.color);
    //    if (!selected)
    //        ren.material.color = Color.cyan;
    //}
    //private void OnMouseExit()
    //{
    //    if (!selected)
    //        ren.material.color = defaultColor;
    //}

    private void OnMouseDown()
    {
        if (enabled)
        {
            selected = true;
            //Sets other selected object to unselected
            if (s.somethingSelected && s.selected != this.gameObject)
            {
                TileSelectable otherObject = s.Selected.GetComponentInChildren<TileSelectable>();
                otherObject.selected = false;
                otherObject.ren.material.color = Color.cyan;
            }
            s.MoveButton.interactable = true;
            s.somethingSelected = true;
            s.Selected = this.gameObject.GetComponent<Tile>();
            PCTM.finalDestination = s.Selected;
            ren.material.color = Color.blue;
        }
    }
}