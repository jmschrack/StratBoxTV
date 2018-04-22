using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {
	public Text playerName;
	public RectTransform panel;
	public UnitUI UnitUIPrefab;
	Squad player;
	// Use this for initialization
	
	public delegate void PlayerUIDelegate(Squad s,Chassis chassis);
	public event PlayerUIDelegate OnClick;

	public void Init(Squad player){
		playerName.text=player.name;
		foreach(Chassis c in player.units){
			if(c==null)
				continue;
			UnitUI temp = Instantiate(UnitUIPrefab,panel);
			temp.Init(c);
			temp.OnClick+=unitClick;
		}
	}
	void unitClick(Chassis chassis){
		OnClick(player,chassis);
	}
}
