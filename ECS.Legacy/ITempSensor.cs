﻿namespace ECS.Legacy
{
	public interface ITempSensor
	{
		int GetTemp();
		bool RunSelfTest();
	}
}