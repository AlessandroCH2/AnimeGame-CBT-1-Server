--================================================================
-- 
-- 配置
-- 
--================================================================

-- 怪物
monsters = {
	{ config_id = 66, monster_id = 20103027, pos = { x = 277.9, y = 13.1, z = 922.5 }, rot = { x = 0.0, y = 304.3, z = 0.0 }, level = 20 },
	{ config_id = 67, monster_id = 20103027, pos = { x = 282.8, y = 11.9, z = 932.3 }, rot = { x = 0.0, y = 310.5, z = 0.0 }, level = 21 },
	{ config_id = 257, monster_id = 21010401, pos = { x = 288.7, y = 13.6, z = 922.9 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 21 }
}

-- NPC
npcs = {
}

-- 装置
gadgets = {
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
	monsters = { 66, 67, 257 },
	npcs = { },
	gadgets = { },
	regions = { },
	triggers = { }
}

--================================================================
-- 
-- 触发器
-- 
--================================================================