using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
//using UnityEngine.Physics2DModule;

public class DnDItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    //private hp = 100;

    [SerializeField] private Canvas canvas; 
    [SerializeField] private GameObject target; 


    //get index
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //object = null;

    }

    //handle dnd
    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("Open location images");
        canvasGroup.blocksRaycasts = false;
        target.SetActive(true);
    }

    //while dnd
    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
    }

    //while drop
    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("OnDrop");
    }

    //ending dnd
    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("Close location images");
        canvasGroup.blocksRaycasts = true;
        target.SetActive(false);
    }

    
    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("OnPointerDown");
    }

    /*void Update()
    {   
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            //Debug.Log("Raycast shot");
            
            if (hit.collider != null) {
                //Debug.Log("Raycast check");
                //Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                //Debug.Log("Raycast collider null");
            }   
        }
    }
    */

/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
}
