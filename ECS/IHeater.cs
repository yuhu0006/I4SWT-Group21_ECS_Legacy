namespace ECS
{
	public interface IHeater
	{
		void TurnOn();
		void TurnOff();
		bool RunSelfTest();
	}
}