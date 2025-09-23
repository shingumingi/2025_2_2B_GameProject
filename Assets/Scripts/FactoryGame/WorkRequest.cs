using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class WorkRequest
{
    public ProductType productType;
    public int quantity;
    public int reward;

    public WorkRequest(ProductType productType, int quantity, int reward)           // »ý¼ºÀÚ
    {
        this.productType = productType;
        this.quantity = quantity;
        this.reward = reward;
    }
}
