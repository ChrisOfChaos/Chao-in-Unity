using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveMorphTest : MonoBehaviour
{
    public GameObject ChaoHead;
    public GameObject ChaoLWing;
    public GameObject ChaoRWing;
    public GameObject ChaoTail;
    SkinnedMeshRenderer ChaoHeadMesh;
    SkinnedMeshRenderer ChaoLWingMesh;
    SkinnedMeshRenderer ChaoRWingMesh;
    SkinnedMeshRenderer ChaoTailMesh;
    Renderer ChaoHeadMat;
    public float evolveTimer;
    public float evolveSpeed;//Sets speed at which Chao evolves at.
    public float evolveLevel;
    public bool evolveActive;
    public bool Hero;
    public bool Dark;
    public bool Swim;
    public bool Fly;
    public bool Run;
    public bool Power;
    public int AlignHero;
    public int AlignDark;
    // Start is called before the first frame update
    /*Starter script for testing evolution morphs. It's not complete as the Chao can't be evolved into Hero/Dark subtypes, but works well for previewing the Chao. Maybe
    add a way to reset the evolveTimer automatically? */
    void Start()
    {
        ChaoHeadMesh = ChaoHead.GetComponent<SkinnedMeshRenderer>();
        ChaoHeadMat = ChaoHead.GetComponent<Renderer>();
        ChaoLWingMesh = ChaoLWing.GetComponent<SkinnedMeshRenderer>();
        ChaoRWingMesh = ChaoRWing.GetComponent<SkinnedMeshRenderer>();
        ChaoTailMesh = ChaoTail.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    /*This is currently set to morph the Chao until it's slider is maxed out.*/
    {
        if(evolveActive == true){
            if(Hero == true){
                evolveLevel = ChaoHeadMesh.GetBlendShapeWeight(6);
                if(evolveLevel<=100){
                    evolveTimer+=Time.deltaTime;
                    ChaoHeadMesh.SetBlendShapeWeight(6, evolveTimer*evolveSpeed);
                    ChaoLWingMesh.SetBlendShapeWeight(6, evolveTimer*evolveSpeed);
                    ChaoRWingMesh.SetBlendShapeWeight(6, evolveTimer*evolveSpeed);
                    ChaoTailMesh.SetBlendShapeWeight(6, evolveTimer*evolveSpeed);
                } else{
                    evolveActive = false;
                }
            }
            else if(Dark == true){
                evolveLevel = ChaoHeadMesh.GetBlendShapeWeight(12);
                if(evolveLevel<=100){
                    evolveTimer+=Time.deltaTime;
                    ChaoHeadMesh.SetBlendShapeWeight(12, evolveTimer*evolveSpeed);
                    ChaoLWingMesh.SetBlendShapeWeight(12, evolveTimer*evolveSpeed);
                    ChaoRWingMesh.SetBlendShapeWeight(12, evolveTimer*evolveSpeed);
                    ChaoTailMesh.SetBlendShapeWeight(12, evolveTimer*evolveSpeed);
                } else{
                    evolveActive = false;
                }
            }
            else if(Swim == true){
                evolveLevel = ChaoHeadMesh.GetBlendShapeWeight(1);
                if(evolveLevel<=100){
                    evolveTimer+=Time.deltaTime;
                    ChaoHeadMesh.SetBlendShapeWeight(1, evolveTimer*evolveSpeed);
                    ChaoLWingMesh.SetBlendShapeWeight(1, evolveTimer*evolveSpeed);
                    ChaoRWingMesh.SetBlendShapeWeight(1, evolveTimer*evolveSpeed);
                    ChaoTailMesh.SetBlendShapeWeight(1, evolveTimer*evolveSpeed);
                } else{
                    evolveActive = false;
                }
            }
            else if(Fly == true){
                evolveLevel = ChaoHeadMesh.GetBlendShapeWeight(2);
                if(evolveLevel<=100){
                    evolveTimer+=Time.deltaTime;
                    ChaoHeadMesh.SetBlendShapeWeight(2, evolveTimer*evolveSpeed);
                    ChaoLWingMesh.SetBlendShapeWeight(2, evolveTimer*evolveSpeed);
                    ChaoRWingMesh.SetBlendShapeWeight(2, evolveTimer*evolveSpeed);
                    ChaoTailMesh.SetBlendShapeWeight(2, evolveTimer*evolveSpeed);
                } else{
                    evolveActive = false;
                }
            }
            else if(Run == true){
                evolveLevel = ChaoHeadMesh.GetBlendShapeWeight(3);
                if(evolveLevel<=100){
                    evolveTimer+=Time.deltaTime;
                    ChaoHeadMesh.SetBlendShapeWeight(3, evolveTimer*evolveSpeed);
                    ChaoLWingMesh.SetBlendShapeWeight(3, evolveTimer*evolveSpeed);
                    ChaoRWingMesh.SetBlendShapeWeight(3, evolveTimer*evolveSpeed);
                    ChaoTailMesh.SetBlendShapeWeight(3, evolveTimer*evolveSpeed);
                } else{
                    evolveActive = false;
                }
            }
            else if(Power == true){
                evolveLevel = ChaoHeadMesh.GetBlendShapeWeight(4);
                if(evolveLevel<=100){
                    evolveTimer+=Time.deltaTime;
                    ChaoHeadMesh.SetBlendShapeWeight(4, evolveTimer*evolveSpeed);
                    ChaoLWingMesh.SetBlendShapeWeight(4, evolveTimer*evolveSpeed);
                    ChaoRWingMesh.SetBlendShapeWeight(4, evolveTimer*evolveSpeed);
                    ChaoTailMesh.SetBlendShapeWeight(4, evolveTimer*evolveSpeed);
                } else{
                    evolveActive = false;
                }
            }
        }
    }
}
