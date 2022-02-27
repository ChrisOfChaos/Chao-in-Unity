using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory1 : MonoBehaviour
{
    public Queue<GameObject> playerinv = new Queue<GameObject>();

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject[] sortQueue;
    public int itemcount;
    public Sprite placeholder;
    public Sprite fruit;
    public Sprite swimfruit;
    public Sprite flyfruit;
    public Sprite runfruit;
    public Sprite powerfruit;
    public GameObject nearbyitem;
    public GameObject currentitem;
    public bool holdingItem;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("pickup")){
            Debug.LogWarning("Detected a nearby item");
            nearbyitem = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("pickup")){
            nearbyitem = null;
        }
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(nearbyitem != null){
                // itemcount = 0;
                playerinv.Enqueue(nearbyitem);
                UpdateQueue();
                nearbyitem.SetActive(false);
                nearbyitem = null;
                currentitem = playerinv.Peek();
                Debug.Log(playerinv);
            }
        }
        if(Input.GetKeyDown(KeyCode.X)){
            // itemcount = 0;
            playerinv.Dequeue();
            UpdateQueue();
            currentitem = playerinv.Peek();
        }
        if(playerinv.Count != 0){
            holdingItem = true;
        } else{
            item1.SetActive(false);
            holdingItem = false;
        }
        if(itemcount == 4){
            item5.SetActive(false);
        } else if(itemcount == 3){
            item5.SetActive(false);
            item4.SetActive(false);
        } else if(itemcount == 2){
            item5.SetActive(false);
            item4.SetActive(false);
            item3.SetActive(false);
        } else if(itemcount == 1){
            item5.SetActive(false);
            item4.SetActive(false);
            item3.SetActive(false);
            item2.SetActive(false);
        }
    }
    void UpdateQueue(){
        sortQueue = playerinv.ToArray();
        // if(playerinv.Peek().GetComponent<itemstats>().itemtag == "fooditem"){
        //     item1.SetActive(true);
        //     item1.GetComponent<Image>().sprite = fruit;
        // } else if(playerinv.Peek().GetComponent<itemstats>().itemtag == "increasestats"){
        //     item1.SetActive(true);
        //     item1.GetComponent<Image>().sprite = swimfruit;
        // }
        for(itemcount = 0; itemcount < sortQueue.Length; itemcount++){
            Debug.LogWarning(sortQueue[itemcount]);
            if(itemcount == 0){
                if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "fooditem"){
                    item1.SetActive(true);
                    item1.GetComponent<Image>().sprite = fruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaseswim"){
                    item1.SetActive(true);
                    item1.GetComponent<Image>().sprite = swimfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasefly"){
                    item1.SetActive(true);
                    item1.GetComponent<Image>().sprite = flyfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaserun"){
                    item1.SetActive(true);
                    item1.GetComponent<Image>().sprite = runfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasepower"){
                    item1.SetActive(true);
                    item1.GetComponent<Image>().sprite = powerfruit;
                }
            } else if(itemcount == 1){
                if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "fooditem"){
                    item2.SetActive(true);
                    item2.GetComponent<Image>().sprite = fruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaseswim"){
                    item2.SetActive(true);
                    item2.GetComponent<Image>().sprite = swimfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasefly"){
                    item2.SetActive(true);
                    item2.GetComponent<Image>().sprite = flyfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaserun"){
                    item2.SetActive(true);
                    item2.GetComponent<Image>().sprite = runfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasepower"){
                    item2.SetActive(true);
                    item2.GetComponent<Image>().sprite = powerfruit;
                }
            } else if(itemcount == 2){
                if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "fooditem"){
                    item3.SetActive(true);
                    item3.GetComponent<Image>().sprite = fruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaseswim"){
                    item3.SetActive(true);
                    item3.GetComponent<Image>().sprite = swimfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasefly"){
                    item3.SetActive(true);
                    item3.GetComponent<Image>().sprite = flyfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaserun"){
                    item3.SetActive(true);
                    item3.GetComponent<Image>().sprite = runfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasepower"){
                    item3.SetActive(true);
                    item3.GetComponent<Image>().sprite = powerfruit;
                }

            } else if(itemcount == 3){
                if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "fooditem"){
                    item4.SetActive(true);
                    item4.GetComponent<Image>().sprite = fruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaseswim"){
                    item4.SetActive(true);
                    item4.GetComponent<Image>().sprite = swimfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasefly"){
                    item4.SetActive(true);
                    item4.GetComponent<Image>().sprite = flyfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaserun"){
                    item4.SetActive(true);
                    item4.GetComponent<Image>().sprite = runfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasepower"){
                    item4.SetActive(true);
                    item4.GetComponent<Image>().sprite = powerfruit;
                }
            } else if(itemcount == 4){
                if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "fooditem"){
                    item5.SetActive(true);
                    item5.GetComponent<Image>().sprite = fruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaseswim"){
                    item5.SetActive(true);
                    item5.GetComponent<Image>().sprite = swimfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasefly"){
                    item5.SetActive(true);
                    item5.GetComponent<Image>().sprite = flyfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increaserun"){
                    item5.SetActive(true);
                    item5.GetComponent<Image>().sprite = runfruit;
                } else if(sortQueue[itemcount].GetComponent<itemstats>().itemtag == "increasepower"){
                    item5.SetActive(true);
                    item5.GetComponent<Image>().sprite = powerfruit;
                }
            }
        }
        // foreach(GameObject invitem in playerinv){
        //     itemcount+=1;
        //     switch(itemcount){
        //         case 1:
        //             item1.SetActive(true);
        //             break;
        //         case 2:
        //             item2.SetActive(true);
        //             break;
        //         case 3:
        //             item3.SetActive(true);
        //             break;
        //         case 4:
        //             item4.SetActive(true);
        //             break;
        //         case 5:
        //             item5.SetActive(true);
        //             break;
        //     }
        //     /**/
        // }
        /*foreach(GameObject invitem in playerinv){
            if(playerinv.Count == 1){
                if(invitem.GetComponent<itemstats>().itemtag == "fooditem"){
                    item1.GetComponent<Image>().sprite = fruit;
                }
                if(invitem.GetComponent<itemstats>().itemtag == "increasestats"){
                    item1.GetComponent<Image>().sprite = swimfruit;
                }
            }
        }*/
    }
}
