using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public GameObject paint_splatter;

	// Use this for initialization
	void Start () {
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CirclePath"), "time", 10, "easytype", iTween.EaseType.easeInOutSine, "loopType", "loop"));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CirclePath"), "time", 10, "easytype", iTween.EaseType.linear, "loopType", "loop"));
    }

    void OnCollisionEnter (Collision c)
    {
        //c.transform.position
        //GameObject paint = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject paint = (GameObject)Instantiate(paint_splatter, c.transform.position, Quaternion.identity);

    }

}
