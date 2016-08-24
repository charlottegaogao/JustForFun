using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class RoleData {
   int _loginTimes = 0;
   int _exp = 0;
   int _money =0;
	int _lastMap = 0;

    public int LoginTimes
    {
        get { return _loginTimes >= 0 ? _loginTimes : 0; }
        set { _loginTimes = value >= 0 ? value:0; }
    }

    public int Exp
    {
        get { return _exp >= 0 ? _exp : 0; }
        set {_exp = value >= 0 ? value : 0; }
    }

    public int Money
    {
        get { return _money >= 0 ? _money : 0; }
        set {_money = value >= 0 ? value : 0; }
    }

	public int LastMap
	{
		get { return _lastMap >= 0 ? _money : 0; }
		set {_lastMap = value >= 0 ? value : 0; }

	}
    public RoleData(int loginTimes = 0, int exp = 0, int money =0,int lastMap = 0)
    {
        _loginTimes = loginTimes;
        _exp = exp;
        _money = money;
		_lastMap = 0;
    }



}
