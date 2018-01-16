namespace _02.Blobs.Entities.Attacks
{
    public abstract class Attack : IAttack
    {
        public abstract void Execute(IBlob attacker, IBlob target);
    }
}