namespace Code.Game.Battle
{
    public interface ITakeDamage
    {
        UnitType UnitType { get; }
        void TakeDamage(float damage);
    }
}