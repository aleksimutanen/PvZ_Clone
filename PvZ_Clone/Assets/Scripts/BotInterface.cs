using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Bot {
    void TakeDamage(float damage);
    void NotifyBugEaten();
}