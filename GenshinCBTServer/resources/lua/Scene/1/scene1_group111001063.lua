--================================================================
-- 
-- 配置
-- 
--================================================================

-- 怪物
monsters = {
	{ config_id = 122, monster_id = 20103027, pos = { x = 309.1, y = 33.4, z = 596.9 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 20 },
	{ config_id = 123, monster_id = 20103027, pos = { x = 318.4, y = 32.2, z = 589.6 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 19 },
	{ config_id = 124, monster_id = 20103027, pos = { x = 305.4, y = 34.0, z = 580.0 }, rot = { x = 0.0, y = 0.0, z = 0.0 }, level = 19 }
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
	monsters = { 122, 123, 124 },
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