using UnityEngine;
using System.Collections;

public class Meteor : monsterControl {
	public override void init(){
		currentHp = MaxHp;
	}
	public override void crashed(){
		wells.destroy (this);
	}
}
