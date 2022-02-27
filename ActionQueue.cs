using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviour
{
    /*This is a basic test of the Queue system, when C is pressed, an item is removed from the queue.*/
    Queue testQueue = new Queue();
    // Start is called before the first frame update
    void Start()
    {
        testQueue.Enqueue("Andrew");
        testQueue.Enqueue("Chris");
        testQueue.Enqueue("Eric");
        testQueue.Enqueue("Brian");
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            RemoveFromQueue();
        }
    }
    void RemoveFromQueue(){
        var removeditem = testQueue.Dequeue();
        Debug.Log("Current Queue: " + testQueue.Count);//.Count gets the total in the queue.//.Peek gets the queue item without removing it
        Debug.Log("Removed: " + removeditem);
        foreach(var queueitem in testQueue){
            Debug.Log("Remaining: " + queueitem);
        }
    }
    // void ShowFromQueue(Queue queue)
    // {
    //     foreach(var queueitem in queue){
    //         var value = queue.Dequeue();
    //     }
    // }
}
