using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{
    // not sure what i should do with this yet
    public interface IAction
    {
        
    }
    public interface IMovementDriver
    {
        void Move(Vector2 input);
    }
}
