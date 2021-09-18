using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachCircle : MonoBehaviour
{
    public void circleDone(int x){
        if(x == 1){
            DestroyGameObject();
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
