--================================================================
-- 
-- 配置
-- 
--================================================================

-- 怪物
monsters = {
	{ config_id = 573, monster_id = 21010101, pos = { x = 2317.9, y = 254.5, z = -450.0 }, rot = { x = 0.0, y = 205.4, z = 0.0 }, level = 12, drop_id = 303043, disableWander = true, pose_id = 9002 },
	{ config_id = 574, monster_id = 21010101, pos = { x = 2319.9, y = 255.0, z = -450.8 }, rot = { x = 0.0, y = 192.3, z = 0.0 }, level = 12, drop_id = 303043, disableWander = true, pose_id = 9002 }
}

-- NPC
npcs = {
}

-- 装置
gadgets = {
	{ config_id = 1246, gadget_id = 70290002, pos = { x = 2318.7, y = 254.6, z = -447.5 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 1 },
	{ config_id = 1247, gadget_id = 70500000, pos = { x = 2317.6, y = 256.3, z = -446.8 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 1, point_type = 3001, owner = 1246 },
	{ config_id = 1248, gadget_id = 70500000, pos = { x = 2319.5, y = 257.3, z = -448.5 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 1, point_type = 3001, owner = 1246 },
	{ config_id = 1249, gadget_id = 70500000, pos = { x = 2318.7, y = 257.5, z = -446.1 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 1, point_type = 3001, owner = 1246 }
}

-- 区域
regions = {
}

-- 触发器
triggers = {
}

-- 变量
variables = {
}

--================================================================
-- 
-- 初始化配置
-- 
--================================================================

-- 初始化时创建
init_config = {
	suite = 1,
	rand_suite = true,
	npcs = { }
}

--================================================================
-- 
-- 小组配置
-- 
--================================================================

suites = {
	{
		-- suite_id = 0,
		-- description = ,
		monsters = { 573, 574 },
		gadgets = { 1246, 1247, 1248, 1249 },
		regions = { },
		triggers = { },
		rand_weight = 100
	}
}

--================================================================
-- 
-- 触发器
-- 
--================================================================