using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//a class of Dialog. 
public class Dialog {
    
    //name of the speaker
    public string name;

    //what is the speaker speaking
    [TextArea(3, 10)]
    public string[] sentences;

}