using Godot;
using System;
using System.Dynamic;
using System.Text.Json;

public partial class MarkeMap_tree
{

    public MarkeMap_tree()
    {
        MarkeTree();
        AssignValues();
    }
    public TreeCfg Oaktree;
    String jsonStr;
    public void MarkeTree()
    {
        jsonStr = new JsonTool().getJsonDataToString(@".\.\.\Data\Json\Tree\Tree_Oak.json");
    }
    // 赋值
    public void AssignValues()
    {
        Oaktree = JsonSerializer.Deserialize<TreeCfg>(jsonStr);
    }



}
