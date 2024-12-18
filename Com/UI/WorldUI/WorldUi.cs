using Godot;
using System;

public partial class WorldUi : Control
{
	// 当节点第一次进入场景树时调用
	[Export]
	public Label label; // 显示文本
	[Export]
	public Button Stard; // 开始按钮
	[Export]
	public Button Again; // 重来按钮
	[Export]
	public AnimationPlayer animationPlayer; // 动画播放器

	[Export]
	public Sprite2D sprite2D; // 2D精灵
	public TilesData tileData; // 瓦片数据
	public override void _Ready()
	{
		Stard.Pressed += StartFun; // 绑定开始按钮的点击事件

		Again.Pressed += AgainFun; // 绑定重来按钮的点击事件
		Stard.Disabled = true; // 禁用开始按钮
		animationPlayer.Play("Aspr"); // 播放动画
	}

	public void setLabel()
	{
		label.Text = tileData.ToString(); // 设置标签文本为瓦片数据的字符串表示
	}
	private Node2D father;
	private void StartFun()
	{
		Node2D parent = GetParent() as Node2D; // 获取父节点
		PackedScene PlayerMap = GD.Load<PackedScene>("res://Com/PlayerMap/player_map.tscn"); // 加载玩家地图场景

		var playerMap = PlayerMap.Instantiate<PlayerMap>(); // 实例化玩家地图
		World world = parent.GetNode<World>("World"); // 获取世界节点
		WorldUi worldUi = parent.GetNode<WorldUi>("WorldUI"); // 获取世界UI节点

		playerMap.tilesData = tileData; // 设置玩家地图的瓦片数据

		playerMap.noise = world.NoiseGenerator;
		playerMap.noise.Seed = world.NoiseGenerator.Seed; // 设置噪声生成器
		parent.AddChild(playerMap); // 将玩家地图添加到父节点
		world.QueueFree(); // 释放世界节点
		worldUi.QueueFree(); // 释放世界UI节点
	}

	public void setSprite(Vector2 vector2)
	{
		sprite2D.Position = vector2; // 设置精灵的位置
	}
	private void AgainFun()
	{
		Node2D parent = GetParent() as Node2D;

		World world = parent.GetNode<World>("World");
		world.SetTerrain(); // 重置地形
		label.Text = ""; // 清空标签文本
	}
}
