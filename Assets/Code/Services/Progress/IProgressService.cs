namespace Code.Services.Progress
{
    public interface IProgressService
    {
        float CooldownShoot { get; }
        float BulletSpeed { get; }
        int Hearts { get; set; }
        int Stage { get; set; }
        void Reset();
    }
}