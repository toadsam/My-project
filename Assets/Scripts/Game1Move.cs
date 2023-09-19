//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.Windows;

//public class Game1Move : MonoBehaviour
//{
//    Vector2 a;
//    public float speed;
//    public event Action<Vector2> OnMoveEvent;
//    // Start is called before the first frame update
//    void Start()
//    {
//        OnMoveEvent += Move;
//    }

//    // Update is called once per frame
//    void LateUpdate()
//    {
//        OnMoveEvent?.Invoke(a);
       
//    }
//    void OnMove(InputValue value)
//    {
//        Vector2 input = value.Get<Vector2>();
//        a = value.Get<Vector2>();
//      //  transform.position += new Vector3(input.x, input.y, 0);
//       // Vector2 movedir = new Vector2(input.x, input.y);
//    }
//    private void Move(Vector2 input)
//    {
//        transform.position += new Vector3(input.x * Time.deltaTime * speed, input.y * Time.deltaTime * speed, 0);
//    }
//}
