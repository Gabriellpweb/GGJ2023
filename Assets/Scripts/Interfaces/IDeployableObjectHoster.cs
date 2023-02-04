using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeployableObjectHoster
{
    public void UnsubscribeHostedObject(object sender, System.EventArgs e);
}
