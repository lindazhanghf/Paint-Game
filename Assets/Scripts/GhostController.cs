using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject paint_splatter;
    public bool hit_player = false;

    public AudioSource ghost_audio;
    public Material visible_material;

    private float counter = 0;
    private float counter_limit = 0.05f;
    private float path_counter = 0;

    // Use this for initialization
    void Start()
    {
        ghost_audio = GetComponent<AudioSource>();

        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CirclePath"), "time", 10, "easytype", iTween.EaseType.easeInOutSine, "loopType", "loop"));
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CirclePath"), "time", 10, "easytype", iTween.EaseType.linear, "loopType", "loop"));
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CirclePath"), "time", 5, "easytype", iTween.EaseType.linear)); 
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CirclePath"), "speed", 5, "easytype", iTween.EaseType.linear, "loopType", "loop"));// Circle level

        //iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("ZigPath"), "speed", 5,  "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .4));// Zig level
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("ZigPath"), "speed", 5, "easytype", iTween.EaseType.linear));
    }

    void Update()
    {
        if (!hit_player)
        {
            follow_path();
        }

    }

    void OnCollisionEnter(Collision c)
    {
        //GameObject paint = GameObject.CreatePrimitive(PrimitiveType.Plane);
        if (c.gameObject.Equals(GameObject.FindGameObjectWithTag("Player")))
        {
            hit_player = true;
            Debug.Log("HIT player!!!!");
            ghost_audio.Play();
            GetComponent<MeshRenderer>().material = visible_material;
            iTween.Stop(transform.gameObject);
        }
        if (!hit_player && counter >= counter_limit)
        {
            GameObject paint = (GameObject)Instantiate(paint_splatter, c.transform.position, Quaternion.identity);
            GameObject.Destroy(paint, 2f);
            counter = 0;
        }
    }

    void follow_path()
    {
        if (counter < counter_limit)
        {
            counter += Time.deltaTime;
        }
        path_counter += Time.deltaTime;
        if (path_counter >= 10)
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("ZigPath"), "speed", 5, "easytype", iTween.EaseType.linear));
            //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("ZigPath"), "speed", 5, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .4));// Zig level
            path_counter = 0;
        }
        Debug.Log(path_counter);
    }

}
