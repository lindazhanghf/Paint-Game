using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
        //iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NewPath"), "time", 10));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NewPath"), "time", 10, "easytype", iTween.EaseType.easeInOutSine));
    }
}

