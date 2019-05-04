using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleData : MonoBehaviour {
    public static RoleData instance;
    public List<RoleInfo> roles = new List<RoleInfo>();

    // Start is called before the first frame update
    void Awake() {
        instance = this;
        InitRolesData();
    }

    private void InitRolesData() {
        RoleInfo phree = new RoleInfo("Phree", "弗雷", "18岁，是男主角");
        RoleInfo soda = new RoleInfo("Soda", "苏打", "在一系列令人厌倦的经历后，放弃社会人身份，成为了Monica的店员，现在是店里的头号懒鬼。");
        RoleInfo boss = new RoleInfo("Boss", "店长", "神秘的快闪咖啡店Monica的店长，即使店里的生意经营惨淡也丝毫不在意的土豪，似乎也有经历过大风大浪的过去。");
        boss.RoleLikeList = new List<string>() { "蜂蜜柚子茶" };
        boss.RoleTagDic.Add(0, new string[] {
            "1|Boss|0|\"倒也还挺不错的嘛\""
            , "1|Boss|0|\"这个冰镇的口感，我很喜欢\"" });
        boss.RoleTagDic.Add(1, new string[] {
            "1|Boss|0|\"挺不错的嘛\""
            , "1|Boss|0|\"这个甜度，太王道了\"" });

        roles.Add(phree);
        roles.Add(soda);
        roles.Add(boss);
    }

}
