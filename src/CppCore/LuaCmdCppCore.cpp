#include "stdafx.h"
#include "luajit/lua.hpp"

int luaopen_CppCore(lua_State *L) 
{
	OutputDebugStringA("CppCore: luaopen_CppCore");
	luaL_Reg CppCoreReg[] = {
		{NULL,NULL}
	};
	luaL_register(L, "CppCore", CppCoreReg);
	return 1;
}