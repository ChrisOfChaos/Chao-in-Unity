using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoAppearance : MonoBehaviour
{
    public GameObject ChaoHead;
    public GameObject ChaoLWing;
    public GameObject ChaoRWing;
    public GameObject ChaoTail;
    public GameObject Player;
    public PlayerSettings1 playerSettings;
    SkinnedMeshRenderer ChaoHeadMesh;
    SkinnedMeshRenderer ChaoLWingMesh;
    SkinnedMeshRenderer ChaoRWingMesh;
    SkinnedMeshRenderer ChaoTailMesh;
    Renderer ChaoHeadMat;
    public GameObject theBrain;
	public ChaoBrain2 StoredBrain;
    public int AlignHero;
    public int AlignDark;
    // Start is called before the first frame update
    void Start()
    {
        StoredBrain = theBrain.GetComponent<ChaoBrain2>();
        ChaoHeadMesh = ChaoHead.GetComponent<SkinnedMeshRenderer>();
        ChaoHeadMat = ChaoHead.GetComponent<Renderer>();
        ChaoLWingMesh = ChaoLWing.GetComponent<SkinnedMeshRenderer>();
        ChaoRWingMesh = ChaoRWing.GetComponent<SkinnedMeshRenderer>();
        ChaoTailMesh = ChaoTail.GetComponent<SkinnedMeshRenderer>();
        playerSettings = Player.GetComponent<PlayerSettings1>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && StoredBrain.pet == true){
            if(playerSettings.Hero == true){
                ChaoHeadMesh.SetBlendShapeWeight(5, AlignHero+= 1);
                ChaoLWingMesh.SetBlendShapeWeight(5, AlignHero+= 1);
                ChaoRWingMesh.SetBlendShapeWeight(5, AlignHero+= 1);
                ChaoTailMesh.SetBlendShapeWeight(5, AlignHero+= 1);
                // ChaoHeadMat.material.color = Color.white;
            }
            if(playerSettings.Dark == true){
                ChaoHeadMesh.SetBlendShapeWeight(5, AlignDark+= 1);
                ChaoLWingMesh.SetBlendShapeWeight(5, AlignDark+= 1);
                ChaoRWingMesh.SetBlendShapeWeight(5, AlignDark+= 1);
                ChaoTailMesh.SetBlendShapeWeight(5, AlignDark+= 1);
            }
            //This doesn't work too well. If Chao has points in Hero alignment, and the player switches to Dark and pets them, the Hero Blendshapes don't recede. So I think this needs to be
            //redone so that instead of increasing the values in this script, petting affects an alignment int in stats and sets the blendshape here.
            //(i.e. if pet is true alignment will change in a stats script, and instead of AlignHero or AlignDark we'll use an int called align and set it equal to the Stat script's alignment.)
        }
    }
}
