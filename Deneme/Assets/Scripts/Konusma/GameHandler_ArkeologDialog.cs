using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler_ArkeologDialog : MonoBehaviour
{
    [SerializeField] private Transform heroTransform;

    private void Start()
    {
        ArkeologDialog.DialogBaslat(heroTransform, new Vector3(heroTransform.position.x, heroTransform.position.y), "Merhaba hocam");
    }
}
