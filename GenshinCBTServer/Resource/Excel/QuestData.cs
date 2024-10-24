namespace GenshinCBTServer.Excel;
using GenshinCBTServer.Data;
using Newtonsoft.Json;

public enum QuestCond
{
    QUEST_COND_NONE = 0,

    QUEST_COND_STATE_EQUAL = 1, 

    QUEST_COND_STATE_NOT_EQUAL = 2, 

    QUEST_COND_PACK_HAVE_ITEM = 3,

    QUEST_COND_AVATAR_ELEMENT_EQUAL = 4, 

    QUEST_COND_AVATAR_ELEMENT_NOT_EQUAL = 5,

    QUEST_COND_AVATAR_CAN_CHANGE_ELEMENT = 6,

    QUEST_COND_WORLD_AREA_LEVEL_EQUAL_GREATER = 7,
}
public enum LogicType
{
    LOGIC_NONE = 0,
    LOGIC_AND = 1,
    LOGIC_OR = 2,
    LOGIC_NOT = 3,
    LOGIC_A_AND_ETCOR = 4,
    LOGIC_A_AND_B_AND_ETCOR = 5,
    LOGIC_A_OR_ETCAND = 6,
    LOGIC_A_OR_B_OR_ETCAND = 7,
    LOGIC_A_AND_B_OR_ETCAND = 8
}

public static class LogicTypeExtensions
{
    public static bool Calculate(this LogicType logicType, uint[] progress)
    {
        if (progress.Length == 0)
        {
            return true;
        }

        if (logicType == LogicType.LOGIC_NONE)
        {
            return progress[0] == 1;
        }

        switch (logicType)
        {
            case LogicType.LOGIC_AND:
                return progress.All(i => i == 1);
            case LogicType.LOGIC_OR:
                return progress.Any(i => i == 1);
            case LogicType.LOGIC_NOT:
                return progress.All(i => i != 1);
            case LogicType.LOGIC_A_AND_ETCOR:
                return progress[0] == 1 && progress.Skip(1).Any(i => i == 1);
            case LogicType.LOGIC_A_AND_B_AND_ETCOR:
                return progress[0] == 1 && progress[1] == 1 && progress.Skip(2).Any(i => i == 1);
            case LogicType.LOGIC_A_OR_ETCAND:
                return progress[0] == 1 || progress.Skip(1).All(i => i == 1);
            case LogicType.LOGIC_A_OR_B_OR_ETCAND:
                return progress[0] == 1 || progress[1] == 1 || progress.Skip(2).All(i => i == 1);
            case LogicType.LOGIC_A_AND_B_OR_ETCAND:
                return progress[0] == 1 && progress[1] == 1 || progress.Skip(2).All(i => i == 1);
            default:
                return progress.Any(i => i == 1);
        }
    }

    public static bool Calculate(this LogicType logicType, List<Func<bool>> predicates)
    {
        switch (logicType)
        {
            case LogicType.LOGIC_AND:
                return predicates.All(predicate => predicate());
            case LogicType.LOGIC_OR:
                return predicates.Any(predicate => predicate());
            default:
                Console.WriteLine("Unimplemented logic operation was called");
                return false;
        }
    }

