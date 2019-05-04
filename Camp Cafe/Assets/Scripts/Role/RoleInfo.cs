using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleInfo 
{
    public string roleName;
    public string roleNameCN;
    public string roleInfoStr;
    private List<string[]> roleTagList = new List<string[]>();
    private List<string> roleLikeList = new List<string>();
    Dictionary<int, string[]> roleTagDic = new Dictionary<int, string[]>();

    public List<string[]> RoleTagList { get => roleTagList; set => roleTagList = value; }
    public List<string> RoleLikeList { get => roleLikeList; set => roleLikeList = value; }
    public Dictionary<int, string[]> RoleTagDic { get => roleTagDic; set => roleTagDic = value; }

    public RoleInfo(string roleName, string roleNameCN, string roleInfoStr) {
        this.roleName = roleName;
        this.roleNameCN = roleNameCN;
        this.roleInfoStr = roleInfoStr;
    }

    public RoleInfo(string rolename,string roleNameCN, string roleinfostr, List<string[]> roletaglist,List<string> rolelikelist) {
        roleName = rolename;
        roleInfoStr = roleinfostr;
        roleTagList = roletaglist;
        roleLikeList = rolelikelist;
    }
}
