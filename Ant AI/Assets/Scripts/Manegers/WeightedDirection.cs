using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedDirection {
    //Utility AI﻿
    public readonly Vector3 direction;
    public readonly float weight;

    public WeightedDirection(Vector3 direction, float weight)
    {
        this.direction = direction;
        this.weight = weight;
    }

    public enum BlendingType { BLEND, EXCLUSIVE, FALLBACK};
    public BlendingType blending = BlendingType.BLEND;

    public float speed = -1f;
}
