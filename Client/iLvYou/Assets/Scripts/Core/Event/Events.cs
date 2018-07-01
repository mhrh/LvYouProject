using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestEvent : EventArgs
{
	public TestEvent(int ele)
    {
        Element = ele;
    }

	public int Element;
}