    public static int GetValue(this LogicType logicType)
    {
        return (int)logicType;
    }
}
public enum QuestContent
{
    QUEST_CONTENT_NONE = 0,
    QUEST_CONTENT_KILL_MONSTER = 1, // currently unused
    QUEST_CONTENT_COMPLETE_TALK = 2,
    QUEST_CONTENT_MONSTER_DIE = 3,
    QUEST_CONTENT_FINISH_PLOT = 4,
    QUEST_CONTENT_OBTAIN_ITEM = 5,
    QUEST_CONTENT_TRIGGER_FIRE = 6,
    QUEST_CONTENT_CLEAR_GROUP_MONSTER = 7,
    QUEST_CONTENT_NOT_FINISH_PLOT = 8, // missing triggers, fail
    QUEST_CONTENT_ENTER_DUNGEON = 9,
    QUEST_CONTENT_ENTER_MY_WORLD = 10,
    QUEST_CONTENT_FINISH_DUNGEON = 11,
    QUEST_CONTENT_DESTROY_GADGET = 12,
    QUEST_CONTENT_OBTAIN_MATERIAL_WITH_SUBTYPE = 13, // missing, finish
    QUEST_CONTENT_NICK_NAME = 14, // missing, currently unused
    QUEST_CONTENT_WORKTOP_SELECT = 15, // currently unused
    QUEST_CONTENT_SEAL_BATTLE_RESULT = 16, // missing, currently unused
    QUEST_CONTENT_ENTER_ROOM = 17,
    QUEST_CONTENT_GAME_TIME_TICK = 18,
    QUEST_CONTENT_FAIL_DUNGEON = 19,
    QUEST_CONTENT_LUA_NOTIFY = 20,
    QUEST_CONTENT_TEAM_DEAD = 21, // missing, fail
    QUEST_CONTENT_COMPLETE_ANY_TALK = 22,
    QUEST_CONTENT_UNLOCK_TRANS_POINT = 23,
    QUEST_CONTENT_ADD_QUEST_PROGRESS = 24,
    QUEST_CONTENT_INTERACT_GADGET = 25,
    QUEST_CONTENT_DAILY_TASK_COMP_FINISH = 26, // missing, currently unused
    QUEST_CONTENT_FINISH_ITEM_GIVING = 27,
    QUEST_CONTENT_SKILL = 107,
    QUEST_CONTENT_CITY_LEVEL_UP = 109, // missing, finish
    QUEST_CONTENT_PATTERN_GROUP_CLEAR_MONSTER = 110, // missing, finish, for random quests
    QUEST_CONTENT_ITEM_LESS_THAN = 111,
    QUEST_CONTENT_PLAYER_LEVEL_UP = 112,
    QUEST_CONTENT_DUNGEON_OPEN_STATUE = 113, // missing, currently unused
    QUEST_CONTENT_UNLOCK_AREA = 114, // currently unused
    QUEST_CONTENT_OPEN_CHEST_WITH_GADGET_ID = 115, // missing, currently unused
    QUEST_CONTENT_UNLOCK_TRANS_POINT_WITH_TYPE = 116, // missing, currently unused
    QUEST_CONTENT_FINISH_DAILY_DUNGEON = 117, // missing, currently unused
    QUEST_CONTENT_FINISH_WEEKLY_DUNGEON = 118, // missing, currently unused
    QUEST_CONTENT_QUEST_VAR_EQUAL = 119,
    QUEST_CONTENT_QUEST_VAR_GREATER = 120,
    QUEST_CONTENT_QUEST_VAR_LESS = 121,
    QUEST_CONTENT_OBTAIN_VARIOUS_ITEM = 122, // missing, finish
    QUEST_CONTENT_FINISH_TOWER_LEVEL = 123, // missing, currently unused
    QUEST_CONTENT_BARGAIN_SUCC = 124,
    QUEST_CONTENT_BARGAIN_FAIL = 125,
    QUEST_CONTENT_ITEM_LESS_THAN_BARGAIN = 126,
    QUEST_CONTENT_ACTIVITY_TRIGGER_FAILED = 127, // missing, fail
    QUEST_CONTENT_MAIN_COOP_ENTER_SAVE_POINT = 128, // missing, finish
    QUEST_CONTENT_ANY_MANUAL_TRANSPORT = 129,
    QUEST_CONTENT_USE_ITEM = 130,
    QUEST_CONTENT_MAIN_COOP_ENTER_ANY_SAVE_POINT = 131, // missing, finish and fail
    QUEST_CONTENT_ENTER_MY_HOME_WORLD = 132, // missing, finish and fail
    QUEST_CONTENT_ENTER_MY_WORLD_SCENE = 133, // missing, finish
    QUEST_CONTENT_TIME_VAR_GT_EQ = 134,
    QUEST_CONTENT_TIME_VAR_PASS_DAY = 135,
    QUEST_CONTENT_QUEST_STATE_EQUAL = 136,
    QUEST_CONTENT_QUEST_STATE_NOT_EQUAL = 137,
    QUEST_CONTENT_UNLOCKED_RECIPE = 138, // missing, finish
    QUEST_CONTENT_NOT_UNLOCKED_RECIPE = 139, // missing, finish
    QUEST_CONTENT_FISHING_SUCC = 140, // missing, finish
    QUEST_CONTENT_ENTER_ROGUE_DUNGEON = 141, // missing, finish
    QUEST_CONTENT_USE_WIDGET = 142, // missing, finish, only in unreleased quest
    QUEST_CONTENT_CAPTURE_SUCC = 143, // missing, currently unused
    QUEST_CONTENT_CAPTURE_USE_CAPTURETAG_LIST = 144, // missing, currently unused
    QUEST_CONTENT_CAPTURE_USE_MATERIAL_LIST = 145, // missing, finish
    QUEST_CONTENT_ENTER_VEHICLE = 147,
    QUEST_CONTENT_SCENE_LEVEL_TAG_EQ = 148, // missing, finish
    QUEST_CONTENT_LEAVE_SCENE = 149,
    QUEST_CONTENT_LEAVE_SCENE_RANGE = 150, // missing, fail
    QUEST_CONTENT_IRODORI_FINISH_FLOWER_COMBINATION = 151, // missing, finish
    QUEST_CONTENT_IRODORI_POETRY_REACH_MIN_PROGRESS = 152, // missing, finish
    QUEST_CONTENT_IRODORI_POETRY_FINISH_FILL_POETRY = 153, // missing, finish
    QUEST_CONTENT_ACTIVITY_TRIGGER_UPDATE = 154, // missing
    QUEST_CONTENT_GADGET_STATE_CHANGE = 155, // missing
    QUEST_CONTENT_UNKNOWN = 9999
}
public class QuestCondition
{
    public uint type;
    public uint[] param;
    public string param_str;
    public uint count;
}
public class QuestExecuteCondition
{
    public uint type;
    public string[] param;
}
public class QuestData
{
    public uint subId;
    public uint mainId;
    public bool finishParent;
    public uint acceptCondComb;
    public List<QuestCondition> acceptCond;
    public uint finishCondComb;
    public List<QuestCondition> finishCond;
    public List<QuestExecuteCondition> finishExec;
}
public class MainQuestData
{
    public uint id;
    public QuestType type;
    public uint activeMode;
    public string luaPath;
    public uint rewardId;
    public uint chapterId;
   
}

public enum QuestType 
{
    AQ=0,
    FQ=1,
    LQ=2,
    EQ=3,
    DQ=4,
    IQ=5,
    VQ=6,
    WQ=7
}
public class TalkData
{

}