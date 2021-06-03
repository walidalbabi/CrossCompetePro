using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoundsInTimer : Singleton<AddRoundsInTimer>
{


    [SerializeField]
    private Transform _Content;

    [SerializeField]
    private GameObject Prefab;

    
    public ContentScript contentScript;

    public void OnClickAdd()
    {
        var pb = Instantiate(Prefab, _Content.position, Quaternion.identity);
        Transform tr = pb.GetComponent<Transform>();

        tr.parent = _Content;
        AmrapManager.instance.ScanChildren();

        contentScript.OnExerciseLoad();
    }
}
