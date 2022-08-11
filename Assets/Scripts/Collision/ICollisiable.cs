using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ICollisiable
{
   public void OnCollision(GameObject go);
   public void OnTrigger(Collider other);
}
