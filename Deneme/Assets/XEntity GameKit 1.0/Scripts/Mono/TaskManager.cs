using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public XEntity.Interactor interactor;
    public static TaskManager instance;

    public Text taskText;

    public string message;

    private void Awake()
    {
        instance = this;
    }

   

    // Start is called before the first frame update
    void Start()
    {
        //taskText.text = interactor.message;
    }

    // Update is called once per frame

    public void UpdateTask()
    {
        taskText.text = (interactor.message + "\n" + interactor.message1 + "\n" + interactor.message2 + "\n" + interactor.message3 + "\n");
    }
}